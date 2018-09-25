using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies filling the interiors of a series of rectangles.
    /// [MS-EMFPLUS] 2.3.4.20
    /// </summary>
    public class EmfPlusFillRects : EmfPlusRecord
    {
        public EmfPlusFillRects(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
            Count = reader.ReadUInt32();
            Rectangles = Utilities.GetRects(reader, DataCompressed, Count);
        }

        public override string Name => "EmfPlusFillRects";

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
        /// A 32-bit unsigned integer that defines the brush, the content of which is
        /// determined by the S bit in the Flags field.
        /// </summary>
        public uint BrushIdOrColor { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of rectangles in the RectData
        /// field.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of either an EmfPlusRect or EmfPlusRectF objects of Count length
        /// that defines the rectangle data.
        /// </summary>
        public IEnumerable<EmfPlusRectBase> Rectangles { get; }

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

            yield return new RecordValues("Count",           4);

            int i = 0;
            foreach (EmfPlusRectBase rect in Rectangles)
            {
                foreach (RecordValues values in rect.GetValues())
                {
                    yield return new RecordValues(values.Name + (i + 1), values.Length);
                }

                i++;
            }
        }
    }
}
