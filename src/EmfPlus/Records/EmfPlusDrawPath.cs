using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a graphics path.
    /// [MS-EMFPLUS] 2.3.4.11
    /// </summary>
    public class EmfPlusDrawPath : EmfPlusRecord
    {
        public EmfPlusDrawPath(MetafileReader reader) : base(reader)
        {
            PenId = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusDrawPath";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// The index of the EmfPlusPath object to draw, in the EMF+ Object Table.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PathId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that specifies an index in the EMF+ Object Table for an
        /// EmfPlusPen object to use for drawing the EmfPlusPath.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Pen Id", 4);
        }
    }
}
