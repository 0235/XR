using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Common
{
    public class MethodResult<T>
    {
        public bool IsOk { get; private set; }
        public string Msg { get; private set; }
        public T Obj { get; private set; }
        public MethodResult(bool isOk,string msg,T obj)
        {
            SetResult(isOk, msg, obj);
        }
        public void SetResult(bool isOk = false,string msg = "",T obj = default(T))
        {
            this.IsOk = isOk;
            this.Msg = msg;
            this.Obj = obj;
        }
    }
}
