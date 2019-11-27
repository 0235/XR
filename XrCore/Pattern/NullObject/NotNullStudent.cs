using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.NullObject
{
    public class NotNullStudent
    {
        private string Name;
        private bool isNull;
        public NotNullStudent(string name, bool isNull)
        {
            this.Name = name;
        }
        public string GetName()
        {
            return isNull ? $"{Name} is not find" : Name;
        }
    }
}
