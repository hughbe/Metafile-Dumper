using System.Collections.Generic;
using System.Linq;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the end of EMF+ data in the metafile.
    /// [MS-EMFPLUS 2.3.3.1]
    /// </summary>
    public class EmfPlusEndOfFile : EmfPlusRecord
    {
        public EmfPlusEndOfFile(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusEndOfFile";

        protected override IEnumerable<RecordValues> GetValues()
        {
            return Enumerable.Empty<RecordValues>();
        }
    }
}
