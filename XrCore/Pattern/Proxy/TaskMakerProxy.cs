using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Proxy
{
    public class TaskMakerProxy : ITaskMaker
    {
        ITaskMaker taskMaker;
        public string CreateTask(string from, string to)
        {
            if (taskMaker == null) taskMaker = new TaskMaker();
            return taskMaker.CreateTask(from, to);
        }
    }
}
