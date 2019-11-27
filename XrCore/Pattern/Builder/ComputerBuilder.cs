using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Builder
{
    public class ComputerBuilder
    {
        public string CPU { get; private set; }
        public string GPU { get; private set; }
        public string MainBord { get; private set; }
        public string Box { get; private set; }
        public ComputerBuilder BuildCPU(string cpu)
        {
            this.CPU = cpu;
            return this;
        }
        public ComputerBuilder BuildGPU(string gpu)
        {
            this.GPU = gpu;
            return this;
        }
        public ComputerBuilder BuildMainBord(string mainBord)
        {
            this.MainBord = mainBord;
            return this;
        }
        public ComputerBuilder BuildBox(string box)
        {
            this.Box = box;
            return this;
        }
        public ComputerBuilder BuildAll()
        {
            return BuildCPU("Default CPU").BuildGPU("Default GPU").BuildMainBord("Default MainBox").BuildBox("Default Box");
        }
    }
}
