using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XrCore.Extends;

namespace XrCore.Tools.XML
{
    public class XmlBase<T> where T : XmlBase<T>
    {
        /// <summary>
        /// 转换成Xml
        /// </summary>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="stream">流</param>
        /// <param name="encoding">编码模式</param>
        /// <param name="prefix">命名空间前缀</param>
        /// <param name="ns">命名空间</param>
        /// <param name="includeDeclaration">是否省略xml申明</param>
        /// <returns>xml字符串</returns>
        public string ToXml(Type[] extraTypes = null, Stream stream = null, Encoding encoding = null, string prefix = "", string ns = "", bool includeDeclaration = true) => XmlHelper.Instance.ToXml(this, extraTypes, stream, encoding, prefix, ns, includeDeclaration);
        /// <summary>
        /// 从xml字符串转成模型
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="encoding">编码模式</param>
        /// <returns>类型实例</returns>
        public static T ToEntity(string xml, Type[] extraTypes = null, Encoding encoding = null) => XmlHelper.Instance.Parse<T>(xml, extraTypes, encoding);
        /// <summary>
        /// 从 流 转成模型
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="encoding">编码模式</param>
        /// <param name="needCloseStream">是否需要关闭流</param>
        /// <returns>类型实例</returns>
        public static T ToEntity(Stream stream, Type[] extraTypes = null, Encoding encoding = null, bool needCloseStream = true) => XmlHelper.Instance.Parse<T>(stream, extraTypes, encoding, needCloseStream);
    }
}
