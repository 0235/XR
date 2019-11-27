using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Tools.Log
{
    public interface ILogComponent
    {
        ILog GetLogger(string logName, string component);
    }
}
