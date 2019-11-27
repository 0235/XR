using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Bridge
{
    public abstract class OutstoreTask
    {
        public IOutbound Outbound;
        public OutstoreTask(IOutbound outbound)
        {
            this.Outbound = outbound;
        }
    }
}
