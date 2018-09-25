using System.Text;

namespace MetafileDumper
{
    public class RecordValues
    {
        public string Name { get; set; }
        public uint Length { get; set; }

        public RecordValues(string name, uint length)
        {
            Name = name;
            Length = length;
        }

        public virtual void Serialize(StringBuilder builder, int padRight, byte[] buffer, uint currentIndex)
        {
            builder.Append("/* " + Name + " */");
            for (int j = 0; j < padRight - Name.Length; j++)
            {
                builder.Append(' ');
            }

            builder.Append(' ');
            Utilities.JoinByteArray(builder, buffer, currentIndex, Length);
        }
    }
}
