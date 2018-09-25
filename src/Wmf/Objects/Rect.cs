using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines a rectangle.
    /// [MS-WMF] 2.2.2.18
    /// </summary>
    public class Rect : ObjectBase
    {
        public Rect(MetafileReader reader)
        {
            Left = reader.ReadInt16();
            Top = reader.ReadInt16();
            Right = reader.ReadInt16();
            Bottom = reader.ReadInt16();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 16-bit signed integer that defines the x coordinate, in logical
        /// coordinates, of the upper-left corner of the rectangle.
        /// </summary>
        public short Left { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the y coordinate, in logical
        /// coordinates, of the upper-left corner of the rectangle.
        /// </summary>
        public short Top { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the x coordinate, in logical
        /// coordinates, of the lower-right corner of the rectangle.
        /// </summary>
        public short Right { get; }

        /// <summary>
        /// A 16-bit signed integer that defines y coordinate, in logical
        /// coordinates, of the lower-right corner of the rectangle.
        /// </summary>
        public short Bottom { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Left",   2);
            yield return new RecordValues("Top",    2);
            yield return new RecordValues("Right",  2);
            yield return new RecordValues("Bottom", 2);
        }
    }
}
