namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines units of measurement in different coordinate systems.
    /// [MS-EMFPLUS] section 2.1.1.33
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Specifies a unit of logical distance within the world space.
        /// </summary>
        World = 0x00,

        /// <summary>
        /// Specifies a unit of distance based on the characteristics of the physical display.
        /// </summary>
        Display = 0x01,

        /// <summary>
        /// Specifies a unit of 1 pixel.
        /// </summary>
        Pixel = 0x02,

        /// <summary>
        /// Specifies a unit of 1 printer's point, or 1/72 inch.
        /// </summary>
        Point = 0x03,

        /// <summary>
        /// Specifies a unit of 1 inch.
        /// </summary>
        Inch = 0x04,

        /// <summary>
        /// Specifies a unit of 1/300 inch.
        /// </summary>
        Document = 0x05,

        /// <summary>
        /// Specifies a unit of 1 millimeter.
        /// </summary>
        Millimeter = 0x06
    }
}