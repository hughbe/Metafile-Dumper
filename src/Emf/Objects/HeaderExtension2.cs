using System.Collections.Generic;

namespace MetafileDumper.Emf.Objects
{
    public class HeaderExtension2 : ObjectBase
    {
        public HeaderExtension2(MetafileReader reader) 
        {
            MicrometersX = reader.ReadUInt32();
            MicrometersY = reader.ReadUInt32();
        }

        public override uint Size => 8;

        public uint MicrometersX { get; }
        public uint MicrometersY { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("MicrometersX", 4);
            yield return new RecordValues("MicrometersY", 4);
        }
    }
}
