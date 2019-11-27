using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Tools.Config
{
    /// <summary>
    /// config 文件配置特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class XmlConfigAttribute : Attribute
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 若文件的写入时间和内存中记录的时间不一致时，超过多少毫秒就重读
        /// </summary>
        public int ReloadTime { get; set; }
        /// <summary>
        /// 指定配置文件名
        /// </summary>
        /// <param name="fileName">文件名</param>
        public XmlConfigAttribute(string fileName = "") { FileName = fileName; }
        /// <summary>
        /// 指定配置文件名和重新加载时间（毫秒）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="reloadTime">重读时间（秒）</param>
        public XmlConfigAttribute(int reloadTime, string fileName = "")
        {
            FileName = fileName;
            ReloadTime = reloadTime;
        }
    }
}
