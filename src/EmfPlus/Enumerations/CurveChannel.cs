namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines color channels that can be affected by a color curve effect adjustment
    /// to an image.
    /// [MS-EMFPLUS] section 2.1.1.8
    /// </summary>
    public enum CurveChannel
    {
        /// <summary>
        /// Specifies that a color curve adjustment applies to all color channels.
        /// </summary>
        All = 0x00000000,

        /// <summary>
        /// Specifies that a color curve adjustment applies only to the red color channel.
        /// </summary>
        Red = 0x00000001,

        /// <summary>
        /// Specifies that a color curve adjustment applies only to the green color channel.
        /// </summary>
        Green = 0x00000002,

        /// <summary>
        /// Specifies that a color curve adjustment applies only to the blue color channel.
        /// </summary>
        Blue = 0x00000003
    }
}
