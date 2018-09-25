using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrRestoreDC : EmfRecord
    {
        public EmrRestoreDC(MetafileReader reader) : base(reader)
        {
            SavedDC = reader.ReadInt32();
        }

        public override string Name => "EMR_RESTOREDC";

        public int SavedDC { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Saved DC", 4);
        }
    }
}
