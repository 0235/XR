using Houdar.Core.Components;
using Houdar.Core.Util.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdcPackage
{
    public interface INdcMessageHandler
    {
        void Handle(ByteBuffer buffer);
    }
    [RegisterToContainer(typeof(INdcMessageHandler), "cmdcode")]
    public class MessageHandler : INdcMessageHandler
    {
        public void Handle(ByteBuffer buffer)
        {

        }
    }
    public class PackageManager : SingleBase<PackageManager>
    {
        public ByteBuffer Buffer { get; private set; } = new ByteBuffer();

        public ByteBuffer AddNewPackage(byte[] package)
        {
            var bytes = Buffer.ToByteArray().ToList();
            bytes.AddRange(package);
            Buffer = new ByteBuffer(bytes.ToArray());
            return Buffer;
        }
        public void GetMessage()
        {
            while (Buffer.Length > 7)
            {
                var head = Buffer.GetUShort();
                if (head == 0x87cd)
                {
                    if (Buffer.Length > 5)
                    {
                        var frameLength = Buffer.GetUShort();
                        var dataLength = Buffer.GetUShort();
                        if (Buffer.Length >= (dataLength + 2))
                        {
                            var messageType = Buffer.GetUShort();
                            var data = Buffer.GetByteArray(dataLength);
                            var dataBuffer = new ByteBuffer(data);
                            var cmdCode = dataBuffer.GetUShort().ToString();
                            ObjectContainer.Resolve<INdcMessageHandler>(cmdCode).Handle(dataBuffer);
                        }
                        else
                        {
                            Buffer.PutUShort(0, dataLength);
                            Buffer.PutUShort(0, frameLength);
                            break;
                        }
                    }
                }
            }
        }
    }
}
