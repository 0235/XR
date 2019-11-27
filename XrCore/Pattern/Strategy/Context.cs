using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Strategy
{
    /// <summary>
    /// 本模式被ioc完美碾压
    /// </summary>
    public class Context
    {
        private IOperation Operation;
        public Context(IOperation operation)
        {
            this.Operation = operation;
        }
        public int ExecuteOperation(int a,int b)
        {
            return Operation.DoOperation(a, b);
        }
    }
}
