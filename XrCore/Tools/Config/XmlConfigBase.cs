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
                    if (current != null && !NeedUpdate)
                        return current;
                    else
                    {
                        current = Load();
                        if (current == default(TConfig))
                        {
                            current = new TConfig();
                            current.SaveDefault();
                            current.SetExpire();
                        }
                        return current;
                    }
                }
            }
            set
            {
                current = value;
            }
        }
        private static DateTime expire;
        [XmlIgnore]
        protected static bool NeedUpdate
        {
            get
            {
                var now = DateTime.Now;
                if (Setting.ReloadTime > 0 && expire != null && expire < now)
                {
                    var fi = new FileInfo(Setting.FileName);
                    fi.Refresh();
                    expire = fi.LastWriteTime.AddSeconds(Setting.ReloadTime);
                    if (expire < now)
                    {
                        expire = now;
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
        private void SetExpire()
        {
            if (Setting.ReloadTime > 0)
            {
                var fi = new FileInfo(Setting.FileName);
                if (fi.Exists)
                {
                    fi.Refresh();
                    expire = fi.LastWriteTime;
                }
                else expire = DateTime.Now;
            }
        }
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
            return XmlHelper.Instance.ToXml(current, stream: stream);
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
            /// 重新加载时间。单位:毫秒
            /// </summary>
            public static int ReloadTime { get; set; } = 0;
            /// <summary>
            /// 初始Setting
            /// </summary>
            static Setting()
            {
                var type = typeof(TConfig);
                var att = type.GetCustomAttribute<XmlConfigAttribute>();
                if (att != null)
                {
                    if (FileName.IsNullOrEmpty())
                        FileName = $"Config\\{type.Name}.Config";
                    else
                        FileName = att.FileName;
                    ReloadTime = att.ReloadTime;
                }
            }
        }
        #endregion
    }
}
