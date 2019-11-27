using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Bridge
{
    public class TaskCreater : OutstoreTask
    {
        public string Station { get; set; }
        public TaskCreater(string station, IOutbound outbound) : base(outbound)
        {
            this.Station = station;
        }
        public string GetTask(string sku, int qty, int locId)
        {
            return Outbound.CreateOutstoreTask(sku, qty, locId);
        }
    }
}
