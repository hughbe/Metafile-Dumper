using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies scaling factors and units for converting page space coordinates
    /// to device space coordinates.
    /// [MS-EMFPLUS] 2.3.9.5
    /// </summary>
    public class EmfPlusSetPageTransform : EmfPlusRecord
    {
        public EmfPlusSetPageTransform(MetafileReader reader) : base(reader)
        {
            PageScale = reader.ReadSingle();
        }

        public override string Name => "EmfPlusSetPageTransform";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |           Page Unit           |
        /// <summary>
        /// The unit of measure for page space coordinates, from the UnitType enumeration.
        /// This value SHOULD NOT be UnitTypeDisplay or UnitTypeWorld.
        /// </summary>
        public UnitType PageUnit => (UnitType)(Flags & 0b11111111);

        /// <summary>
        /// A 32-bit floating-point value that specifies the scale factor for converting page
        /// space coordinates to device space coordinates.
        /// </summary>
        public float PageScale { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Page Scale", 4);
        }
    }
}
