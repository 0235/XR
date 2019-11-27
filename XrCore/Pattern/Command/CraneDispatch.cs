using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Tools.Log;

namespace XrCore.Pattern.Command
{
    public class CraneDispatch : IDispatch
    {
        public bool Dispatch(string from, string to, int whId, int level)
        {
            var logger = Logger.GetLogger("CraneDispatch");
            logger.Info($"create a crane task,from {from} to {to} in wh{whId} by level{level}");
            return true;
        }
    }
}
