using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Facade
{
    public class TaskMaker
    {
        public ITask Crane;
        public ITask Agv;
        public string CreateCraneTask(string from, string to)
        {
            if (Crane == null) Crane = new CraneTask();
            return Crane.CreateTask(from, to);
        }
        public string CreateAgvTask(string from, string to)
        {
            if (Agv == null) Agv = new AgvTask();
            return Agv.CreateTask(from, to);
        }
    }
}
