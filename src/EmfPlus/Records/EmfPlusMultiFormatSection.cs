using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    public class EmfPlusMultiFormatStart : EmfPlusRecord
    {
        public EmfPlusMultiFormatStart(MetafileReader reader) : base(reader)
        {
            MaybeSectionSize = reader.ReadInt32();
            Version = reader.ReadInt32();
        }

        public override string Name => "EmfPlusMultiFormatStart";

        public int MaybeSectionSize { get; }

        public int Version { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("MaybeSectionSize", 4);
            yield return new RecordValues("Version",          4);

            if (DataSize - 8 > 0)
            {
                yield return new RecordValues("Data",         DataSize - 8);
            }
        }
    }
}
