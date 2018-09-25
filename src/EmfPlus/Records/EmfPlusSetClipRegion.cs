using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Combines the current clipping region with another graphics region.
    /// [MS-EMFPLUS] 2.3.1.5
    /// </summary>
    public class EmfPlusSetClipRegion : EmfPlusRecord
    {
        public EmfPlusSetClipRegion(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetClipRegion";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X |     CM        |           Object Id           |
        /// <summary>
        /// Specifies the logical operation for combining two regions. See the CombineMode
        /// enumeration for the meanings of the values.
        /// </summary>
        public CombineMode CombineMode => (CombineMode)((Flags >> 8) & 0b1111);

        /// <summary>
        /// The index of an EmfPlusRegion object in the EMF+ Object Table.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint RegionId => Flags & 0b11111111u;
    }
}
