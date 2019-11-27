using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Strategy
{
    public interface IOperation
    {
        int DoOperation(int num1, int num2);
    }
}
