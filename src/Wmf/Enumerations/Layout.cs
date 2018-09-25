namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Defines options for controlling the direction in which text and graphics are
    /// drawn.
    /// [MS-WMF] 2.1.1.13
    /// </summary>
    public enum Layout
    {
        /// <summary>
        /// Sets the default horizontal layout to be left-to-right.
        /// </summary>
        LAYOUT_LTR = 0x0000,

        /// <summary>
        /// Sets the default horizontal layout to be right-to-left.
        /// Switching to this layout SHOULD cause the mapping mode in the playback device
        /// context to become MM_ISOTROPIC (section 2.1.1.16).
        /// </summary>
        LAYOUT_RTL = 0x0001,

        /// <summary>
        /// Disables mirroring of bitmaps that are drawn by META_BITBLT Record
        /// (section 2.3.1.1) and META_STRETCHBLT Record (section 2.3.1.5) operations,
        /// when the layout is right-to-left.
        /// </summary>
        LAYOUT_BITMAPORIENTATIONPRESERVED = 0x0008
    }
}
