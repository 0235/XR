using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Decorator
{
    public class TaskDecorator : ITask
    {
        public ITask Task;
        public TaskDecorator(ITask task)
        {
            this.Task = task;
        }
        public virtual int CreateTask(string from, string to)
        {
            return Task.CreateTask(from, to);
        }
    }
}
