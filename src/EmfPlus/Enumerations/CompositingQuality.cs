namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines levels of quality for creating composite images.
    /// [MS-EMFPLUS] section 2.1.1.6
    /// </summary>
    public enum CompositingQuality
    {
        /// <summary>
        /// No gamma correction is performed. Gamma correction controls the overall brightness
        /// and contrast of an image. Without gamma correction, composited images can appear
        /// too light or too dark.
        /// </summary>
        Default = 0x01,

        /// <summary>
        /// No gamma correction is performed. Compositing speed is favored at the expense of
        /// quality. In terms of the result, there is no difference between this value and
        /// CompositingQualityDefault.
        /// </summary>
        HighSpeed = 0x02,

        /// <summary>
        /// Gamma correction is performed. Compositing quality is favored at the expense of
        /// speed.
        /// </summary>
        HighQuality = 0x03,

        /// <summary>
        /// Enable gamma correction for higher-quality compositing with lower speed.
        /// In terms of the result, there is no difference between this value and
        /// CompositingQualityHighQuality.
        /// </summary>
        GammaCorrected = 0x04,

        /// <summary>
        /// No gamma correction is performed; however, using linear values results in
        /// better quality than the default at a slightly lower speed.
        /// </summary>
        AssumeLinear = 0x05
    }
}
