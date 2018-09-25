using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a rectangle origin, height, and width as 32-bit floating-point values.
    /// [MS-EMFPLUS] 2.2.2.39
    /// </summary>
    public class EmfPlusRectF : EmfPlusRectBase
    {
        public EmfPlusRectF(MetafileReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Width = reader.ReadSingle();
            Height = reader.ReadSingle();
        }

        public override uint Size => 16;

        /// <summary>
        /// A 32-bit floating-point value that specifies the horizontal coordinate of the
        /// upper-left corner of the rectangle.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the vertical coordinate of the
        /// upper-left corner of the rectangle.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the width of the rectangle.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the height of the rectangle.
        /// </summary>
        public float Height { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X",      4);
            yield return new RecordValues("Y",      4);
            yield return new RecordValues("Width",  4);
            yield return new RecordValues("Height", 4);
        }
    }
}
