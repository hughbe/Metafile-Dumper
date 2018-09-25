using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines a rectangle.
    /// [MS-WMF] 2.2.2.19
    /// </summary>
    public class RectL : ObjectBase
    {
        public RectL(MetafileReader reader)
        {
            Left = reader.ReadInt32();
            Top = reader.ReadInt32();
            Right = reader.ReadInt32();
            Bottom = reader.ReadInt32();
        }

        public override uint Size => 16;

        /// <summary>
        /// A 32-bit signed integer that defines the x coordinate, in logical
        /// coordinates, of the upper-left corner of the rectangle.
        /// </summary>
        public int Left { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the y coordinate, in logical
        /// coordinates, of the upper-left corner of the rectangle.
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the x coordinate, in logical
        /// coordinates, of the lower-right corner of the rectangle.
        /// </summary>
        public int Right { get; }

        /// <summary>
        /// A 32-bit signed integer that defines y coordinate, in logical
        /// coordinates, of the lower-right corner of the rectangle.
        /// </summary>
        public int Bottom { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Left", 4);
            yield return new RecordValues("Top", 4);
            yield return new RecordValues("Right", 4);
            yield return new RecordValues("Bottom", 4);
        }
    }
}
