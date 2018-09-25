namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of bitmap data formats.
    /// [MS-EMFPLUS] section 2.1.1.2
    /// </summary>
    public enum BitmapDataType
    {
        /// <summary>
        /// Specifies a bitmap image with pixel data.
        /// </summary>
        Pixel = 0x00000000,

        /// <summary>
        /// Specifies a bitmap image with compressed data.
        /// </summary>
        Compressed = 0x00000001
    }
}
