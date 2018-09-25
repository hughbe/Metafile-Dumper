using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrUnknownRecord : EmfRecord
    {
        public EmrUnknownRecord(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "Unknown Record";

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", Size - 8);
        }
    }
}
