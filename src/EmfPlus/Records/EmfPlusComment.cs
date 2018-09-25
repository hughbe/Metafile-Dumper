using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies arbitrary private data. 
    /// [MS-EMFPLUS] 2.3.2.1
    /// </summary>
    public class EmfPlusComment : EmfPlusRecord
    {
        public EmfPlusComment(MetafileReader reader) : base(reader)
        {
            PrivateData = Utilities.ReadBytes(reader, DataSize);
        }

        public override string Name => "EmfPlusComment";

        /// <summary>
        /// A DataSize-length byte array of private data.
        /// </summary>
        public IEnumerable<byte> PrivateData { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", DataSize);   
        }
    }
}
