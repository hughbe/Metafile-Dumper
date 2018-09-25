namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Specifies the number of bits that define each pixel and the maximum number
    /// of colors in a device-independent bitmap (DIB).
    /// [MS-WMF] 2.1.1.3
    /// </summary>
    public enum BitCount : ushort
    {
        /// <summary>
        /// The number of bits per pixel is undefined.
        /// The image SHOULD be in either JPEG or PNG format.<4> Neither of these formats
        /// includes a color table, so this value specifies that no color table is present
        /// in the Colors field of the DIB Object.
        /// See [JFIF] and [RFC2083] for more information concerning JPEG and PNG
        /// compression formats
        /// </summary>
        BI_BITCOUNT_0 = 0x0000,

        /// <summary>
        /// The image is specified with two colors.
        /// Each pixel in the bitmap in the BitmapBuffer field of the DIB Object is
        /// represented by a single bit.
        /// If the bit is clear, the pixel is displayed with the color of the first entry
        /// in the color table in the Colors field.
        /// If the bit is set, the pixel has the color of the second entry in the table.
        /// </summary>
        BI_BITCOUNT_1 = 0x0001,

        /// <summary>
        /// The image is specified with a maximum of 16 colors.
        /// Each pixel in the bitmap in the BitmapBuffer field of the DIB Object is
        /// represented by a 4-bit index into the color table in the Colors field,
        /// and each byte contains 2 pixels.
        /// </summary>
        BI_BITCOUNT_2 = 0x0004,

        /// <summary>
        /// The image is specified with a maximum of 256 colors.
        /// Each pixel in the bitmap in the BitmapBuffer field of the DIB Object is
        /// represented by an 8-bit index into the color table in the Colors field,
        /// and each byte contains 1 pixel.
        /// </summary>
        BI_BITCOUNT_3 = 0x0008,

        /// <summary>
        /// The image is specified with a maximum of 2^16 colors.
        /// Each pixel in the bitmap in the BitmapBuffer field of the DIB Object is
        /// represented by a 16-bit value.
        /// </summary>
        BI_BITCOUNT_4 = 0x0010,

        /// <summary>
        /// The bitmap in the BitmapBuffer field of the DIB Object has a maximum of 2^24
        /// colors, and the Colors field is NULL. Each 3-byte triplet in the bitmap
        /// represents the relative intensities of blue, green, and red, respectively,
        /// for a pixel. 
        /// </summary>
        BI_BITCOUNT_5 = 0x0018,

        /// <summary>
        /// The bitmap in the BitmapBuffer field of the DIB Object has a maximum of 2^24
        /// colors.
        /// </summary>
        BI_BITCOUNT_6 = 0x0020
    }
}
