using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Mediator
{
    public class Chater
    {
        public ChatRoom ChatRoom;
        public Chater(string id)
        {

        }

        public void GetIntoRoom(ChatRoom room)
        {
            this.ChatRoom = room;
            room.AddChater(this);
        }

        public void SendMessage(string msg)
        {
            ChatRoom.SendMsg(msg);
        }
        public void ReceiveMessage(string msg)
        {

        }
    }
}
