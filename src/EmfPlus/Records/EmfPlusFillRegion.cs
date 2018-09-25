using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies filling the interior of a graphics region.
    /// [MS-EMFPLUS] 2.3.4.21
    /// </summary>
    public class EmfPlusFillRegion : EmfPlusRecord
    {
        public EmfPlusFillRegion(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusFillRegion";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // S | X | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, BrushId specifies a color as an EmfPlusARGB object.
        /// If clear, BrushId contains the index of an EmfPlusBrush object in the EMF+ Object Table.
        /// </summary>
        public bool BrushIdFieldIsColor => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// The index of the EmfPlusRegion object to fill, in the EMF+ Object Table.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint RegionId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that defines the brush, the content of which is
        /// determined by the S bit in the Flags field.
        /// </summary>
        public uint BrushIdOrColor { get; }

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
        }
    }
}
