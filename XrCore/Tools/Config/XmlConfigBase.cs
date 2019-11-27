using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XrCore.Extends;
using XrCore.Tools.XML;

namespace XrCore.Tools.Config
{
    public class XmlConfigBase<TConfig> where TConfig : XmlConfigBase<TConfig>, new()
    {

        private static TConfig current;
        public static readonly object LockObj = new object();
        [XmlIgnore]
        public static TConfig Current
        {
            get
            {
                lock (LockObj)
                {
                    if (current != default(TConfig) && !NeedReload)
                        return current;
                    else
                    {
                        var loadedObj = Load();
                        if (loadedObj == default(TConfig) && current == default(TConfig))
                        {
                            current = new TConfig();
                            current.SaveDefault();
                        }
                        else current = loadedObj;
                        return current;
                    }
                }
            }
            set
            {
                current = value;
            }
        }
        [XmlIgnore]
        protected static bool NeedReload
        {
            get
            {
                var now = DateTime.Now;
                if (Setting.ReloadTime > 0 && Setting.LastWriteTime != null && Setting.Expire < now)
                {
                    var expire = now.AddMilliseconds(Setting.ReloadTime);
                    var fi = new FileInfo(Setting.FileName);
                    fi.Refresh();
                    if (Setting.LastWriteTime < fi.LastWriteTime)
                    {
                        Setting.LastWriteTime = fi.LastWriteTime;
                        return true;
                    }
                    else return false;
                }
                return false;
            }
        }
        public XmlConfigBase() { }
        /// <summary>
        /// 保存为默认配置，若有初始化值，则重写该方法
        /// </summary>
        public virtual void SaveDefault() => Save();
        /// <summary>
        /// 读取文件 ，若无文件则返回null
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="extraTypes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        protected static TConfig Load(string filename = "", Type[] extraTypes = null, Encoding encoding = null)
        {
            if (filename.IsNullOrWhiteSpace()) filename = Setting.FileName;
            filename = $"{filename}".GetFullPath();
            Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));
            TConfig config = null;
            var stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (stream != null && stream.Length > 0) config = XmlHelper.Instance.Parse<TConfig>(stream, extraTypes, encoding, needCloseStream: false);
            stream.Flush();
            stream.Close();
            return config;
        }
        public string Save(string fileName = "")
        {
            if (fileName.IsNullOrWhiteSpace()) fileName = Setting.FileName;
            var stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var result = XmlHelper.Instance.ToXml(current, stream: stream);
            var fi = new FileInfo(Setting.FileName);
            fi.Refresh();
            Setting.LastWriteTime = fi.LastWriteTime;
            return result;
        }
        public override string ToString() => XmlHelper.Instance.ToXml(current);
        #region 文件配置
        /// <summary>
        /// 配置数据
        /// </summary>
        public static class Setting
        {
            /// <summary>
            /// 配置文件路径
            /// </summary>
            public static string FileName { get; set; }
            /// <summary>
            /// 允许重新加载的时间。单位:毫秒
            /// </summary>
            public static int ReloadTime { get; set; }
            /// <summary>
            /// 内存中记录的写入时间
            /// </summary>
            public static DateTime LastWriteTime { get; set; }
            /// <summary>
            /// 若当前时间超过这个，则视为可重新加载
            /// </summary>
            public static DateTime Expire { get; set; }
            /// <summary>
            /// 初始Setting
            /// </summary>
            static Setting()
            {
                var type = typeof(TConfig);
                FileName = $"Config\\{type.Name}.Config";
                var att = type.GetCustomAttribute<XmlConfigAttribute>();
                if (att != null)
                {
                    if (!att.FileName.IsNullOrEmpty()) FileName = att.FileName;
                    if (att.ReloadTime > 0)
                    {
                        ReloadTime = att.ReloadTime;
                        Expire = DateTime.Now.AddMilliseconds(ReloadTime);
                    }
                    else
                    {
                        ReloadTime = 0;
                        Expire = DateTime.Now;
                    }
                }
            }
        }
        #endregion
    }
}
