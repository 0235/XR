using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    class TaskExecuting : ITask
    {
        private TaskModel Task;
        public TaskExecuting(TaskModel task)
        {
            this.Task = task;
        }

        public void Create()
        {
            Console.WriteLine("task is executed,do not create again");
        }

        public void Execute()
        {
            Console.WriteLine("task is already execute");
        }

        public void Finish()
        {
            Task.SetState(new TaskComplete(Task));
            Console.WriteLine("task finished");
        }

        public void Send()
        {
            Console.WriteLine("task is executed,do not send again");
        }
    }
}
