using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    public class EmfPlusUnknownRecord : EmfPlusRecord
    {
        public EmfPlusUnknownRecord(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "Unknown EMF+ Record";

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", Size - 12);
        }
    }
}
