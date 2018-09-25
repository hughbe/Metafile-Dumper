namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines modes for combining source colors with background colors.
    /// The compositing mode represents the enable state of alpha blending.
    /// [MS-EMFPLUS] section 2.1.1.5
    /// </summary>
    public enum CompositingMode
    {
        /// <summary>
        /// Enables alpha blending, which specifies that when a color is renderered, it
        /// is blended with the background color. The extent of blending is determined
        /// by the value of the alpha component of the color being rendered.
        /// </summary>
        SourceOver = 0x00,

        /// <summary>
        /// Disables alpha blending, which means that when a source color is rendered, it
        /// overwrites the background color.
        /// </summary>
        SourceCopy = 0x01
    }
}
