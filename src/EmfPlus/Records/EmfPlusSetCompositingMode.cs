using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies how source colors are combined with background colors.
    /// [MS-EMFPLUS] 2.3.6.2
    /// </summary>
    public class EmfPlusSetCompositingMode : EmfPlusRecord
    {
        public EmfPlusSetCompositingMode(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetCompositingMode";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X |        CompositingMode        |
        /// <summary>
        /// The compositing mode value, from the CompositingMode enumeration.
        /// Compositing can be expressed as the state of alpha blending, which can
        /// either be on or off.
        /// </summary>
        public CompositingMode CompositingMode => (CompositingMode)(Flags & 0b11111111);
    }
}
