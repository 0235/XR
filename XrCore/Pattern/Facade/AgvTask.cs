using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Facade
{
    public class AgvTask : ITask
    {
        public string CreateTask(string from, string to)
        {
            return $"Agv:{from}-{to}";
        }
    }
}
