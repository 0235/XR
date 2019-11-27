using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    public class TaskComplete : ITask
    {
        private TaskModel Task;
        public TaskComplete(TaskModel task)
        {
            this.Task = task;
        }

        public void Create()
        {
            Console.WriteLine("task is already completed");
        }

        public void Execute()
        {
            Console.WriteLine("task is already completed");
        }

        public void Finish()
        {
            Console.WriteLine("task is already completed");
        }

        public void Send()
        {
            Console.WriteLine("task is already completed");
        }
    }
}
