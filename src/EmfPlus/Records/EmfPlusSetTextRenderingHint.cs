using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the quality of text rendering, including the type of anti-aliasing.
    /// [MS-EMFPLUS] 2.3.6.8
    /// </summary>
    public class EmfPlusSetTextRenderingHint : EmfPlusRecord
    {
        public EmfPlusSetTextRenderingHint(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetTextRenderingHint";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |       TextRenderingHint       |
        /// <summary>
        /// The text rendering hint value, from the TextRenderingHint enumeration,
        /// which specifies the quality to use in subsequent text rendering.
        /// </summary>
        public TextRenderingHint TextRenderingHint => (TextRenderingHint)(Flags & 0b11111111);
    }
}
