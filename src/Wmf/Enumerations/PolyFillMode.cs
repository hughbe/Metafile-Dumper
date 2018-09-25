namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Specifies the method used for filling a polygon.
    /// [MS-WMF] 2.1.1.25
    /// </summary>
    public enum PolyFillMode
    {
        /// <summary>
        /// Selects alternate mode (fills the area between odd-numbered and even-numbered
        /// polygon sides on each scan line).
        /// </summary>
        ALTERNATE = 0x0001,

        /// <summary>
        /// Selects winding mode (fills any region with a nonzero winding value).
        /// </summary>
        WINDING = 0x0002
    }
}
