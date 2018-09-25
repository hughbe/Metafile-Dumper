namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines how the pattern from a texture or gradient brush is tiled across a
    /// shape or at shape boundaries, when it is smaller than the area being
    /// filled.
    /// [MS-EMFPLUS] section 2.1.1.34
    /// </summary>
    public enum WrapMode
    {
        /// <summary>
        /// Tiles the gradient or texture.
        /// </summary>
        Tile = 0x00000000,

        /// <summary>
        /// Reverses the texture or gradient horizontally, and then tiles the texture or
        /// gradient.
        /// </summary>
        TileFlipX = 0x00000001,

        /// <summary>
        /// Reverses the texture or gradient vertically, and then tiles the texture or
        /// gradient.
        /// </summary>
        TileFlipY = 0x00000002,

        /// <summary>
        /// Reverses the texture or gradient horizontally and vertically, and then tiles the
        /// texture or gradient.
        /// </summary>
        TileFlipXY = 0x00000003,

        /// <summary>
        /// Fixes the texture or gradient to the object boundary.
        /// </summary>
        Clamp = 0x00000004
    }
}
