using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern
{
    public class LockSingleBase<T> where T : LockSingleBase<T>, new()
    {
        private static object LockObj = new object();
        private static T current;
        public static T Current
        {
            get
            {
                lock (LockObj)
                {
                    if (current == null) current = new T();
                    return current;
                }
            }
        }

    }
}
