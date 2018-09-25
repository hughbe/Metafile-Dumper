using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a custom line cap for the end of a line.
    /// [MS-EMFPLUS] 2.2.2.11
    /// </summary>
    public class EmfPlusCustomEndCapData : ObjectBase
    {
        public EmfPlusCustomEndCapData(MetafileReader reader)
        {
            DataSize = reader.ReadUInt32();
            Data = new EmfPlusCustomLineCap(reader, DataSize);
        }

        public override uint Size => 4 + DataSize;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the size in bytes of the
        /// CustomEndCap field.
        /// </summary>
        public uint DataSize { get; }

        /// <summary>
        /// A custom line cap that defines the shape to draw at the end of a line. It
        /// can be any of various shapes, including a square, circle, or diamond.
        /// </summary>
        public EmfPlusCustomLineCap Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Size", 4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
