namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Defines line-joining capabilities for use with a PostScript printer driver.
    /// [MS-WMF] 2.1.1.29
    /// </summary>
    public enum PostScriptJoin
    {
        /// <summary>
        /// Specifies that the line-joining style has not been set and that a default style
        /// can be used.
        /// </summary>
        PostScriptNotSet = -2,

        /// <summary>
        /// Specifies a mitered join, which produces a sharp or clipped corner.
        /// </summary>
        PostScriptMiterJoin = 0,

        /// <summary>
        /// Specifies a circular join, which produces a smooth, circular arc between the
        /// lines.
        /// </summary>
        PostScriptRoundJoin = 1,

        /// <summary>
        /// Specifies a beveled join, which produces a diagonal corner.
        /// </summary>
        PostScriptBevelJoin = 2
    }
}
