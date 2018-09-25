namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines styles of lines that are drawn with graphics pens.
    /// [MS-EMFPLUS] section 2.1.1.20
    /// </summary>
    public enum LineStyle
    {
        /// <summary>
        /// Specifies a solid line.
        /// </summary>
        Solid = 0x00000000,

        /// <summary>
        /// Specifies a dashed line.
        /// </summary>
        Dash = 0x00000001,

        /// <summary>
        /// Specifies a dotted line.
        /// </summary>
        Dot = 0x00000002,

        /// <summary>
        /// Specifies an alternating dash-dot line.
        /// </summary>
        DashDot = 0x00000003,

        /// <summary>
        /// Specifies an alternating dash-dot-dot line.
        /// </summary>
        DashDotDot = 0x00000004,

        /// <summary>
        /// Specifies a user-defined, custom dashed line.
        /// </summary>
        Custom = 0x00000005
    }
}
