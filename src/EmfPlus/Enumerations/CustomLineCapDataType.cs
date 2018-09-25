namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of custom line cap data, which specify styles and shapes for
    /// the ends of graphics lines.
    /// [MS-EMFPLUS] section 2.1.1.9
    /// </summary>
    public enum CustomLineCapDataType
    {
        /// <summary>
        /// Specifies a default custom line cap.
        /// </summary>
        Default = 0x00000000,

        /// <summary>
        /// Specifies an adjustable arrow custom line cap.
        /// </summary>
        AdjustableArrow = 0x00000001
    }
}
