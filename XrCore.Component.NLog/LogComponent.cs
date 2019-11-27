using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Pattern.IOC;
using XrCore.Tools.Log;

namespace XrCore.Component.NLog
{
    [Container(typeof(Tools.Log.ILogComponent), "NLog", ContainerLifeStyle.Singleton)]
    public class LogComponent : ILogComponent
    {
        public ILog GetLogger(string logName, string component)
        {
            var nLogger = LogManager.GetLogger(logName);
            return new NLogger(nLogger);
        }
    }
}
