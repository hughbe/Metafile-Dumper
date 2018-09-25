namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines how pixels are offset, which specifies the trade-off between
    /// rendering speed and quality.
    /// [MS-EMFPLUS] section 2.1.1.26
    /// </summary>
    public enum PixelOffsetMode
    {
        /// <summary>
        /// Pixels are centered on integer coordinates, specifying speed over quality.
        /// </summary>
        Default = 0x00,

        /// <summary>
        /// Pixels are centered on integer coordinates, as with PixelOffsetModeNone.
        /// Higher speed at the expense of quality is specified.
        /// </summary>
        HighSpeed = 0x01,

        /// <summary>
        /// Pixels are centered on half-integer coordinates, as with PixelOffsetModeHalf.
        /// Higher quality at the expense of speed is specified.
        /// </summary>
        HighQuality = 0x02,

        /// <summary>
        /// Pixels are centered on the origin, which means that the pixel covers the area
        /// from -0.5 to 0.5 on both the x and y axes and its center is at (0,0).
        /// </summary>
        None = 0x03,

        /// <summary>
        /// Pixels are centered on half-integer coordinates, which means that the pixel
        /// covers the area from 0 to 1 on both the x and y axes and its center is at
        /// (0.5,0.5). By offsetting pixels during rendering, the render quality can
        /// be improved at the cost of render speed.
        /// </summary>
        Half = 0x04
    }
}
