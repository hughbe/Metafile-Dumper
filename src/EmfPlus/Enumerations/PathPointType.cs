namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of points on a graphics path.
    /// [MS-EMFPLUS] section 2.1.1.24
    /// </summary>
    public enum PathPointType
    {
        /// <summary>
        /// Specifies that the point is the starting point of a path.
        /// </summary>
        Start = 0x00,

        /// <summary>
        /// Specifies that the point is one of the two endpoints of a line.
        /// </summary>
        Line = 0x01,

        /// <summary>
        /// Specifies that the point is an endpoint or control point of a cubic Bezier
        /// curve.
        /// </summary>
        Bezier = 0x03
    }
}
