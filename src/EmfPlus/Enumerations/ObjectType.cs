namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of graphics objects that can be created and used in graphics
    /// operations.
    /// [MS-EMFPLUS] section 2.1.1.22
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// The object is not a valid object
        /// </summary>
        Invalid = 0x00000000,

        /// <summary>
        /// Specifies an EmfPlusBrush object. Brush objects fill graphics regions.
        /// </summary>
        Brush = 0x00000001,

        /// <summary>
        /// Specifies an EmfPlusPen object. Pen objects draw graphics lines.
        /// </summary>
        Pen = 0x00000002,

        /// <summary>
        /// Specifies an EmfPlusPath object. Path objects specify sequences of lines, curves,
        /// and shapes.
        /// </summary>
        Path = 0x00000003,

        /// <summary>
        /// Specifies an EmfPlusRegion object. Region objects specify areas of the output
        /// surface.
        /// </summary>
        Region = 0x00000004,

        /// <summary>
        /// Specifies an EmfPlusImage object. Image objects encapsulate bitmaps and
        /// metafiles.
        /// </summary>
        Image = 0x00000005,

        /// <summary>
        /// Specifies an EmfPlusFont object. Font objects specify font properties, including
        /// typeface style, em size, and font family.
        /// </summary>
        Font = 0x00000006,

        /// <summary>
        /// Specifies an EmfPlusStringFormat object. String format objects specify text
        /// layout, including alignment, orientation, tab stops, clipping, and digit
        /// substitution for languages that do not use Western European digits.
        /// </summary>
        StringFormat = 0x00000007,

        /// <summary>
        /// Specifies an EmfPlusImageAttributes object. Image attribute objects specify
        /// operations on pixels during image rendering, including color adjustment,
        /// grayscale adjustment, gamma correction, and color mapping.
        /// </summary>
        ImageAttributes = 0x00000008,

        /// <summary>
        /// Specifies an EmfPlusCustomLineCap object. Custom line cap objects specify shapes
        /// to draw at the ends of a graphics line, including squares, circles, and
        /// diamonds.
        /// </summary>
        CustomLineCap = 0x00000009
    }
}
