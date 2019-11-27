using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Extends;

namespace XrCore.Pattern.IOC
{
    /// <summary>
    /// 容器注册区的主键
    /// </summary>
    public struct ContainerKey
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; }
        /// <summary>
        /// 基类型
        /// </summary>
        public string BaseTypeFullName { get; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="baseTypeFullName">基类型</param>
        public ContainerKey(string moduleName, string baseTypeFullName)
        {
            this.ModuleName = moduleName;
            this.BaseTypeFullName = baseTypeFullName;
        }
    }
}
