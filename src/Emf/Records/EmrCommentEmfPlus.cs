using System.Collections.Generic;
using System.Text;

namespace MetafileDumper.Emf.Records
{
    public class EmrCommentEmfPlus : EmfRecord
    {
        public EmrCommentEmfPlus(MetafileReader reader) : base(reader)
        {
            DataSize = reader.ReadUInt32(); ;
            Signature = reader.ReadUInt32();

            var records = new List<EmfPlusRecord>();
            uint currentIndex = (uint)reader.CurrentIndex;
            uint endIndex = currentIndex + DataSize - 4;
            while (currentIndex < endIndex)
            {
                var record = EmfPlusRecord.GetRecord(reader);
                records.Add(record);
                currentIndex += record.Size;

                if (reader.CurrentIndex != currentIndex)
                {
                    reader.CurrentIndex = (int)currentIndex;
                    throw new System.InvalidOperationException("Reader is out of sync with the size.");
                }
            }
            Records = records;
        }

        public uint DataSize { get; }
        public uint Signature { get; }

        public IEnumerable<EmfPlusRecord> Records { get; }

        public override string Name => "EMR_COMMENT_EMFPLUS";

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data Size", 4);
            yield return new RecordValues("Signature", 4);
        }

        public override void WriteTo(StringBuilder builder)
        {
            base.WriteTo(builder);
    
            foreach (EmfPlusRecord record in Records)
            {
                builder.AppendLine();
                record.WriteTo(builder);
            }
        }
    }
}
