namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines pixel formats that are supported in EMF+ bitmaps.
    /// [MS-EMFPLUS] section 2.1.1.25
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>
        /// The format is not specified.
        /// </summary>
        PixelFormatUndefined = 0x00000000,

        /// <summary>
        /// The format is monochrome, and a color palette lookup table is used.
        /// </summary>
        PixelFormat1bppIndexed = 0x00030101,

        /// <summary>
        /// The format is 16-color, and a color palette lookup table is used.
        /// </summary>
        PixelFormat4bppIndexed = 0x00030402,

        /// <summary>
        /// The format is 256-color, and a color palette lookup table is used.
        /// </summary>
        PixelFormat8bppIndexed = 0x00030803,

        /// <summary>
        /// The format is 16 bits per pixel, grayscale.
        /// </summary>
        PixelFormat16bppGrayScale = 0x00101004,

        /// <summary>
        /// The format is 16 bits per pixel; 5 bits each are used for the red, green,
        /// and blue components. The remaining bit is not used.
        /// </summary>
        PixelFormat16bppRGB555 = 0x00021005,

        /// <summary>
        /// The format is 16 bits per pixel; 5 bits are used for the red component,
        /// 6 bits for the green component, and 5 bits for the blue component.
        /// </summary>
        PixelFormat16bppRGB565 = 0x00021006,

        /// <summary>
        /// The format is 16 bits per pixel; 1 bit is used for the alpha component,
        /// and 5 bits each are used for the red, green, and blue components.
        /// </summary>
        PixelFormat16bppARGB1555 = 0x00061007,

        /// <summary>
        /// The format is 24 bits per pixel; 8 bits each are used for the red, green, and
        /// blue componenents.
        /// </summary>
        PixelFormat24bppRGB = 0x00021808,

        /// <summary>
        /// The format is 32 bits per pixel; 8 bits each are used for the red, green, and
        /// blue components. The remaining 8 bits are not used.
        /// </summary>
        PixelFormat32bppRGB = 0x00022009,

        /// <summary>
        /// The format is 32 bits per pixel; 8 bits each are used for the alpha, red,
        /// green, and blue components.
        /// </summary>
        PixelFormat32bppARGB = 0x0026200A,

        /// <summary>
        /// The format is 32 bits per pixel; 8 bits each are used for the alpha, red, green,
        /// and blue components. The red, green, and blue components are premultiplied
        /// according to the alpha component.
        /// </summary>
        PixelFormat32bppPARGB = 0x000E200B,

        /// <summary>
        /// The format is 48 bits per pixel; 16 bits each are used for the red, green, and
        /// blue components.
        /// </summary>
        PixelFormat48bppRGB = 0x0010300C,

        /// <summary>
        /// The format is 64 bits per pixel; 16 bits each are used for the alpha, red, green,
        /// and blue components.
        /// </summary>
        PixelFormat64bppARGB = 0x0034400D,

        /// <summary>
        /// The format is 64 bits per pixel; 16 bits each are used for the alpha, red, green,
        /// and blue components. The red, green, and blue components are premultiplied
        /// according to the alpha component.
        /// </summary>
        PixelFormat64bppPARGB = 0x001A400E
    }
}
