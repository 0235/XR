using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Extends
{
    public static class ObjectExtends
    {
        /// <summary>
        /// 使用该方法的对象的类必须有[Serializable]特性
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object Clone(this object source)
        {
            if (ReferenceEquals(source, null))
                return null;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }

        public static object CloneReflection(this object source)
        {
            //如果是字符串或值类型则直接返回
            if (source is string || source.GetType().IsValueType) return source;
            object retval = Activator.CreateInstance(source.GetType());
            FieldInfo[] fields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, CloneReflection(field.GetValue(source))); }
                catch { }
            }
            return retval;
        }
    }
}
