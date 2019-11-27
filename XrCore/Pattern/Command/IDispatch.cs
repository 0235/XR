using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Command
{
    public interface IDispatch
    {
        bool Dispatch(string from, string to, int whId, int level);
    }
}
