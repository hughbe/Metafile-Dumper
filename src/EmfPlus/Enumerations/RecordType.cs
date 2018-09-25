namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines record types used in EMF+ metafiles.
    /// [MS-EMFPLUS] section 2.1.1.1
    /// </summary>
    public enum RecordType : ushort
    {
        /// <summary>
        /// This record specifies the start of EMF+ data in the metafile. It MUST be embedded in the first EMF record after the EMF Header record.
        /// </summary>
        Header = 0x4001,

        /// <summary>
        /// This record specifies the end of EMF+ data in the metafile.
        /// </summary>
        EndOfFile = 0x4002,

        /// <summary>
        /// This record specifies arbitrary private data.
        /// </summary>
        Comment = 0x4003,

        /// <summary>
        /// This record specifies that subsequent EMF records ([MS-EMF] section 2.3) encountered
        /// in the metafile SHOULD be processed. EMF records cease being processed when the
        /// next EMF+ record is encountered.
        /// </summary>
        GetDC = 0x4004,

        /// <summary>
        /// This record is reserved and MUST NOT be used.
        /// </summary>
        MultiFormatStart = 0x4005,

        /// <summary>
        /// This record is reserved and MUST NOT be used.
        /// </summary>
        MultiFormatSection = 0x4006,

        /// <summary>
        /// This record is reserved and MUST NOT be used.
        /// </summary>
        MultiFormatEnd = 0x4007,

        /// <summary>
        /// This record specifies an object for use in graphics operations.
        /// </summary>
        Object = 0x4008,

        /// <summary>
        /// This record clears the output coordinate space and initializes it with a specified
        /// background color and transparency.
        /// </summary>
        Clear = 0x4009,

        /// <summary>
        /// This record defines how to fill the interiors of a series of rectangles, using a
        /// specified brush.
        /// </summary>
        FillRects = 0x400A,

        /// <summary>
        /// This record defines the pen strokes for drawing a series of rectangles.
        /// </summary>
        DrawRects = 0x400B,

        /// <summary>
        /// This record defines the data to fill the interior of a polygon, using a specified
        /// brush.
        /// </summary>
        FillPolygon = 0x400C,

        /// <summary>
        /// This record defines the pen strokes for drawing a series of connected lines.
        /// </summary>
        DrawLines = 0x400D,

        /// <summary>
        /// This record defines how to fill the interiors of an ellipse, using a specified brush.
        /// </summary>
        FillEllipse = 0x400E,

        /// <summary>
        /// This record defines the pen strokes for drawing an ellipse.
        /// </summary>
        DrawEllipse = 0x400F,

        /// <summary>
        /// This record defines how to fill a section of an interior section of an ellipse using
        /// a specified brush.
        /// </summary>
        FillPie = 0x4010,

        /// <summary>
        /// This record defines pen strokes for drawing a section of an ellipse.
        /// </summary>
        DrawPie = 0x4011,

        /// <summary>
        /// The record defines pen strokes for drawing an arc of an ellipse.
        /// </summary>
        DrawArc = 0x4012,

        /// <summary>
        /// This record defines how to fill the interior of a region using a specified brush.
        /// </summary>
        FillRegion = 0x4013,

        /// <summary>
        /// The record defines how to fill the interiors of the figures defined in a graphics
        /// path with a specified brush. A path is an object that defines an arbitrary sequence
        /// of lines, curves, and shapes.
        /// </summary>
        FillPath = 0x4014,

        /// <summary>
        /// The record defines the pen strokes to draw the figures in a graphics path. A path
        /// is an object that defines an arbitrary sequence of lines, curves, and shapes.
        /// </summary>
        DrawPath = 0x4015,

        /// <summary>
        /// This record defines how to fill the interior of a closed cardinal spline
        /// using a specified brush.
        /// </summary>
        FillClosedCurve = 0x4016,

        /// <summary>
        /// This record defines the pen and strokes for drawing a closed cardinal spline.
        /// </summary>
        DrawClosedCurve = 0x4017,

        /// <summary>
        /// This record defines the pen strokes for drawing a cardinal spline.
        /// </summary>
        DrawCurve = 0x4018,

        /// <summary>
        /// This record defines the pen strokes for drawing a Bezier spline.
        /// </summary>
        DrawBeziers = 0x4019,

        /// <summary>
        /// This record defines a scaled EmfPlusImage object. An image can consist of
        /// either bitmap or metafile data.
        /// </summary>
        DrawImage = 0x401A,

        /// <summary>
        /// This record defines a scaled EmfPlusImage object inside a parallelogram.
        /// An image can consist of either bitmap or metafile data.
        /// </summary>
        DrawImagePoints = 0x401B,

        /// <summary>
        /// This record defines a text string based on a font, a layout rectangle, and a
        /// format.
        /// </summary>
        DrawString = 0x401C,

        /// <summary>
        /// This record defines the origin of rendering to the specified horizontal and
        /// vertical coordinates. This applies to hatch brushes and to 8 and 16 bits per
        /// pixel dither patterns.
        /// </summary>
        SetRenderingOrigin = 0x401D,

        /// <summary>
        /// This record defines whether to enable or disable text anti-aliasing.
        /// Text anti-aliasing is a method of making lines and edges of character glyphs
        /// appear smoother when drawn on an output surface.
        /// </summary>
        SetAntiAliasMode = 0x401E,

        /// <summary>
        /// This record defines the process used for rendering text.
        /// </summary>
        SetTextRenderingHint = 0x401F,

        /// <summary>
        /// This record sets text contrast according to the specified text gamma value.
        /// </summary>
        SetTextContrast = 0x4020,

        /// <summary>
        /// This record defines the interpolation mode of an object according to the specified
        /// type of image filtering. The interpolation mode influences how scaling (stretching
        /// and shrinking) is performed.
        /// </summary>
        SetInterpolationMode = 0x4021,

        /// <summary>
        /// This record defines the pixel offset mode according to the specified
        /// pixel centering value.
        /// </summary>
        SetPixelOffsetMode = 0x4022,

        /// <summary>
        /// This record defines the compositing mode according to the state of alpha blending,
        /// which specifies how source colors are combined with background colors.
        /// </summary>
        SetCompositingMode = 0x4023,

        /// <summary>
        /// This record defines the compositing quality, which describes the desired
        /// level of quality for creating composite images from multiple objects.
        /// </summary>
        SetCompositingQuality = 0x4024,

        /// <summary>
        /// This record saves the graphics state, identified by a specified index, on a stack of
        /// saved graphics states. Each stack index is associated with a particular saved state,
        /// and the index is used by an EmfPlusRestore record to restore the state.
        /// </summary>
        Save = 0x4025,

        /// <summary>
        /// This record restores the graphics state, identified by a specified index, from a
        /// stack of saved graphics states. Each stack index is associated with a particular
        /// saved state, and the index is defined by an EmfPlusSave record to save the state.
        /// </summary>
        Restore = 0x4026,

        /// <summary>
        /// This record opens a new graphics state container and specifies a transform for it.
        /// Graphics containers are used to retain elements of the graphics state.
        /// </summary>
        BeginContainer = 0x4027,

        /// <summary>
        /// This record opens a new graphics state container.
        /// </summary>
        BeginContainerNoParams = 0x4028,

        /// <summary>
        /// This record closes a graphics state container that was previously opened by
        /// a begin container operation.
        /// </summary>
        EndContainer = 0x4029,

        /// <summary>
        /// This record defines the current world space transform in the playback device
        /// context, according to a specified transform matrix.
        /// </summary>
        SetWorldTransform = 0x402A,

        /// <summary>
        /// This record resets the current world space transform to the identify matrix.
        /// </summary>
        ResetWorldTransform = 0x402B,

        /// <summary>
        /// This record multiplies the current world space by a specified transform matrix.
        /// </summary>
        MultiplyWorldTransform = 0x402C,

        /// <summary>
        /// This record applies a translation transform to the current world space by
        /// specified horizontal and vertical distances.
        /// </summary>
        TranslateWorldTransform = 0x402D,

        /// <summary>
        /// This record applies a scaling transform to the current world space by
        /// specified horizontal and vertical scale factors.
        /// </summary>
        ScaleWorldTransform = 0x402E,

        /// <summary>
        /// This record rotates the current world space by a specified angle.
        /// </summary>
        RotateWorldTransform = 0x402F,

        /// <summary>
        /// This record specifies extra scaling factors for the current world space
        /// transform.
        /// </summary>
        SetPageTransform = 0x4030,

        /// <summary>
        /// This record resets the current clipping region for the world space to infinity.
        /// </summary>
        ResetClip = 0x4031,

        /// <summary>
        /// This record combines the current clipping region with a rectangle.
        /// </summary>
        SetClipRect = 0x4032,

        /// <summary>
        /// This record combines the current clipping region with a graphics path.
        /// </summary>
        SetClipPath = 0x4033,

        /// <summary>
        /// This record combines the current clipping region with another graphics region.
        /// </summary>
        SetClipRegion = 0x4034,

        /// <summary>
        /// This record applies a translation transform on the current clipping region of the
        /// world space.
        /// </summary>
        OffsetClip = 0x4035,

        /// <summary>
        /// This record specifies text output with character positions.
        /// </summary>
        DrawDriverString = 0x4036,

        /// <summary>
        /// This record closes any open figures in a path, strokes the outline of the path
        /// by using the current pen, and fills its interior by using the current brush.
        /// </summary>
        StrokeFillPath = 0x4037,

        /// <summary>
        /// This record defines an image effects parameter block that has been serialized
        /// into a data buffer.
        /// </summary>
        SerializableObject = 0x4038,

        /// <summary>
        /// This record specifies the state of a graphics device context for a terminal
        /// server.
        /// </summary>
        SetTSGraphics = 0x4039,

        /// <summary>
        /// This record specifies clipping areas in the graphics device context for a terminal
        /// server.
        /// </summary>
        SetTSClip = 0x403A
    }
}
