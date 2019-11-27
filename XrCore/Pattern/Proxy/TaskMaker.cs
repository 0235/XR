using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Proxy
{
    public class TaskMaker : ITaskMaker
    {
        public string CreateTask(string from, string to)
        {
            return $"{from}-{to}";
        }
    }
}
