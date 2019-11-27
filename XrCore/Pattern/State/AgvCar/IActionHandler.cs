using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.AgvCar
{
    public interface IActionHandler
    {
        void StartLoad();
        void FinishLoad();
        void StartUnload();
        void FinishUnload();
    }
}
