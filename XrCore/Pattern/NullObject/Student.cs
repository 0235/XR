using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.NullObject
{
    public class Student : StudentBase
    {
        public Student(string name) : base(name)
        {
        }
        public override string GetName()
        {
            return Name;
        }
    }
}
