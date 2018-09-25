using MetafileDumper.Wmf.Data;
using System.Collections.Generic;

namespace MetafileDumper.Emf.Objects
{
    public class Header : ObjectBase
    {
        public Header(MetafileReader reader) 
        {
            Bounds = new RectL(reader);
            Frame = new RectL(reader);
            Signature = reader.ReadUInt32();
            Version = reader.ReadUInt32();
            NumberOfBytes = reader.ReadUInt32();
            NumberOfRecords = reader.ReadUInt32();
            NumberOfObjects = reader.ReadUInt16();
            Reserved = reader.ReadUInt16();
            DescriptionLength = reader.ReadUInt32();
            DescriptionOffset = reader.ReadUInt32();
            NumberOfPaletteEntries = reader.ReadUInt32();
            ReferenceDeviceSizePixels = new SizeL(reader);
            ReferenceDeviceSizeMillimeters = new SizeL(reader);
        }

        public override uint Size => 80;

        public RectL Bounds { get; }
        public RectL Frame { get; }

        public uint Signature { get; }
        public uint Version { get; }

        public uint NumberOfBytes { get; }
        public uint NumberOfRecords { get; }
        public ushort NumberOfObjects { get; }

        public ushort Reserved { get; }

        public uint DescriptionLength { get; }
        public uint DescriptionOffset { get; }

        public uint NumberOfPaletteEntries { get; }

        public SizeL ReferenceDeviceSizePixels { get; }
        public SizeL ReferenceDeviceSizeMillimeters { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Bounds",         16);
            yield return new RecordValues("Frame",          16);
            yield return new RecordValues("Signature",      4);
            yield return new RecordValues("Version",        4);
            yield return new RecordValues("Bytes",          4);
            yield return new RecordValues("Records",        4);
            yield return new RecordValues("Handles",        2);
            yield return new RecordValues("Reserved",       2);
            yield return new RecordValues("nDescription",   4);
            yield return new RecordValues("offDescription", 4);
            yield return new RecordValues("palEntries",     4);
            yield return new RecordValues("Device",         8);
            yield return new RecordValues("Millimetres",    8);
        }
    }
}
