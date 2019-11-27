using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XrCore.Common;
using XrCore.SingleBase.Pattern;
using XrCore.Tools.Log;

namespace XrCore.Pattern.IOC
{
    public class IocManager : SingleBase<IocManager>
    {
        public Dictionary<ContainerKey, ContainerArgs> ContainerDic = new Dictionary<ContainerKey, ContainerArgs>();
        public IocManager()
        {
            var types = CommonObj.Instance.Assemblies.SelectMany(p => p.GetTypes().Select(type => new { type, attr = type.GetCustomAttribute<ContainerAttribute>() }).Where(t => t.attr != null));
            foreach (var type in types)
            {
                AddContainer(type.type, type.attr);
            }
        }
        private void AddContainer(Type type, ContainerAttribute attrContainer, bool isNew = false)
        {
            if (type.GetInterfaces().Where(p => p.FullName == attrContainer.BaseType.FullName).Count() == 0 && type.BaseType != attrContainer.BaseType)
            {
                Logger.GetLogger("IocManager").Error($"类型{type.FullName}没有继承自{attrContainer.BaseType.FullName},无法注册到容器");
            }
            else
            {
                var key = new ContainerKey(attrContainer.ModuleName, attrContainer.BaseType.FullName);
                if (ContainerDic.Keys.Contains(key))
                {
                    if (isNew)
                        ContainerDic.Remove(key);
                    else
                        Logger.GetLogger("IocManager").Warn($"类型:{type.FullName},模块：{attrContainer.ModuleName},继承自{attrContainer.BaseType.FullName},已经注册到容器，无法再次注册");
                }
                var args = new ContainerArgs(type, attrContainer);
                ContainerDic.Add(key, args);
            }
        }
        public void Register<T>(Type registerType, ContainerLifeStyle lifeStyle, string moduleName = "", object[] paras = null)
        {
            AddContainer(registerType, new ContainerAttribute(typeof(T), moduleName, lifeStyle, paras));
        }
        /// <summary>
        /// 强行覆盖注册，可用于原型模式的原型刷新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="registerType"></param>
        /// <param name="lifeStyle"></param>
        /// <param name="moduleName"></param>
        /// <param name="paras"></param>
        public void RegisterNew<T>(Type registerType, ContainerLifeStyle lifeStyle, string moduleName, object[] paras = null)
        {
            AddContainer(registerType, new ContainerAttribute(typeof(T), moduleName, lifeStyle, paras), true);
        }
        public T Resolve<T>(string moduleName = "")
        {
            var parent = typeof(T).FullName;
            var key = new ContainerKey(moduleName, parent);
            //ContainerArgs.FirstOrDefault(p => p.ParentType.Count(d => d.FullName == parent.FullName) > 0 && p.ContainerAttribute.ModuleName == moduleName);
            if (!ContainerDic.Keys.Contains(key))
            {
                string msg = $"容器内没有找到基类型为{parent},模块为{moduleName}的注册信息";
                Logger.GetLogger("IocManager").Fatal(msg);
                throw new KeyNotFoundException(msg);
            }
            return (T)ContainerDic[key].GetInstance();
        }
        public T TryResolve<T>(string moduleName = "")
        {
            var parent = typeof(T).FullName;
            var key = new ContainerKey(moduleName, parent);
            //ContainerArgs.FirstOrDefault(p => p.ParentType.Count(d => d.FullName == parent.FullName) > 0 && p.ContainerAttribute.ModuleName == moduleName);
            if (!ContainerDic.Keys.Contains(key))
                return default(T);
            return (T)ContainerDic[key].GetInstance();
        }
    }
}
