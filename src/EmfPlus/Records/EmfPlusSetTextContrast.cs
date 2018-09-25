namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies text contrast according to the gamma correction value.
    /// [MS-EMFPLUS] 2.3.6.7
    /// </summary>
    public class EmfPlusSetTextContrast : EmfPlusRecord
    {
        public EmfPlusSetTextContrast(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusSetTextContrast";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X |                 Text Contrast                 |
        /// <summary>
        /// The gamma correction value X 1000, which will be applied to subsequent
        /// text rendering operations.
        /// The allowable range is 1000 to 2200, representing text gamma values of
        /// 1.0 to 2.2.
        /// </summary>
        public uint TextContrast => (uint)(Flags & 0b111111111111);
    }
}
