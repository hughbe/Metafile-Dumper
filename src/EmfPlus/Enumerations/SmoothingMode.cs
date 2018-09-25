namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of smoothing to apply to lines, curves and the edges of filled
    /// areas to make them appear more continuous or sharply defined.
    /// [MS-EMFPLUS] section 2.1.1.28
    /// </summary>
    public enum SmoothingMode
    {
        /// <summary>
        /// Default curve smoothing with no anti-aliasing.
        /// </summary>
        Default = 0x00,

        /// <summary>
        /// Best performance with no anti-aliasing.
        /// </summary>
        HighSpeed = 0x01,

        /// <summary>
        /// Best quality with anti-aliasing.
        /// </summary>
        HighQuality = 0x02,

        /// <summary>
        /// No curve smoothing and no anti-aliasing.
        /// </summary>
        None = 0x03,

        /// <summary>
        /// Anti-aliasing using an 8x4 box filter.
        /// </summary>
        AntiAlias8x4 = 0x04,

        /// <summary>
        /// Anti-aliasing using an 8x8 box filter.
        /// </summary>
        AntiAlias8x8 = 0x05
    }
}
