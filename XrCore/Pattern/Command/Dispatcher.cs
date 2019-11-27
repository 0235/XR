using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Command
{
    public class Dispatcher
    {
        List<IDispatch> Dispatchs = new List<IDispatch>();
        public bool Dispatch(IDispatch dispatch)
        {
            Dispatchs.Add(dispatch);
            return true;
        }
        public bool TakeDispatch()
        {
            foreach (var d in Dispatchs)
            {
                d.Dispatch("", "", 1, 1);
            }
            return true;
        }
    }
}
