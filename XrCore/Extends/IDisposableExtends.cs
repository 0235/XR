using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Extends
{
    public static class IDisposableExtends
    {
        public static void TryDispose(this IDisposable obj)
        {
            try
            {
                obj.Dispose();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
