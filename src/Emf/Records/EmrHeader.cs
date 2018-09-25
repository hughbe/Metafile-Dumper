using MetafileDumper.Emf.Objects;
using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrHeader : EmfRecord
    {
        public EmrHeader(MetafileReader reader) : base(reader)
        {
            Header = new Header(reader);
            if (Size >= 100)
            {
                HeaderExtension1 = new HeaderExtension1(reader);
            }
            if (Size >= 108)
            {
                HeaderExtension2 = new HeaderExtension2(reader);
            }
        }

        public override string Name => "EMR_HEADER";

        public Header Header { get; }
        public HeaderExtension1 HeaderExtension1 { get; }
        public HeaderExtension2 HeaderExtension2 { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Header.GetValues())
            {
                yield return values;
            }
            foreach (RecordValues values in HeaderExtension1.GetValues())
            {
                yield return values;
            }
            foreach (RecordValues values in HeaderExtension2.GetValues())
            {
                yield return values;
            }
        }
    }
}
