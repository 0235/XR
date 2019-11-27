using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Template
{
    /// <summary>
    /// 本模式被ioc碾压
    /// </summary>
    public abstract class Game
    {
        public abstract void Initlize();
        public abstract void Gaming();
        public abstract void EndPlaying();
        public void Play()
        {
            Initlize();
            Gaming();
            EndPlaying();
        } 
    }
}
