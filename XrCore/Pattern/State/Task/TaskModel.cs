using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    public class TaskModel : ITask
    {
        public TaskStatus TaskStatus;
        private ITask Task;
        public TaskModel(ITask task)
        {
            this.Task = task;
        }
        public void SetState(ITask task)
        {
            this.Task = task;
        }
        public void Create()
        {
            Task.Create();
        }

        public void Execute()
        {
            Task.Execute();
        }

        public void Finish()
        {
            Task.Finish();
        }

        public void Send()
        {
            Task.Send();
        }
    }
}
