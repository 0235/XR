using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Decorator
{
    public interface ITask
    {
        int CreateTask(string from, string to);
    }
}
