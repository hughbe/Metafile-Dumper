namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Specifies different types of pens that can be used in graphics operations.
    /// [MS-WMF] 2.1.1.32
    /// </summary>
    public enum PenStyle : ushort
    {
        /// <summary>
        /// The pen is cosmetic.
        /// </summary>
        PS_COSMETIC = 0x0000,

        /// <summary>
        /// Line end caps are round.
        /// </summary>
        PS_ENDCAP_ROUND = 0x0000,

        /// <summary>
        /// Line joins are round.
        /// </summary>
        PS_JOIN_ROUND = 0x0000,

        /// <summary>
        /// The pen is solid.
        /// </summary>
        PS_SOLID = 0x0000,

        /// <summary>
        /// The pen is dashed.
        /// </summary>
        PS_DASH = 0x0001,

        /// <summary>
        /// The pen is dotted.
        /// </summary>
        PS_DOT = 0x0002,

        /// <summary>
        /// The pen has alternating dashes and dots.
        /// </summary>
        PS_DASHDOT = 0x0003,

        /// <summary>
        /// The pen has dashes and double dots.
        /// </summary>
        PS_DASHDOTDOT = 0x0004,

        /// <summary>
        /// The pen is invisible.
        /// </summary>
        PS_NULL = 0x0005,

        /// <summary>
        /// The pen is solid. When this pen is used in any drawing record that takes a
        /// bounding rectangle, the dimensions of the figure are shrunk so that it
        /// fits entirely in the bounding rectangle, taking into account the width of
        /// the pen.
        /// </summary>
        PS_INSIDEFRAME = 0x0006,

        /// <summary>
        /// The pen uses a styling array supplied by the user.
        /// </summary>
        PS_USERSTYLE = 0x0007,

        /// <summary>
        /// The pen sets every other pixel (this style is applicable only for
        /// cosmetic pens).
        /// </summary>
        PS_ALTERNATE = 0x0008,

        /// <summary>
        /// Line end caps are square.
        /// </summary>
        PS_ENDCAP_SQUARE = 0x0100,

        /// <summary>
        /// Line end caps are flat.
        /// </summary>
        PS_ENDCAP_FLAT = 0x0200,

        /// <summary>
        /// Line joins are beveled.
        /// </summary>
        PS_JOIN_BEVEL = 0x1000,

        /// <summary>
        /// Line joins are mitered when they are within the current limit set by the
        /// SET_MITERLIMIT Record (section 2.3.6.42).
        /// A join is beveled when it would exceed the limit.
        /// </summary>
        PS_JOIN_MITER = 0x2000
    }
}
