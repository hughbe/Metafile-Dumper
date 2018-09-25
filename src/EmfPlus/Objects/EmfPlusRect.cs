using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a rectangle origin, height, and width as 16-bit signed integers.
    /// [MS-EMFPLUS] 2.2.2.38
    /// </summary>
    public class EmfPlusRect : EmfPlusRectBase
    {
        public EmfPlusRect(MetafileReader reader)
        {
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
            Width = reader.ReadInt16();
            Height = reader.ReadInt16();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 16-bit signed integer that specifies the horizontal coordinate of the
        /// upper-left corner of the rectangle.
        /// </summary>
        public short X { get; }

        /// <summary>
        /// A 16-bit signed integer that specifies the vertical coordinate of the
        /// upper-left corner of the rectangle.
        /// </summary>
        public short Y { get; }

        /// <summary>
        /// A 16-bit signed integer that specifies the width of the rectangle.
        /// </summary>
        public short Width { get; }

        /// <summary>
        /// A 16-bit signed integer that specifies the height of the rectangle.
        /// </summary>
        public short Height { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X",      2);
            yield return new RecordValues("Y",      2);
            yield return new RecordValues("Width",  2);
            yield return new RecordValues("Height", 2);
        }
    }
}
