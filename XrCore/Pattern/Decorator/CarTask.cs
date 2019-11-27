using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Decorator
{
    public class CarTask : ITask
    {
        public int CreateTask(string from, string to)
        {
            return 1;
        }
    }
}
