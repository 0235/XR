using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    class TaskSend : ITask
    {
        private TaskModel Task;
        public TaskSend(TaskModel task)
        {
            this.Task = task;
        }

        public void Create()
        {
            Console.WriteLine("task is already send");
        }

        public void Execute()
        {
            Console.WriteLine("task is send,do execute");
            Task.SetState(new TaskExecuting(Task));
        }

        public void Finish()
        {
            Console.WriteLine("task is only send");
        }

        public void Send()
        {
            Console.WriteLine("task is already send");
        }
    }
}
