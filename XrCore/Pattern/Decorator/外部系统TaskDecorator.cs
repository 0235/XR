using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Decorator
{
    public class 外部系统TaskDecorator : TaskDecorator
    {
        public string 外部系统任务主键 { get; private set; }

        public 外部系统TaskDecorator(ITask task) : base(task)
        {

        }
        public override int CreateTask(string from, string to)
        {
            SetKey(Task);
            return base.CreateTask(from, to);
        }
        private void SetKey(ITask task)
        {
            this.外部系统任务主键 = task.ToString();
        }
    }
}
