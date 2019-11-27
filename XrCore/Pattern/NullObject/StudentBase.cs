using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.NullObject
{
    public abstract class StudentBase
    {
        protected string Name;
        public StudentBase(string name)
        {
            this.Name = name;
        }
        public abstract string GetName();
    }
}
