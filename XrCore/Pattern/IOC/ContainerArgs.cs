using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Extends;

namespace XrCore.Pattern.IOC
{
    public class ContainerArgs
    {

        public Type Type { get; private set; }

        public ContainerAttribute ContainerAttribute { get; private set; }


        private static object Instance;
        private static object LocObj = new object();

        public ContainerArgs(Type type, ContainerAttribute containerAttribute)
        {
            this.Type = type;
            this.ContainerAttribute = containerAttribute;
        }

        public object GetInstance()
        {
            if (ContainerAttribute.ContainerLifeStyle == ContainerLifeStyle.Singleton || ContainerAttribute.ContainerLifeStyle == ContainerLifeStyle.Prototype)
            {
                if (Instance == null)
                    lock (LocObj)
                        if (Instance == null)
                            Instance = Activator.CreateInstance(Type, ContainerAttribute.Paras);
                if (ContainerAttribute.ContainerLifeStyle == ContainerLifeStyle.Singleton)
                    return Instance;
                else //原型模式
                    return Instance.CloneReflection();
            }
            else if (ContainerAttribute.ContainerLifeStyle == ContainerLifeStyle.InTime)
                return Activator.CreateInstance(Type, ContainerAttribute.Paras);
            else return null;
        }
    }
}
