using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Builder
{
    public class Meal
    {
        public List<string> SthForEat = new List<string>();
        public Meal AddSthToThisMeal(string sth)
        {
            SthForEat.Add(sth);
            return this;
        }
    }
}
