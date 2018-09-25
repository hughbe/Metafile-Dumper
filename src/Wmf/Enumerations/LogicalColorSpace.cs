namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Specifies the type of color space.
    /// [MS-WMF] 2.1.1.14
    /// </summary>
    public enum LogicalColorSpace
    {
        /// <summary>
        /// Color values are calibrated red green blue (RGB) values. 
        /// </summary>
        LCS_CALIBRATED_RGB = 0x00000000,

        /// <summary>
        /// The value is an encoding of the ASCII characters "sRGB", and it indicates
        /// that the color values are sRGB values.
        /// </summary>
        LCS_sRGB = 0x73524742,

        /// <summary>
        /// The value is an encoding of the ASCII characters "Win ", including the
        /// trailing space, and it indicates that the color values are Windows
        /// default color space values.
        /// </summary>
        LCS_WINDOWS_COLOR_SPACE = 0x57696E20
    }
}
