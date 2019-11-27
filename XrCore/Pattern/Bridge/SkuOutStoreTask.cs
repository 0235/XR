using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Bridge
{
    public class SkuOutStoreTask : IOutbound
    {
        public string CreateOutstoreTask(string sku, int qty, int locId)
        {
            return $"create task:{sku}-{qty}";
        }
    }
}
