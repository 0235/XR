using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    class TaskCreate : ITask
    {
        private TaskModel Task;
        public TaskCreate(TaskModel task)
        {
            this.Task = task;
        }

        public void Create()
        {
            Console.WriteLine("task is already create");
        }

        public void Execute()
        {
            Console.WriteLine("task is only create");
        }

        public void Finish()
        {
            Console.WriteLine("task is only create");
        }

        public void Send()
        {
            Console.WriteLine("task is create,do send");
            Task.SetState(new TaskSend(Task));
        }
    }
}
