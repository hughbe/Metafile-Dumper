namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of text hinting and anti-aliasing, which affects the quality
    /// of text rendering.
    /// [MS-EMFPLUS] section 2.1.1.32
    /// </summary>
    public enum TextRenderingHint
    {
        /// <summary>
        /// pecifies that each text character SHOULD be drawn using whatever font-smoothing
        /// settings have been configured on the operating system.
        /// </summary>
        SystemDefault = 0x00,

        /// <summary>
        /// Specifies that each text character SHOULD be drawn using its glyph bitmap.
        /// Smoothing MAY be used to improve the appearance of character glyph
        /// stems and curvature.
        /// </summary>
        SingleBitPerPixelGridFit = 0x01,

        /// <summary>
        /// Specifies that each text character SHOULD be drawn using its glyph bitmap.
        /// Smoothing is not used.
        /// </summary>
        SingleBitPerPixel = 0x02,

        /// <summary>
        /// Specifies that each text character SHOULD be drawn using its anti-aliased
        /// glyph bitmap with smoothing. The rendering is high quality because of
        /// anti-aliasing, but at a higher performance cost.
        /// </summary>
        AntialiasGridFit = 0x03,

        /// <summary>
        /// Specifies that each text character is drawn using its anti-aliased glyph
        /// bitmap without hinting. Better quality results from anti-aliasing, but
        /// stem width differences MAY be noticeable because hinting is turned off.
        /// </summary>
        Antialias = 0x04,

        /// <summary>
        /// Specifies that each text character SHOULD be drawn using its ClearType
        /// glyph bitmap with smoothing. This is the highest-quality text hinting
        /// setting, which is used to take advantage of ClearType font features.
        /// </summary>
        ClearTypeGridFit = 0x05
    }
}
