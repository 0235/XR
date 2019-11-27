using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Bridge
{
    public class BridgeDemo
    {
        public void UseIt()
        {
            var taskC = new TaskCreater("", new SkuOutStoreTask());
            taskC.GetTask("sku", 1, 1);
            var taskC2 = new TaskCreater("", new LocOutstore());
            taskC2.GetTask("sku", 1, 1);
        }
    }
}
