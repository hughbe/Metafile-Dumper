using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetafileDumper
{
    public abstract class Record
    {
        public Record(MetafileReader reader)
        {
            Reader = reader;
            StartIndex = reader.CurrentIndex;
        }

        public MetafileReader Reader { get; }
        public int StartIndex { get; }

        public abstract string Name { get; }
        public uint Size { get; protected set; }

        protected abstract IEnumerable<RecordValues> GetHeaderValues();
        protected virtual IEnumerable<RecordValues> GetValues()
        {
            return Enumerable.Empty<RecordValues>();
        }

        private void WriteHeaderValues(StringBuilder builder, IList<RecordValues> values)
        {
            builder.AppendLine("/* -- " + Name + " -- */");

            int maxNameLength = values.Where(p => p.Name != null).Max(p => p.Name.Length);

            uint currentIndex = (uint)StartIndex;
            for (int i = 0; i < values.Count; i++)
            {
                values[i].Serialize(builder, maxNameLength, Reader.Buffer, currentIndex);
                currentIndex += values[i].Length;
            }

            if (Name != "EMR_COMMENT_EMFPLUS" && currentIndex != StartIndex + Size)
            {
                throw new System.InvalidOperationException("Did not write everything.");
            }
        }

        public virtual void WriteTo(StringBuilder builder)
        {
            IEnumerable<RecordValues> headerValues = GetHeaderValues();
            IEnumerable<RecordValues> recordValues = GetValues();
            if (recordValues == null)
            {
                return;
            }

            List<RecordValues> values = headerValues.Concat(recordValues).ToList();
            WriteHeaderValues(builder, values);
        }

        public override string ToString() => Name;
    }
}
