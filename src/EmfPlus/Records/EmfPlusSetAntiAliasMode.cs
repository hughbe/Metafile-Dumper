using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the anti-aliasing mode for text output.
    /// [MS-EMFPLUS] 2.3.6.1
    /// </summary>
    public class EmfPlusSetAntiAliasMode : EmfPlusRecord
    {
        public EmfPlusSetAntiAliasMode(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetAntiAliasMode";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X |       SmoothingMode       | A |
        /// <summary>
        /// The smoothing mode value, from the SmoothingMode enumeration.
        /// </summary>
        public SmoothingMode SmoothingMode => (SmoothingMode)((Flags >> 1) & 0b1111111);

        /// <summary>
        /// If set, anti-aliasing SHOULD be performed.
        /// If clear, anti-aliasing SHOULD NOT be performed.
        /// </summary>
        public bool PerformAntiAliasing => (Flags & 0b1) != 0;
    }
}
