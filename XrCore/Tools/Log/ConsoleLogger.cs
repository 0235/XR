using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Tools.Log
{
    public class ConsoleLogger : ILog
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
        public void Debug(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Debug || {msg}");

        public void Debug(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Debug || {msg},堆栈信息：{ex}");

        public void Error(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Error || {msg}");

        public void Error(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Error || {msg},堆栈信息：{ex}");

        public void Fatal(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Fatal || {msg}");

        public void Fatal(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Fatal || {msg},堆栈信息：{ex}");

        public void Info(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Info || {msg}");

        public void Info(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Info || {msg},堆栈信息：{ex}");

        public void Trace(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Trace || {msg}");

        public void Trace(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Trace || {msg},堆栈信息：{ex}");

        public void Warn(string msg) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Warn || {msg}");

        public void Warn(string msg, Exception ex) => Log($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} Warn || {msg},堆栈信息：{ex}");
    }
}
