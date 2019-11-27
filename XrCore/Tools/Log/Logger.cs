using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Pattern.IOC;

namespace XrCore.Tools.Log
{
    public class Logger
    {
        private static object LocObj = new object();
        private static Dictionary<string, ILog> LogDic = new Dictionary<string, ILog>();
        public static ILog GetLogger(string logName, string component = "NLog")
        {
            ILog result = null;
            var logger = IocManager.Instance.TryResolve<ILogComponent>(component);
            if (logger != default(ILogComponent))
                result = logger.GetLogger(logName, component);
            else
            {
                if (LogDic.ContainsKey(logName))
                    result = LogDic[logName];
                else
                {
                    lock (LocObj)
                    {
                        result = new UnitLogger(logName);
                        if (!LogDic.ContainsKey(logName))
                        {
                            while (LogDic.Count >= 50)
                                LogDic.Remove(LogDic.FirstOrDefault().Key);
                            LogDic.Add(logName, result);
                        }
                    }
                }
            }
            return result;
        }
    }
}
