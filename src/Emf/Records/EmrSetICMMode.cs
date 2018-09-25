using MetafileDumper.EMFRecords.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrSetICMMode : EmfRecord
    {
        public EmrSetICMMode(MetafileReader reader) : base(reader)
        {
            Mode = (ICMMode)reader.ReadUInt32();
        }

        public override string Name => "EMR_SETICMMODE";

        public ICMMode Mode { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Mode", 4);
        }
    }
}
