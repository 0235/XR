using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using XrCore.Extends;

namespace XrCore.Sockets
{
    public class SocketServer
    {
        public Socket Server { get; }
        public Dictionary<string, Socket> DicClient = new Dictionary<string, Socket>();
        public event Action<Socket, byte[]> DataReceive;
        public SocketServer()
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111));
            Server.Listen(10);
            var task = new Task(() =>
            {
                try
                {
                    while (true)
                    {
                        var client = Server.Accept();
                        var ip = ((IPEndPoint)client.RemoteEndPoint).ToString();
                        if (!DicClient.Keys.Contains(ip))
                        {
                            DicClient.Add(ip, client);
                        }
                        else
                        {
                            DicClient[ip].TryDispose();
                            DicClient[ip] = client;
                        }
                        var t = new Task(() =>
                         {
                             try
                             {
                                 var data = new byte[65535];
                                 var length = client.Receive(data);
                                 data = data.Take(length).ToArray();
                                 DataReceive?.Invoke(client, data);
                             }
                             catch(Exception ex)
                             {

                             }
                         });
                        t.Start();
                    }
                }
                catch (Exception ex)
                {

                }
            });
            task.Start();
        }
    }
}
