using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a custom line cap for the start of a line.
    /// [MS-EMFPLUS] 2.2.2.15
    /// </summary>
    public class EmfPlusCustomStartCapData : ObjectBase
    {
        public EmfPlusCustomStartCapData(MetafileReader reader)
        {
            DataSize = reader.ReadUInt32();
            Data = new EmfPlusCustomLineCap(reader, DataSize);
        }

        public override uint Size => 4 + DataSize;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the size in bytes of the
        /// CustomStartCap field.
        /// </summary>
        public uint DataSize { get; }

        /// <summary>
        /// A custom graphics line cap that defines the shape to draw at the start
        /// of a line.
        /// It can be any of various shapes, including a square, circle or diamond.
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
