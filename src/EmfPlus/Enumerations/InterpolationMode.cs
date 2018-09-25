namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines ways to perform scaling, including stretching and shrinking.
    /// [MS-EMFPLUS] section 2.1.1.16
    /// </summary>
    public enum InterpolationMode
    {
        /// <summary>
        /// Specifies the default interpolation mode, which is defined as
        /// InterpolationModeBilinear.
        /// </summary>
        Default = 0x00,

        /// <summary>
        /// Specifies a low-quality interpolation mode, which is defined as
        /// InterpolationModeNearestNeighbor.
        /// </summary>
        LowQuality = 0x01,

        /// <summary>
        /// Specifies a high-quality interpolation mode, which is defined as
        /// InterpolationModeHighQualityBicubic.
        /// </summary>
        HighQuality = 0x02,

        /// <summary>
        /// Specifies bilinear interpolation, which uses the closest 2x2 neighborhood of known
        /// known pixels surrounding the interpolated pixel. The weighted average of these 4
        /// known pixel values determines the value to assign to the interpolated pixel.
        /// The result is smoother looking than InterpolationModeNearestNeighbor.
        /// </summary>
        Bilinear = 0x03,

        /// <summary>
        /// Specifies bicubic interpolation, which uses the closest 4x4 neighborhood of known
        /// pixels surrounding the interpolated pixel. The weighted average of these 16 known
        /// pixel values determines the value to assign to the interpolated pixel. Because the
        /// known pixels are likely to be at varying distances from the interpolated pixel,
        /// closer pixels are given a higher weight in the calculation.
        /// The result is smoother looking than InterpolationModeBilinear
        /// </summary>
        Bicubic = 0x04,

        /// <summary>
        /// Specifies nearest-neighbor interpolation, which uses only the value of the pixel
        /// that is closest to the interpolated pixel. This mode simply duplicates or removes
        /// pixels, producing the lowest-quality result among these options.
        /// </summary>
        NearestNeighbor = 0x05,

        /// <summary>
        /// Specifies bilinear interpolation with prefiltering.
        /// </summary>
        HighQualityBilinear = 0x06,

        /// <summary>
        /// Specifies bicubic interpolation with prefiltering, which produces the
        /// highest-quality result among these options.
        /// </summary>
        HighQualityBicubic = 0x07
    }
}
