using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the desired level of quality for creating composite images
    /// from multiple objects.
    /// [MS-EMFPLUS] 2.3.6.3
    /// </summary>
    public class EmfPlusSetCompositingQuality : EmfPlusRecord
    {
        public EmfPlusSetCompositingQuality(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetCompositingQuality";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |      CompositingQuality       |
        /// <summary>
        /// The compositing quality value, from the CompositingQuality enumeration.
        /// </summary>
        public CompositingQuality CompositingMode => (CompositingQuality)(Flags & 0b11111111);
    }
}
