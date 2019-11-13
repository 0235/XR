using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XrCore.Extends;
using XrCore.Pattern;

namespace XrCore.Tools.XML
{
    public class XmlHelper : SingleBase<XmlHelper>
    {
        public XmlHelper()
        {

        }
        /// <summary>
        /// 转换成Xml
        /// </summary>
        /// <param name="obj">需要转的对象</param>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="stream">流</param>
        /// <param name="encoding">编码模式</param>
        /// <param name="prefix">命名空间前缀</param>
        /// <param name="ns">命名空间</param>
        /// <param name="omitXmlDeclaration">是否省略xml申明</param>
        /// <param name="needCloseStream">是否关闭流</param>
        /// <returns>xml字符串</returns>
        public string ToXml(object obj, Type[] extraTypes = null, Stream stream = null, Encoding encoding = null, string prefix = "", string ns = "", bool omitXmlDeclaration = true, bool needCloseStream = true)
        {
            if (encoding == null) encoding = new UTF8Encoding(false);
            if (stream == null) stream = new MemoryStream();
            else stream.SetLength(0);
            var serial = new XmlSerializer(obj.GetType(), extraTypes);
            var setting = new XmlWriterSettings();
            setting.Encoding = encoding;
            setting.Indent = true;
            setting.OmitXmlDeclaration = omitXmlDeclaration;
            setting.NewLineOnAttributes = true;
            var xsns = new XmlSerializerNamespaces();
            xsns.Add(prefix, ns);
            var xw = XmlWriter.Create(stream, setting);
            serial.Serialize(xw, obj, xsns);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var result = sr.ReadToEnd();
            if (needCloseStream)
            {
                stream.Flush();
                stream.Close();
            }
            return result;
        }
        /// <summary>
        /// 从xml字符串转成模型
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="encoding">编码模式</param>
        /// <returns>类型实例</returns>
        public T Parse<T>(string xml, Type[] extraTypes = null, Encoding encoding = null)
        {
            if (xml.IsNullOrEmpty()) throw new ArgumentNullException("xml", "传入的字符串为空，无法转换成模型");
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return Parse<T>(stream, extraTypes, encoding);
        }
        /// <summary>
        /// 从 流 转成模型
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="extraTypes">派生类型</param>
        /// <param name="encoding">编码模式</param>
        /// <param name="needCloseStream">编码模式</param>
        /// <returns>类型实例</returns>
        public T Parse<T>(Stream stream, Type[] extraTypes = null, Encoding encoding = null, bool needCloseStream = true)
        {
            var type = typeof(T);
            if (stream?.Length == 0) throw new Exception("传入的流为Null或无长度，无法转换成模型");
            if (!type.IsPublic) throw new Exception($"类型{type.Name}不是Public，无法序列化");
            if (encoding == null) encoding = Encoding.UTF8;
            var serial = new XmlSerializer(type, extraTypes);
            T result = default(T);
            try { result = (T)serial.Deserialize(stream); } catch (Exception ex) { }
            if (needCloseStream)
            {
                stream.Flush();
                stream.Close();
            }
            return result;
        }
    }
}
