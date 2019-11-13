using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtends
    {
        /// <summary>
        /// 判断是否null或空
        /// </summary>
        /// <param name="str">被判断字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
        /// <summary>
        /// 判断是否null或全是空格
        /// </summary>
        /// <param name="str">被判断字符串</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
        /// <summary>
        /// 获取文件字符串的全部路径
        /// </summary>
        /// <param name="str">文件字符串</param>
        /// <returns></returns>
        public static string GetFullPath(this string str) => Path.GetFullPath(str);
    }
}
