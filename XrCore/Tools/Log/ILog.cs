using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Tools.Log
{
    public interface ILog
    {
        /// <summary>
        /// Level = 1
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>日志输出的结果</returns>
        void Trace(string msg);
        /// <summary>
        /// Level = 1
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns>日志输出的结果</returns>
        void Trace(string msg, Exception ex);
        /// <summary>
        /// Level = 2
        /// </summary>
        /// <param name="msg"></param>
        void Debug(string msg);
        /// <summary>
        /// Level = 2
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns>日志输出的结果</returns>
        void Debug(string msg, Exception ex);
        /// <summary>
        /// Level = 3
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>日志输出的结果</returns>
        void Info(string msg);
        /// <summary>
        /// Level = 3
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        void Info(string msg, Exception ex);
        /// <summary>
        /// Level = 4
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>日志输出的结果</returns>
        void Warn(string msg);
        /// <summary>
        /// Level = 4
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns>日志输出的结果</returns>
        void Warn(string msg, Exception ex);
        /// <summary>
        /// Level = 5
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>日志输出的结果</returns>
        void Error(string msg);
        /// <summary>
        /// Level = 5
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns>日志输出的结果</returns>
        void Error(string msg, Exception ex);
        /// <summary>
        /// Level = 6
        /// </summary>
        /// <param name="msg"></param>
        void Fatal(string msg);
        /// <summary>
        /// Level = 6
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns>日志输出的结果</returns>
        void Fatal(string msg, Exception ex);
    }
}
