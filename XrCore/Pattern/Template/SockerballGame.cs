using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Template
{
    public class SockerballGame : Game
    {
        public override void EndPlaying()
        {
            Console.WriteLine("throw a ball");
        }

        public override void Gaming()
        {
            Console.WriteLine("kick a bll");
        }

        public override void Initlize()
        {
            Console.WriteLine("take a ball");
        }
    }
}
