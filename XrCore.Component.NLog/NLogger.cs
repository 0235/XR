using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using XrCore.Tools.Log;

namespace XrCore.Component.NLog
{
    public class NLogger : ILog
    {
        private global::NLog.Logger nLogger;

        public NLogger(global::NLog.Logger nLogger)
        {
            this.nLogger = nLogger;
        }

        public void Debug(string msg) => nLogger.Debug(msg);

        public void Debug(string msg, Exception ex) => nLogger.Debug(ex, msg);

        public void Error(string msg) => nLogger.Error(msg);

        public void Error(string msg, Exception ex) => nLogger.Error(ex, msg);

        public void Fatal(string msg) => nLogger.Fatal(msg);

        public void Fatal(string msg, Exception ex) => nLogger.Fatal(ex, msg);

        public void Info(string msg) => nLogger.Info(msg);

        public void Info(string msg, Exception ex) => nLogger.Info(ex, msg);

        public void Trace(string msg) => nLogger.Trace(msg);

        public void Trace(string msg, Exception ex) => nLogger.Trace(ex, msg);

        public void Warn(string msg) => nLogger.Warn(msg);

        public void Warn(string msg, Exception ex) => nLogger.Warn(ex, msg);
    }
}
