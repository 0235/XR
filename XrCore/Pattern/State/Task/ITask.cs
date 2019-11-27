using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.Task
{
    public enum TaskStatus
    {
        Created = 1,
        Sended = 2,
        Executed = 3,
        Finish = 4,
    }
    public interface ITask
    {
        void Create();
        void Send();
        void Execute();
        void Finish();
    }
}
