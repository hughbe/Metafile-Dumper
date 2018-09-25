namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of graphics brushes, which are used to fill graphics regions.
    /// [MS-EMFPLUS] section 2.1.1.3
    /// </summary>
    public enum BrushType
    {
        /// <summary>
        /// Specifies a solid-color brush, which is characterized by an EmfPlusARGB value.
        /// </summary>
        SolidColor = 0x00000000,

        /// <summary>
        /// Specifies a hatch brush, which is characterized by a predefined pattern.
        /// </summary>
        HatchFill = 0x00000001,

        /// <summary>
        /// Specifies a texture brush, which is characterized by an image.
        /// </summary>
        TextureFill = 0x00000002,

        /// <summary>
        /// Specifies a path gradient brush, which is characterized by a color gradient
        /// path gradient brush data.
        /// </summary>
        PathGradient = 0x00000003,

        /// <summary>
        /// BrushData contains linear gradient brush data.
        /// </summary>
        LinearGradient = 0x00000004
    }
}
