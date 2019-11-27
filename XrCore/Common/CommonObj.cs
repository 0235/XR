using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XrCore.SingleBase.Pattern;

namespace XrCore.Common
{
    /// <summary>
    /// 通用数据，todo：GC回收
    /// </summary>
    public class CommonObj : SingleBase<CommonObj>
    {
        private List<Assembly> assemblies;
        public List<Assembly> Assemblies
        {
            get
            {
                if (assemblies == null)
                {
                    assemblies = new List<Assembly>();
                    var dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
                    foreach (var dll in dlls)
                    {
                        assemblies.Add(Assembly.LoadFile(dll));
                    }
                }
                return assemblies;
            }
        }
    }
}
