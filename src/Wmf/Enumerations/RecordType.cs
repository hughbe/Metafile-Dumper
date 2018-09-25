namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Defines the types of records that can be used in WMF metafiles.
    /// [MS-WMF] 2.1.1.1
    /// </summary>
    public enum RecordType
    {
        /// <summary>
        /// This record specifies the end of the file, the last record in the metafile.
        /// </summary>
        META_EOF = 0x0000,

        /// <summary>
        /// This record maps entries from the logical palette that is defined in the
        /// playback device context to the system palette.
        /// </summary>
        META_REALIZEPALETTE = 0x0035,

        /// <summary>
        /// This record defines red green blue (RGB) color values in a range of entries
        /// in the logical palette that is defined in the playback device context.
        /// </summary>
        META_SETPALENTRIES = 0x0037,

        /// <summary>
        /// This record defines the background raster operation mix mode in the playback
        /// device context. The background mix mode is the mode for combining pens, text,
        /// hatched brushes, and interiors of filled objects with background colors on
        /// the output surface.
        /// </summary>
        META_SETBKMODE = 0x0102,

        /// <summary>
        /// This record defines the mapping mode in the playback device context. The mapping
        /// mode defines the unit of measure used to transform page-space  coordinates into
        /// coordinates of the output device, and also defines the orientation of the
        /// device's x and y axes.
        /// </summary>
        META_SETMAPMODE = 0x0103,

        /// <summary>
        /// This record defines the foreground raster operation mix mode in the playback
        /// device context. The foreground mix mode is the mode for combining pens and
        /// interiors of filled objects with foreground colors on the output surface.
        /// </summary>
        META_SETROP2 = 0x0104,

        /// <summary>
        /// This record is undefined and MUST be ignored.
        /// </summary>
        META_SETRELABS = 0x0105,

        /// <summary>
        /// This record defines polygon fill mode in the playback device context for
        /// graphics operations that fill polygons.
        /// </summary>
        META_SETPOLYFILLMODE = 0x0106,

        /// <summary>
        /// This record defines the bitmap stretching mode in the playback device context.
        /// </summary>
        META_SETSTRETCHBLTMODE = 0x0107,

        /// <summary>
        /// This record defines inter-character spacing for text justification in the
        /// playback device context. Spacing is added to the white space between each
        /// character, including break characters, when a line of justified text is
        /// output.
        /// </summary>
        META_SETTEXTCHAREXTRA = 0x0108,

        /// <summary>
        /// This record restores the playback device context from a previously saved
        /// device context.
        /// </summary>
        META_RESTOREDC = 0x0127,

        /// <summary>
        /// This record redefines the size of the logical palette that is defined in the
        /// playback device context.
        /// </summary>
        META_RESIZEPALETTE = 0x0139,

        /// <summary>
        /// This record defines a brush with a pattern specified by a device-independent
        /// bitmap (DIB).
        /// </summary>
        META_DIBCREATEPATTERNBRUSH = 0x0142,

        /// <summary>
        /// This record defines the layout orientation in the playback device context.
        /// </summary>
        META_SETLAYOUT = 0x0149,

        /// <summary>
        /// This record sets the background color in the playback device context to a
        /// specified color, or to the nearest physical color if the device cannot
        /// represent the specified color
        /// </summary>
        META_SETBKCOLOR = 0x0201,

        /// <summary>
        /// This record defines the text color in the playback device context.
        /// </summary>
        META_SETTEXTCOLOR = 0x0209,

        /// <summary>
        /// This record moves the viewport origin in the playback device context by
        /// using specified horizontal and vertical offsets.
        /// </summary>
        META_OFFSETVIEWPORTORG = 0x0211,

        /// <summary>
        /// This record draws a line from the output position that is defined in the playback
        /// device context up to, but not including, a specified point.
        /// </summary>
        META_LINETO = 0x0213,

        /// <summary>
        /// This record sets the output position in the playback device context to a specified
        /// point.
        /// </summary>
        META_MOVETO = 0x0214,

        /// <summary>
        /// This record moves the clipping region that is defined in the playback
        /// device context by specified offsets.
        /// </summary>
        META_OFFSETCLIPRGN = 0x0220,

        /// <summary>
        /// This record fills a region by using a specified brush.
        /// </summary>
        META_FILLREGION = 0x0228,

        /// <summary>
        /// This record defines the algorithm that the font mapper uses when it maps
        /// logical fonts to physical fonts.
        /// </summary>
        META_SETMAPPERFLAGS = 0x0231,

        /// <summary>
        /// This record specifies the logical palette in the playback device context.
        /// </summary>
        META_SELECTPALETTE = 0x0234,

        /// <summary>
        /// This record paints a polygon consisting of two or more vertices connected by
        /// straight lines. The polygon is outlined by using the pen and filled by using
        /// the brush and polygon fill mode; these are defined in the playback device
        /// context.
        /// </summary>
        META_POLYGON = 0x0324,

        /// <summary>
        /// This record draws a series of line segments by connecting the points in a
        /// specified array.
        /// </summary>
        META_POLYLINE = 0x0325,

        /// <summary>
        /// This record defines the amount of space to add to break characters in a
        /// string of justified text.
        /// </summary>
        META_SETTEXTJUSTIFICATION = 0x020A,

        /// <summary>
        /// This record defines the output window origin in the playback device context.
        /// </summary>
        META_SETWINDOWORG = 0x020B,

        /// <summary>
        /// This record defines the horizontal and vertical extents of the output window
        /// in the playback device context.
        /// </summary>
        META_SETWINDOWEXT = 0x020C,

        /// <summary>
        /// This record defines the viewport origin in the playback device context.
        /// </summary>
        META_SETVIEWPORTORG = 0x020D,

        /// <summary>
        /// This record defines the horizontal and vertical extents of the viewport in
        /// the playback device context.
        /// </summary>
        META_SETVIEWPORTEXT = 0x020E,

        /// <summary>
        /// This record moves the output window origin in the playback device context
        /// by using specified horizontal and vertical offsets.
        /// </summary>
        META_OFFSETWINDOWORG = 0x020F,

        /// <summary>
        /// This record scales the horizontal and vertical extents of the output window
        /// that is defined in the playback device context by using the ratios formed
        /// by specified multiplicands and divisors.
        /// </summary>
        META_SCALEWINDOWEXT = 0x0410,

        /// <summary>
        /// This record scales the horizontal and vertical extents of the viewport that
        /// is defined in the playback device context by using the ratios formed by
        /// specified multiplicands and divisors.
        /// </summary>
        META_SCALEVIEWPORTEXT = 0x0412,

        /// <summary>
        /// This record sets the clipping region that is defined in the playback device
        /// context to the existing clipping region minus a specified rectangle.
        /// </summary>
        META_EXCLUDECLIPRECT = 0x0415,

        /// <summary>
        /// This record sets the clipping region that is defined in the playback device
        /// context to the intersection of the existing clipping region and a specified
        /// rectangle.
        /// </summary>
        META_INTERSECTCLIPRECT = 0x0416,

        /// <summary>
        /// This record defines an ellipse. The center of the ellipse is the center of a
        /// specified bounding rectangle. The ellipse is outlined by using the pen and
        /// is filled by using the brush; these are defined in the playback device
        /// context.
        /// </summary>
        META_ELLIPSE = 0x0418,

        /// <summary>
        /// This record fills an area of the display surface with the brush that is defined
        /// in the playback device context.
        /// </summary>
        META_FLOODFILL = 0x0419,

        /// <summary>
        /// This record defines a border around a specified region by using a specified
        /// brush.
        /// </summary>
        META_FRAMEREGION = 0x0429,

        /// <summary>
        /// This record redefines entries in the logical palette that is defined in the
        /// playback device context.
        /// </summary>
        META_ANIMATEPALETTE = 0x0436,

        /// <summary>
        /// This record outputs a character string at a specified location using the font,
        /// background color, and text color; these are defined in the playback device
        /// context.
        /// </summary>
        META_TEXTOUT = 0x0521,

        /// <summary>
        /// This record paints a series of closed polygons. Each polygon is outlined by
        /// using the pen and filled by using the brush and polygon fill mode; these
        /// are defined in the playback device context.The polygons drawn in this
        /// operation can overlap.
        /// </summary>
        META_POLYPOLYGON = 0x0538,

        /// <summary>
        /// This record fills an area with the brush that is defined in the playback device
        /// context.
        /// </summary>
        META_EXTFLOODFILL = 0x0548,

        /// <summary>
        /// This record paints a rectangle. The rectangle is outlined by using the pen and
        /// filled by using the brush; these are defined in the playback device context.
        /// </summary>
        META_RECTANGLE = 0x041B,

        /// <summary>
        /// This record sets the pixel at specified coordinates to a specified color.
        /// </summary>
        META_SETPIXEL = 0x041F,

        /// <summary>
        /// This record draws a rectangle with rounded corners. The rectangle is outlined
        /// by using the current pen and filled by using the current brush.
        /// </summary>
        META_ROUNDRECT = 0x061C,

        /// <summary>
        /// This record paints the specified rectangle by using the brush that is currently
        /// selected into the playback device context. The brush color and the surface
        /// color or colors are combined using the specified raster operation.
        /// </summary>
        META_PATBLT = 0x061D,

        /// <summary>
        /// This record saves the playback device context for later retrieval.
        /// </summary>
        META_SAVEDC = 0x001E,

        /// <summary>
        /// This record draws a pie-shaped wedge bounded by the intersection of an ellipse
        /// and two radials. The pie is outlined by using the pen and filled by using the
        /// brush; these are defined in the playback device context.
        /// </summary>
        META_PIE = 0x081A,

        /// <summary>
        /// This record specifies the transfer of a block of pixels according to a raster
        /// operation, with possible expansion or contraction.
        /// </summary>
        META_STRETCHBLT = 0x0B23,

        /// <summary>
        /// This record makes it possible to access capabilities of a particular printing
        /// device that are not directly available through other WMF records.
        /// </summary>
        META_ESCAPE = 0x0626,

        /// <summary>
        /// This record inverts the colors in a specified region.
        /// </summary>
        META_INVERTREGION = 0x012A,

        /// <summary>
        /// This record paints a specified region by using the brush that is defined in the
        /// playback device context.
        /// </summary>
        META_PAINTREGION = 0x012B,

        /// <summary>
        /// This record specifies the clipping region in the playback device context.
        /// </summary>
        META_SELECTCLIPREGION = 0x012C,

        /// <summary>
        ///  This record specifies a graphics object in the playback device context.
        ///  The new object replaces the previous object of the same type, if one
        ///  is defined.
        /// </summary>
        META_SELECTOBJECT = 0x012D,

        /// <summary>
        /// This record defines the text-alignment values in the playback device context.
        /// </summary>
        META_SETTEXTALIGN = 0x012E,

        /// <summary>
        /// TThis record draws an elliptical arc.
        /// </summary>
        META_ARC = 0x0817,

        /// <summary>
        /// This record draws a chord, which is a region bounded by the intersection of an
        /// ellipse and a line segment. The chord is outlined by using the pen and filled
        /// by using the brush; these are defined in the playback device context.
        /// </summary>
        META_CHORD = 0x0830,

        /// <summary>
        /// This record specifies the transfer of a block of pixels according to a
        /// raster operation.
        /// </summary>
        META_BITBLT = 0x0922,

        /// <summary>
        /// This record outputs a character string by using the font, background color, and
        /// text color; these are defined in the playback device context. Optionally,
        /// dimensions can be provided for clipping, opaquing, or both.
        /// </summary>
        META_EXTTEXTOUT = 0x0a32,

        /// <summary>
        /// This record sets a block of pixels using device-independent color data.
        /// </summary>
        META_SETDIBTODEV = 0x0d33,

        /// <summary>
        /// This record specifies the transfer of a block of pixels in device-independent
        /// format according to a raster operation.
        /// </summary>
        META_DIBBITBLT = 0x0940,

        /// <summary>
        /// This record specifies the transfer of a block of pixels in device-independent
        /// format according to a raster operation, with possible expansion or
        /// contraction.
        /// </summary>
        META_DIBSTRETCHBLT = 0x0b41,

        /// <summary>
        /// This record specifies the transfer of color data from a block of pixels in
        /// device-independent format according to a raster operation, with possible
        /// expansion or contraction.
        /// </summary>
        META_STRETCHDIB = 0x0f43,

        /// <summary>
        /// This record deletes a graphics object, which can be a pen, brush, font,
        /// region, or palette.
        /// </summary>
        META_DELETEOBJECT = 0x01f0,

        /// <summary>
        /// This record defines a logical palette.
        /// </summary>
        META_CREATEPALETTE = 0x00f7,

        /// <summary>
        /// This record defines a brush with a pattern specified by a DIB.
        /// </summary>
        META_CREATEPATTERNBRUSH = 0x01F9,

        /// <summary>
        /// This record defines a pen with specified style, width, and color.
        /// </summary>
        META_CREATEPENINDIRECT = 0x02FA,

        /// <summary>
        /// This record defines a font with specified characteristics.
        /// </summary>
        META_CREATEFONTINDIRECT = 0x02FB,

        /// <summary>
        /// This record defines a brush with specified style, color, and pattern.
        /// </summary>
        META_CREATEBRUSHINDIRECT = 0x02FC,

        /// <summary>
        /// This record defines a region.
        /// </summary>
        META_CREATEREGION = 0x06FF
    }
}
