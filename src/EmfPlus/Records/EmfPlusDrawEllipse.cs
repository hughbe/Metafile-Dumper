using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing an ellipse
    /// [MS-EMFPLUS] 2.3.4.7
    /// </summary>
    public class EmfPlusDrawEllipse : EmfPlusRecord
    {
        public EmfPlusDrawEllipse(MetafileReader reader) : base(reader)
        {
            Rectangle = Utilities.GetRect(reader, DataCompressed);
        }

        public override string Name => "EmfPlusDrawEllipse";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, RectData contains an EmfPlusRect object.
        /// If clear, RectData contains an EmfPlusRectF object.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusPen object in the EMF+ Object Table to draw the
        /// ellipse.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// Either an EmfPlusRect or EmfPlusRectF object that defines the bounding box of
        /// the ellipse.
        /// </summary>
        public EmfPlusRectBase Rectangle { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Rectangle.GetValues())
            {
                yield return values;
            }
        }
    }
}
