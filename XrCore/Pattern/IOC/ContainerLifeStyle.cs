using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.IOC
{
    public enum ContainerLifeStyle
    {
        /// <summary>
        /// 每次使用都新建一个
        /// </summary>
        InTime = 1,
        /// <summary>
        /// 若非重新初始化，否则都只用同一个
        /// </summary>
        Singleton = 2,
        /// <summary>
        /// 原型模式，初始化后注册一个单例对象，每次调用返回该对象的克隆(反射克隆）
        /// </summary>
        Prototype = 4,
    }
}
