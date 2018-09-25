namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines the distribution of the width of the pen with respect to the line
    /// being drawn.
    /// [MS-EMFPLUS] section 2.1.1.24
    /// </summary>
    public enum PenAlignment
    {
        /// <summary>
        /// Specifies that the EmfPlusPen object is centered over the theoretical line.
        /// </summary>
        Center = 0x00000000,

        /// <summary>
        /// Specifies that the pen is positioned on the inside of the theoretical line.
        /// </summary>
        Inset = 0x00000001,

        /// <summary>
        /// Specifies that the pen is positioned to the left of the theoretical line.
        /// </summary>
        Left = 0x00000002,

        /// <summary>
        /// Specifies that the pen is positioned on the outside of the theoretical line.
        /// </summary>
        Outset = 0x00000003,

        /// <summary>
        /// Specifies that the pen is positioned to the right of the theoretical line.
        /// </summary>
        Right = 0x00000004
    }
}
