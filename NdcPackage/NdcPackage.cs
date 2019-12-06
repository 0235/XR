using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NdcPackage
{
    public enum NdcMessageType
    {
        a = 0x0001,
        b = 0x0002,
        c = 0x0003,
        d = 0x0004,
        e = 0x0005,
    }
    public class NdcPackage
    {
        public ushort FrameHead { get; private set; }
        public ushort FrameHeadLength { get; private set; }
        public ushort DataLength { get; private set; }
        public NdcMessageType FuncCode { get; private set; }
        public byte[] Data { get; private set; }
        public void GetHead(ByteBuffer buffer)
        {
            FrameHead = buffer.GetUShort();
            FrameHeadLength = buffer.GetUShort();
            DataLength = buffer.GetUShort();
            FuncCode = (NdcMessageType)buffer.GetUShort();
        }

        public NdcPackage(ByteBuffer buffer)
        {
        }
    }
}
