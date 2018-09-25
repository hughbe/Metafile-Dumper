using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a series of rectangles.
    /// [MS-EMFPLUS] 2.3.4.13
    /// </summary>
    public class EmfPlusDrawRects : EmfPlusRecord
    {
        public EmfPlusDrawRects(MetafileReader reader) : base(reader)
        {
            Count = reader.ReadUInt32();
            Rectangles = Utilities.GetRects(reader, DataCompressed, Count);
        }

        public override string Name => "EmfPlusDrawRects";

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
        /// rectangles.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of rectangles in the RectData
        /// member.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of either an EmfPlusRect or EmfPlusRectF objects of Count length
        /// that defines the rectangle data.
        /// </summary>
        public IEnumerable<EmfPlusRectBase> Rectangles { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
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
