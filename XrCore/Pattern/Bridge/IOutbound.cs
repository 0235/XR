using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Bridge
{
    public interface IOutbound
    {
        string CreateOutstoreTask(string sku, int qty,int locId);
    }
}
