using System.Collections.Generic;

namespace MetafileDumper.Emf.Objects
{
    public class HeaderExtension1 : ObjectBase
    {
        public HeaderExtension1(MetafileReader reader) 
        {
            PixelFormatLength = reader.ReadUInt32();
            PixelFormatOffset = reader.ReadUInt32();
            HasOpenGLCommands = reader.ReadBoolean();
        }

        public override uint Size => 12;

        public uint PixelFormatLength { get; }
        public uint PixelFormatOffset { get; }
        public bool HasOpenGLCommands { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("cbPixelFormat",  4);
            yield return new RecordValues("offPixelFormat", 4);
            yield return new RecordValues("bOpenGL",        4);
        }
    }
}
