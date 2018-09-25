using System;

namespace MetafileDumper
{
    public class MetafileReader
    {
        public MetafileReader(byte[] buffer, int index)
        {
            Buffer = buffer;
            CurrentIndex = index;
        }

        public byte[] Buffer { get; }

        public int CurrentIndex { get; set; }

        public int ReadInt32()
        {
            int result = BitConverter.ToInt32(Buffer, CurrentIndex);
            CurrentIndex += 4;
            return result;
        }

        public int PeekInt32()
        {
            int result = BitConverter.ToInt32(Buffer, CurrentIndex);
            return result;
        }

        public uint ReadUInt32()
        {
            uint result = BitConverter.ToUInt32(Buffer, CurrentIndex);
            CurrentIndex += 4;
            return result;
        }

        public int PeekUInt32()
        {
            int result = BitConverter.ToInt32(Buffer, CurrentIndex);
            return result;
        }

        public short ReadInt16()
        {
            short result = BitConverter.ToInt16(Buffer, CurrentIndex);
            CurrentIndex += 2;
            return result;
        }

        public short PeekInt16()
        {
            short result = BitConverter.ToInt16(Buffer, CurrentIndex);
            return result;
        }

        public ushort ReadUInt16()
        {
            ushort result = BitConverter.ToUInt16(Buffer, CurrentIndex);
            CurrentIndex += 2;
            return result;
        }

        public byte ReadByte()
        {
            byte result = Buffer[CurrentIndex];
            CurrentIndex += 1;
            return result;
        }

        public float ReadSingle()
        {
            float result = BitConverter.ToSingle(Buffer, CurrentIndex);
            CurrentIndex += 4;
            return result;
        }

        public bool ReadBoolean()
        {
            bool result = BitConverter.ToBoolean(Buffer, CurrentIndex);
            CurrentIndex += 4;
            return result;
        }

        public Guid ReadGuid()
        {
            var result = new Guid(Buffer);
            CurrentIndex += 16;
            return result;
        }
    }
}
