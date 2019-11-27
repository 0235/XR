using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.SingleBase.Pattern
{
    public abstract class SingleBase<T> where T : SingleBase<T>, new()
    {
        private static T instance;
        private static object Lock_Obj = new object();
        public static T Instance
        {
            get
            {
                if (instance == null)
                    lock (Lock_Obj)
                        if (instance == null)
                            instance = new T();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}
