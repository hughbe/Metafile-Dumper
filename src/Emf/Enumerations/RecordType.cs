namespace MetafileDumper.Emf.Enumerations
{
    /// <summary>
    /// Defines values that uniquely identify records in an EMF metafile.
    /// [MS-EMF] 2.1.1
    /// </summary>
    public enum RecordType
    {
        /// <summary>
        /// This record defines the start of the metafile and specifies its characteristics;
        /// its contents, including the dimensions of the embedded image; the number of
        /// records in the metafile; and the resolution of the device on which the embedded
        /// image was created. These values make it possible for the metafile to be
        /// device-independent.
        /// </summary>
        EMR_HEADER = 0x00000001,

        /// <summary>
        /// This record defines one or more Bezier curves. Cubic Bezier curves are defined
        /// using specified endpoints and control points, and are stroked with the current pen.
        /// </summary>
        EMR_POLYBEZIER = 0x00000002,

        /// <summary>
        /// This record defines a polygon consisting of two or more vertexes connected by
        /// straight lines. The polygon is outlined by using the current pen and filled
        /// y using the current brush and polygon fill mode.The polygon is closed
        /// automatically by drawing a line from the last vertex to the first.
        /// </summary>
        EMR_POLYGON = 0x00000003,

        /// <summary>
        /// This record defines a series of line segments by connecting the points in the
        /// specified array.
        /// </summary>
        EMR_POLYLINE = 0x00000004,

        /// <summary>
        /// This record defines one or more Bezier curves based upon the current
        /// drawing position.
        /// </summary>
        EMR_POLYBEZIERTO = 0x00000005,

        /// <summary>
        /// This record defines one or more straight lines based upon the current drawing
        /// position. A line is drawn from the current drawing position to the first point
        /// specified by the points field by using the current pen.For each additional
        /// line, drawing is performed from the ending point of the previous line to the
        /// next point specified by points.
        /// </summary>
        EMR_POLYLINETO = 0x00000006,

        /// <summary>
        /// This record defines multiple series of connected line segments. The line
        /// segments are drawn by using the current pen.The figures formed by the
        /// segments are not filled. The current position is neither used nor updated
        /// by this record.
        /// </summary>
        EMR_POLYPOLYLINE = 0x00000007,

        /// <summary>
        /// This record defines a series of closed polygons. Each polygon is outlined by
        /// using the current pen and filled by using the current brush and polygon fill
        /// mode.The polygons defined by this record can overlap.
        /// </summary>
        EMR_POLYPOLYGON = 0x00000008,

        /// <summary>
        /// This record defines the window extent.
        /// </summary>
        EMR_SETWINDOWEXTEX = 0x00000009,

        /// <summary>
        /// This record defines the window origin.
        /// </summary>
        EMR_SETWINDOWORGEX = 0x0000000A,

        /// <summary>
        /// This record defines the viewport extent.
        /// </summary>
        EMR_SETVIEWPORTEXTEX = 0x0000000B,

        /// <summary>
        /// This record defines the viewport origin.
        /// </summary>
        EMR_SETVIEWPORTORGEX = 0x0000000C,

        /// <summary>
        /// This record defines the origin of the current brush.
        /// </summary>
        EMR_SETBRUSHORGEX = 0x0000000D,

        /// <summary>
        /// This record indicates the end of the metafile.
        /// </summary>
        EMR_EOF = 0x0000000E,

        /// <summary>
        /// This record defines the color of the pixel at the specified logical coordinates.
        /// </summary>
        EMR_SETPIXELV = 0x0000000F,

        /// <summary>
        /// This record specifies parameters for the process of matching logical fonts
        /// to physical fonts, which is performed by the font mapper.
        /// </summary>
        EMR_SETMAPPERFLAGS = 0x00000010,

        /// <summary>
        /// This record defines the mapping mode, which defines the unit of measure used
        /// to transform page space units into device space units, and defines the
        /// orientation of the device's X and Y axes.
        /// </summary>
        EMR_SETMAPMODE = 0x00000011,

        /// <summary>
        /// This record defines the background mix mode, which is used with text, hatched
        /// brushes, and pen styles that are not solid lines.
        /// </summary>
        EMR_SETBKMODE = 0x00000012,

        /// <summary>
        /// This record defines polygon fill mode.
        /// </summary>
        EMR_SETPOLYFILLMODE = 0x00000013,

        /// <summary>
        /// This record defines binary raster operation mode.
        /// </summary>
        EMR_SETROP2 = 0x00000014,

        /// <summary>
        /// This record defines bitmap stretch mode.
        /// </summary>
        EMR_SETSTRETCHBLTMODE = 0x00000015,

        /// <summary>
        /// This record defines text alignment.
        /// </summary>
        EMR_SETTEXTALIGN = 0x00000016,

        /// <summary>
        /// This record defines the color adjustment values using the specified values.
        /// </summary>
        EMR_SETCOLORADJUSTMENT = 0x00000017,

        /// <summary>
        /// This record defines the current text color.
        /// </summary>
        EMR_SETTEXTCOLOR = 0x00000018,

        /// <summary>
        /// This record defines the background color.
        /// </summary>
        EMR_SETBKCOLOR = 0x00000019,

        /// <summary>
        /// This record redefines the current clipping region by the specified offsets.
        /// </summary>
        EMR_OFFSETCLIPRGN = 0x0000001A,

        /// <summary>
        /// This record defines coordinates of the new drawing position in logical units.
        /// </summary>
        EMR_MOVETOEX = 0x0000001B,

        /// <summary>
        /// This record intersects the current clipping region with the current metaregion
        /// and saves the combined region as the new current metaregion.
        /// </summary>
        EMR_SETMETARGN = 0x0000001C,

        /// <summary>
        /// This record defines a new clipping region that consists of the current
        /// clipping region intersected with the specified rectangle.
        /// </summary>
        EMR_EXCLUDECLIPRECT = 0x0000001D,

        /// <summary>
        /// This record defines a new clipping region from the intersection of the
        /// current clipping region and the specified rectangle.
        /// </summary>
        EMR_INTERSECTCLIPRECT = 0x0000001E,

        /// <summary>
        /// This record redefines the viewport using the ratios formed by the
        /// specified multiplicands and divisors.
        /// </summary>
        EMR_SCALEVIEWPORTEXTEX = 0x0000001F,

        /// <summary>
        /// This record redefines the window using the ratios formed by the
        /// specified multiplicands and divisors.
        /// </summary>
        EMR_SCALEWINDOWEXTEX = 0x00000020,

        /// <summary>
        /// This record saves the current state of the playback device context (section 3.1)
        /// in an array of states saved by preceding EMR_SAVEDC records if any.
        /// </summary>
        EMR_SAVEDC = 0x00000021,

        /// <summary>
        /// This record restores the playback device context to the specified state, which
        /// was saved by a preceding EMR_SAVEDC record (section 2.3.11).
        /// </summary>
        EMR_RESTOREDC = 0x00000022,

        /// <summary>
        /// This record defines a two-dimensional linear transform between world space and
        /// page space [MSDN-WRLDPGSPC].
        /// </summary>
        EMR_SETWORLDTRANSFORM = 0x00000023,

        /// <summary>
        /// This record redefines the world transform by using the specified mode.
        /// </summary>
        EMR_MODIFYWORLDTRANSFORM = 0x00000024,

        /// <summary>
        /// This record selects an object in the playback device context, which is
        /// identified by its index in the EMF object table (section 3.1.1.1).
        /// </summary>
        EMR_SELECTOBJECT = 0x00000025,

        /// <summary>
        /// This record defines a logical pen (section 2.2.19) that has the specified style,
        /// width, and color.
        /// </summary>
        EMR_CREATEPEN = 0x00000026,

        /// <summary>
        /// This record defines a logical brush for filling figures in graphics operations.
        /// </summary>
        EMR_CREATEBRUSHINDIRECT = 0x00000027,

        /// <summary>
        /// This record deletes a graphics object, clearing its index in the EMF object table.
        /// </summary>
        EMR_DELETEOBJECT = 0x00000028,

        /// <summary>
        /// This record defines a line segment of an arc. The line segment is drawn from
        /// the current drawing position to the beginning of the arc. The arc is drawn
        /// along the perimeter of a circle with the given radius and center. The length
        /// of the arc is defined by the given start and sweep angles.
        /// </summary>
        EMR_ANGLEARC = 0x00000029,

        /// <summary>
        /// This record defines an ellipse. The center of the ellipse is the center of
        /// the specified bounding rectangle. The ellipse is outlined by using the
        /// current pen and is filled by using the current brush.
        /// </summary>
        EMR_ELLIPSE = 0x0000002A,

        /// <summary>
        /// This record defines a rectangle. The rectangle is outlined by using the current
        /// pen and filled by using the current brush.
        /// </summary>
        EMR_RECTANGLE = 0x0000002B,

        /// <summary>
        /// This record defines a rectangle with rounded corners. The rectangle is outlined
        /// by using the current pen and filled by using the current brush.
        /// </summary>
        EMR_ROUNDRECT = 0x0000002C,

        /// <summary>
        /// This record defines an elliptical arc.
        /// </summary>
        EMR_ARC = 0x0000002D,

        /// <summary>
        /// This record defines a chord, which is a region bounded by the intersection of
        /// an ellipse and a line segment, called a secant. The chord is outlined by
        /// using the current pen and filled by using the current brush.
        /// </summary>
        EMR_CHORD = 0x0000002E,

        /// <summary>
        /// This record defines a pie-shaped wedge bounded by the intersection of an ellipse
        /// and two radials. The pie is outlined by using the current pen and filled by
        /// by using the current brush.
        /// </summary>
        EMR_PIE = 0x0000002F,

        /// <summary>
        /// This record selects a LogPalette object (section 2.2.17) into the playback
        /// device context, identifying it by its index in the EMF object table.
        /// </summary>
        EMR_SELECTPALETTE = 0x00000030,

        /// <summary>
        /// This record defines a LogPalette object.
        /// </summary>
        EMR_CREATEPALETTE = 0x00000031,

        /// <summary>
        /// This record defines RGB color values in a range of entries in a LogPalette
        /// object.
        /// </summary>
        EMR_SETPALETTEENTRIES = 0x00000032,

        /// <summary>
        /// This record increases or decreases the size of a logical palette.
        /// </summary>
        EMR_RESIZEPALETTE = 0x00000033,

        /// <summary>
        /// This record maps entries from the current logical palette to the system palette.
        /// </summary>
        EMR_REALIZEPALETTE = 0x00000034,

        /// <summary>
        /// This record fills an area of the display surface with the current brush.
        /// </summary>
        EMR_EXTFLOODFILL = 0x00000035,

        /// <summary>
        /// This record defines a line from the current drawing position up to, but not
        /// including, the specified point. It resets the current drawing position to
        /// the specified point.
        /// </summary>
        EMR_LINETO = 0x00000036,

        /// <summary>
        /// This record defines an elliptical arc. It resets the current position to the
        /// endpoint of the arc.
        /// </summary>
        EMR_ARCTO = 0x00000037,

        /// <summary>
        /// This record defines a set of line segments and Bezier curves.
        /// </summary>
        EMR_POLYDRAW = 0x00000038,

        /// <summary>
        /// This record defines the drawing direction to be used for arc and rectangle
        /// operations.
        /// </summary>
        EMR_SETARCDIRECTION = 0x00000039,

        /// <summary>
        /// This record defines the limit for the length of miter joins.
        /// </summary>
        EMR_SETMITERLIMIT = 0x0000003A,

        /// <summary>
        /// This record opens a path bracket for specifying the current path.
        /// </summary>
        EMR_BEGINPATH = 0x0000003B,

        /// <summary>
        /// This record closes an open path bracket and selects the path into the playback
        /// device context.
        /// </summary>
        EMR_ENDPATH = 0x0000003C,

        /// <summary>
        /// This record closes an open figure in a path.
        /// </summary>
        EMR_CLOSEFIGURE = 0x0000003D,

        /// <summary>
        /// This record closes any open figures in the current path bracket and fills its
        /// interior by using the current brush and polygon-filling mode.
        /// </summary>
        EMR_FILLPATH = 0x0000003E,

        /// <summary>
        /// This record closes any open figures in a path, strokes the outline of the
        /// path by using the current pen, and fills its interior by using the
        /// current brush.
        /// </summary>
        EMR_STROKEANDFILLPATH = 0x0000003F,

        /// <summary>
        /// This record renders the specified path by using the current pen.
        /// </summary>
        EMR_STROKEPATH = 0x00000040,

        /// <summary>
        /// This record turns each curve in the path into a sequence of lines.
        /// </summary>
        EMR_FLATTENPATH = 0x00000041,

        /// <summary>
        /// This record redefines the current path bracket as the area that would be
        /// painted if the path were stroked using the current pen.
        /// </summary>
        EMR_WIDENPATH = 0x00000042,

        /// <summary>
        /// This record specifies a clipping region as the current clipping region
        /// combined with the current path bracket, using the specified mode.
        /// </summary>
        EMR_SELECTCLIPPATH = 0x00000043,

        /// <summary>
        /// This record aborts a path bracket or discards the path from a closed path
        /// bracket.
        /// </summary>
        EMR_ABORTPATH = 0x00000044,

        /// <summary>
        /// This record specifies arbitrary private data.
        /// </summary>
        EMR_COMMENT = 0x00000046,

        /// <summary>
        /// This record fills the specified region by using the specified brush.
        /// </summary>
        EMR_FILLRGN = 0x00000047,

        /// <summary>
        /// This record draws a border around the specified region using the specified brush.
        /// </summary>
        EMR_FRAMERGN = 0x00000048,

        /// <summary>
        /// This record inverts the colors in the specified region.
        /// </summary>
        EMR_INVERTRGN = 0x00000049,

        /// <summary>
        /// This record paints the specified region by using the current brush.
        /// </summary>
        EMR_PAINTRGN = 0x0000004A,

        /// <summary>
        /// This record combines the specified region with the current clipping region,
        /// using the specified mode.
        /// </summary>
        EMR_EXTSELECTCLIPRGN = 0x0000004B,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, optionally in combination with a brush pattern,
        /// according to a specified raster operation.
        /// </summary>
        EMR_BITBLT = 0x0000004C,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, optionally in combination with a brush pattern,
        /// according to a specified raster operation, stretching or compressing the
        /// output to fit the dimensions of the destination, if necessary.
        /// </summary>
        EMR_STRETCHBLT = 0x0000004D,

        /// <summary>
        /// his record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, optionally in combination with a brush pattern and
        /// with the application of a color mask bitmap, according to specified
        /// foreground and background raster operations.
        /// </summary>
        EMR_MASKBLT = 0x0000004E,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination parallelogram, with the application of a color mask bitmap.
        /// </summary>
        EMR_PLGBLT = 0x0000004F,

        /// <summary>
        /// This record specifies a block transfer of pixels from specified scanlines
        /// of a source bitmap to a destination rectangle.
        /// </summary>
        EMR_SETDIBITSTODEVICE = 0x00000050,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, optionally in combination with a brush pattern,
        /// according to a specified raster operation, stretching or compressing the
        /// output to fit the dimensions of the destination, if necessary.
        /// </summary>
        EMR_STRETCHDIBITS = 0x00000051,

        /// <summary>
        /// This record defines a logical font that has the specified characteristics.
        /// The font can subsequently be selected as the current font.
        /// </summary>
        EMR_EXTCREATEFONTINDIRECTW = 0x00000052,

        /// <summary>
        /// This record draws an ASCII text string using the current font and text colors.
        /// </summary>
        EMR_EXTTEXTOUTA = 0x00000053,

        /// <summary>
        /// his record draws a Unicode text string using the current font and text colors.
        /// </summary>
        EMR_EXTTEXTOUTW = 0x00000054,

        /// <summary>
        /// This record defines one or more Bezier curves. The curves are drawn using
        /// the current pen.
        /// </summary>
        EMR_POLYBEZIER16 = 0x00000055,

        /// <summary>
        /// This record defines a polygon consisting of two or more vertexes connected by
        /// straight lines. The polygon is outlined by using the current pen and filled
        /// by using the current brush and polygon fill mode.The polygon is closed
        /// automatically by drawing a line from the last vertex to the first.
        /// </summary>
        EMR_POLYGON16 = 0x00000056,

        /// <summary>
        /// This record defines a series of line segments by connecting the points in the
        /// specified array.
        /// </summary>
        EMR_POLYLINE16 = 0x00000057,

        /// <summary>
        /// This record defines one or more Bezier curves based on the current position.
        /// </summary>
        EMR_POLYBEZIERTO16 = 0x00000058,

        /// <summary>
        /// This record defines one or more straight lines based upon the current position.
        /// A line is drawn from the current position to the first point specified by the
        /// Points field by using the current pen. For each additional line, drawing is
        /// performed from the ending point of the previous line to the next point
        /// specified by Points.
        /// </summary>
        EMR_POLYLINETO16 = 0x00000059,

        /// <summary>
        /// This record defines multiple series of connected line segments.
        /// </summary>
        EMR_POLYPOLYLINE16 = 0x0000005A,

        /// <summary>
        /// This record defines a series of closed polygons. Each polygon is outlined by
        /// using the current pen and filled by using the current brush and polygon fill
        /// mode.The polygons specified by this record can overlap.
        /// </summary>
        EMR_POLYPOLYGON16 = 0x0000005B,

        /// <summary>
        /// This record defines a set of line segments and Bezier curves.
        /// </summary>
        EMR_POLYDRAW16 = 0x0000005C,

        /// <summary>
        /// This record defines a logical brush with the specified bitmap pattern.
        /// The bitmap can be a device-independent bitmap (DIB) section bitmap or
        /// it can be a devicedependent bitmap.
        /// </summary>
        EMR_CREATEMONOBRUSH = 0x0000005D,

        /// <summary>
        /// This record defines a logical brush that has the pattern specified by the DIB.
        /// </summary>
        EMR_CREATEDIBPATTERNBRUSHPT = 0x0000005E,

        /// <summary>
        /// This record defines an extended logical pen (section 2.2.20) that has the
        /// specified style, width, color, and brush attributes.
        /// </summary>
        EMR_EXTCREATEPEN = 0x0000005F,

        /// <summary>
        /// This record draws one or more ASCII text strings using the current font and
        /// text colors.
        /// </summary>
        EMR_POLYTEXTOUTA = 0x00000060,

        /// <summary>
        /// This record draws one or more Unicode text strings using the current font
        /// and text colors.
        /// </summary>
        EMR_POLYTEXTOUTW = 0x00000061,

        /// <summary>
        /// This record specifies the mode of Image Color Management (ICM) for graphics
        /// operations.
        /// </summary>
        EMR_SETICMMODE = 0x00000062,

        /// <summary>
        /// This record creates a logical color space object from a color profile with
        /// a name consisting of ASCII characters.
        /// </summary>
        EMR_CREATECOLORSPACE = 0x00000063,

        /// <summary>
        /// This record defines the current logical color space object for graphics
        /// operations.
        /// </summary>
        EMR_SETCOLORSPACE = 0x00000064,

        /// <summary>
        /// This record deletes a logical color space object.
        /// </summary>
        EMR_DELETECOLORSPACE = 0x00000065,

        /// <summary>
        /// This record specifies an OpenGL function.
        /// </summary>
        EMR_GLSRECORD = 0x00000066,

        /// <summary>
        /// This record specifies an OpenGL function with a bounding rectangle for output.
        /// </summary>
        EMR_GLSBOUNDEDRECORD = 0x00000067,

        /// <summary>
        /// This record specifies the pixel format to use for graphics operations.
        /// </summary>
        EMR_PIXELFORMAT = 0x00000068,

        /// <summary>
        /// This record passes arbitrary information to the driver. The intent is that the
        /// information results in drawing being done.
        /// </summary>
        EMR_DRAWESCAPE = 0x00000069,

        /// <summary>
        /// This record passes arbitrary information to the driver. The intent is that the
        /// information does not result in drawing being done.
        /// </summary>
        EMR_EXTESCAPE = 0x0000006A,

        /// <summary>
        /// This record outputs a string.
        /// </summary>
        EMR_SMALLTEXTOUT = 0x0000006C,

        /// <summary>
        /// This record forces the font mapper to match fonts based on their
        /// UniversalFontId in preference to their LogFont information
        /// </summary>
        EMR_FORCEUFIMAPPING = 0x0000006D,

        /// <summary>
        /// This record passes arbitrary information to the given named driver.
        /// </summary>
        EMR_NAMEDESCAPE = 0x0000006E,

        /// <summary>
        /// This record specifies how to correct the entries of a logical palette
        /// object using Windows Color System (WCS) 1.0 values.
        /// </summary>
        EMR_COLORCORRECTPALETTE = 0x0000006F,

        /// <summary>
        /// This record specifies a color profile in a file with a name consisting of ASCII
        /// characters, for graphics output.
        /// </summary>
        EMR_SETICMPROFILEA = 0x00000070,

        /// <summary>
        /// This record specifies a color profile in a file with a name consisting of
        /// Unicode characters, for graphics output.
        /// </summary>
        EMR_SETICMPROFILEW = 0x00000071,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, including alpha transparency data, according to a
        /// specified blending operation.
        /// </summary>
        EMR_ALPHABLEND = 0x00000072,

        /// <summary>
        /// This record specifies the order in which text and graphics are drawn.
        /// </summary>
        EMR_SETLAYOUT = 0x00000073,

        /// <summary>
        /// This record specifies a block transfer of pixels from a source bitmap to a
        /// destination rectangle, treating a specified color as transparent,
        /// stretching or compressing the output to fit the dimensions of the
        /// destination, if necessary.
        /// </summary>
        EMR_TRANSPARENTBLT = 0x00000074,

        /// <summary>
        /// This record specifies filling rectangles or triangles with gradients of
        /// color.
        /// </summary>
        EMR_GRADIENTFILL = 0x00000076,

        /// <summary>
        /// This record sets the UniversalFontIds (section 2.2.27) of linked fonts to
        /// use during character lookup.
        /// </summary>
        EMR_SETLINKEDUFIS = 0x00000077,

        /// <summary>
        ///  This record specifies the amount of extra space to add to break characters
        ///  for justification purposes.
        /// </summary>
        EMR_SETTEXTJUSTIFICATION = 0x00000078,

        /// <summary>
        /// This record specifies whether to perform color matching with a color profile
        /// that is specified in a file with a name consisting of Unicode characters.
        /// </summary>
        EMR_COLORMATCHTOTARGETW = 0x00000079,

        /// <summary>
        /// This record creates a logical color space object from a color profile with
        /// a name consisting of Unicode characters.
        /// </summary>
        EMR_CREATECOLORSPACEW = 0x0000007A
    }
}
