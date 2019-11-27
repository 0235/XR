using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Mediator
{
    public class ChatRoom
    {
        List<Chater> Chaters = new List<Chater>();

        public void AddChater(Chater chater)
        {
            this.Chaters.Add(chater);
        }

        public void SendMsg(string msg)
        {
            foreach(var chater in Chaters)
            {
                chater.ReceiveMessage(msg);
            }
        }
    }
}
