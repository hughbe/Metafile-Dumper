using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies how image scaling, including stretching and shrinking, is performed.
    /// [MS-EMFPLUS] 2.3.6.4
    /// </summary>
    public class EmfPlusSetInterpolationMode : EmfPlusRecord
    {
        public EmfPlusSetInterpolationMode(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetInterpolationMode";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |       InterpolationMode       |
        /// <summary>
        /// The interpolation mode value, from the InterpolationMode enumeration.
        /// </summary>
        public InterpolationMode InterpolationMode => (InterpolationMode)(Flags & 0b11111111);
    }
}
