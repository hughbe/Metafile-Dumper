using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies how pixels are centered with respect to the coordinates of the
    /// drawing surface.
    /// [MS-EMFPLUS] 2.3.6.5
    /// </summary>
    public class EmfPlusSetPixelOffsetMode : EmfPlusRecord
    {
        public EmfPlusSetPixelOffsetMode(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetPixelOffsetMode";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |        PixelOffsetMode        |
        /// <summary>
        /// The pixel offset mode value, from the PixelOffsetMode enumeration.
        /// </summary>
        public PixelOffsetMode PixelOffsetMode => (PixelOffsetMode)(Flags & 0b11111111);
    }
}
