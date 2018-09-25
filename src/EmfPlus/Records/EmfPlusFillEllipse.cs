using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies filling the interior of an ellipse.
    /// [MS-EMFPLUS] 2.3.4.16
    /// </summary>
    public class EmfPlusFillEllipse : EmfPlusRecord
    {
        public EmfPlusFillEllipse(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
            Rectangle = Utilities.GetRect(reader, DataCompressed);
        }

        public override string Name => "EmfPlusFillEllipse";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // S | C | X | X | X | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, BrushId specifies a color as an EmfPlusARGB object.
        /// If clear, BrushId contains the index of an EmfPlusBrush object in the
        /// EMF+ Object Table.
        /// </summary>
        public bool BrushIdFieldIsColor => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// If set, RectData contains an EmfPlusRect object.
        /// If clear, RectData contains an EmfPlusRectF object.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the brush, the content of which is
        /// determined by the S bit in the Flags field.
        /// This definition is used to fill the interior of the ellipse.
        /// </summary>
        public uint BrushIdOrColor { get; }

        /// <summary>
        /// Either an EmfPlusRect or EmfPlusRectF object that defines the bounding box of
        /// the ellipse.
        /// </summary>
        public EmfPlusRectBase Rectangle { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            if (BrushIdFieldIsColor)
            {
                yield return new RecordValues("Brush Color", 4);
            }
            else
            {
                yield return new RecordValues("Brush ID",    4);
            }

            foreach (RecordValues values in Rectangle.GetValues())
            {
                yield return values;
            }
        }
    }
}
