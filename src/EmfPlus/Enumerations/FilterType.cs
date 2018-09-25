namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of filtering algorithms that can be used for text and graphics
    /// quality enhancement and image rendering.
    /// [MS-EMFPLUS] section 2.1.1.11
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// Specifies that filtering is not performed.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Specifies that each destination pixel is computed by sampling the nearest pixel
        /// from the source image.
        /// </summary>
        Point = 0x01,

        /// <summary>
        /// Specifies that linear interpolation is performed using the weighted average of a
        /// 2x2 area of pixels surrounding the source pixel.
        /// </summary>
        Linear = 0x02,

        /// <summary>
        /// Specifies that each pixel in the source image contributes equally to the
        /// destination image. This is the slowest of filtering algorithms.
        /// </summary>
        Triangle = 0x03,

        /// <summary>
        /// Specifies a box filter algorithm, in which each destination pixel is computed by
        /// averaging a rectangle of source pixels. This algorithm is useful only when reducing
        /// the size of an image.
        /// </summary>
        Box = 0x04,

        /// <summary>
        /// Specifies that a 4-sample tent filter is used.
        /// </summary>
        PyramidalQuad = 0x06,

        /// <summary>
        /// Specifies that a 4-sample Gaussian filter is used, which creates a blur effect
        /// on an image.
        /// </summary>
        GaussianQuad = 0x07
    }
}
