using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.IOC
{
    public class ContainerAttribute : Attribute
    {
        public Type BaseType { get; private set; }
        public string ModuleName { get; private set; }
        public ContainerLifeStyle ContainerLifeStyle { get; private set; }
        public object[] Paras { get; private set; }
        /// <summary>
        /// Ioc特性，系统初始化时仅自动注入标记了此特性的容器
        /// </summary>
        /// <param name="baseType">基类型，reslove时需要的类型</param>
        /// <param name="moduleName">模块名称，reslove时第二参数</param>
        /// <param name="containerLifeStyle">生命周期</param>
        /// <param name="paras">构造函数参数传入</param>
        public ContainerAttribute(Type baseType, string moduleName = "", ContainerLifeStyle containerLifeStyle = ContainerLifeStyle.InTime, object[] paras = null)
        {
            this.BaseType = baseType;
            this.ModuleName = moduleName;
            this.ContainerLifeStyle = containerLifeStyle;
            this.Paras = paras;
        }
    }
}
