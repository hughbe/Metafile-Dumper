using System;
using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrEOF : EmfRecord
    {
        public EmrEOF(MetafileReader reader) : base(reader)
        {
            PaletteEntriesCount = reader.ReadUInt32();
            PaletteEntriesOffset = reader.ReadUInt32();

            if (PaletteEntriesCount != 0)
            {
                throw new InvalidOperationException("Don't know how to handle non-zer palette entries in EMR_EOF.");
            }

            SizeLast = reader.ReadUInt32();
        }

        public override string Name => "EMR_EOF";

        public uint PaletteEntriesCount { get; }
        public uint PaletteEntriesOffset { get; }
        public uint SizeLast { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("nPalEntries",   4);
            yield return new RecordValues("offPalEntries", 4);
            yield return new RecordValues("SizeLast",      4);
        }
    }
}
