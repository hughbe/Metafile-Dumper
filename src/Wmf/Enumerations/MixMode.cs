namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Specifies the background mix mode for text, hatched brushes, and other nonsolid
    /// pen styles.
    /// [MS-WMF] 2.1.1.20
    /// </summary>
    public enum MixMode
    {
        /// <summary>
        /// The background remains untouched.
        /// </summary>
        TRANSPARENT = 0x0001,

        /// <summary>
        /// The background is filled with the background color that is currently defined
        /// in the playback device context before the text, hatched brush, or pen
        /// is drawn.
        /// </summary>
        OPAQUE = 0x0002
    }
}
