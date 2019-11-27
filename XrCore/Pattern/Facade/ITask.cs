using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Facade
{
    public interface ITask
    {
        string CreateTask(string from, string to);
    }
}
