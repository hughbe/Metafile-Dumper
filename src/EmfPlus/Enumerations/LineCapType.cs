namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of line caps to use at the ends of lines that are drawn with
    /// graphics pens.
    /// [MS-EMFPLUS] section 2.1.1.18
    /// </summary>
    public enum LineCapType
    {
        /// <summary>
        /// Specifies a squared-off line cap. The end of the line MUST be the last point in
        /// the line.
        /// </summary>
        Flat = 0x00000000,

        /// <summary>
        /// Specifies a square line cap. The center of the square MUST be located at the
        /// last point in the line. The width of the square is the line width.
        /// </summary>
        Square = 0x00000001,

        /// <summary>
        /// Specifies a circular line cap. The center of the circle MUST be located at the
        /// last point in the line. The diameter of the circle is the line width.
        /// </summary>
        Round = 0x00000002,

        /// <summary>
        /// Specifies a triangular line cap. The base of the triangle MUST be located at
        /// the last point in the line. The base of the triangle is the line width.
        /// </summary>
        Triangle = 0x00000003,

        /// <summary>
        /// Specifies that the line end is not anchored
        /// </summary>
        NoAnchor = 0x00000010,

        /// <summary>
        /// Specifies that the line end is anchored with a square line cap. The center of
        /// the square MUST be located at the last point in the line. The height and
        /// width of the square are the line width.
        /// </summary>
        SquareAnchor = 0x00000011,

        /// <summary>
        /// Specifies that the line end is anchored with a circular line cap. The center of
        /// the circle MUST be located at the last point in the line. The circle SHOULD be
        /// wider than the line.
        /// </summary>
        RoundAnchor = 0x00000012,

        /// <summary>
        /// Specifies that the line end is anchored with a diamond-shaped line cap, which is
        /// a square turned at 45 degrees. The center of the diamond MUST be located at the
        /// last point in the line. The diamond SHOULD be wider than the line.
        /// </summary>
        DiamondAnchor = 0x00000013,

        /// <summary>
        /// Specifies that the line end is anchored with an arrowhead shape. The arrowhead
        /// point MUST be located at the last point in the line. The arrowhead SHOULD be
        /// wide than the line.
        /// </summary>
        ArrowAnchor = 0x00000014,

        /// <summary>
        /// Mask used to check whether a line cap is an anchor cap.
        /// </summary>
        AnchorMask = 0x000000F0,

        /// <summary>
        /// Specifies a custom line cap.
        /// </summary>
        Custom = 0x000000FF
    }
}
