namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of line caps to use at the ends of dashed lines that are
    /// drawn with graphics pens.
    /// [MS-EMFPLUS] section 2.1.1.10
    /// </summary>
    public enum DashedLineCapType
    {
        /// <summary>
        /// Specifies a flat dashed line cap.
        /// </summary>
        Flat = 0x00000000,

        /// <summary>
        /// Specifies a round dashed line cap.
        /// </summary>
        Round = 0x00000002,

        /// <summary>
        /// Specifies a triangular dashed line cap.
        /// </summary>
        Triangle = 0x00000003
    }
}
