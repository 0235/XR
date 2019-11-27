using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Proxy
{
    public interface ITaskMaker
    {
        string CreateTask(string from, string to);
    }
}
