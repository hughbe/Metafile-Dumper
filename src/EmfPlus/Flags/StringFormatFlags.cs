using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies options for graphics text layout.
    /// [MS-EMFPLUS] Section 2.1.2.8
    /// </summary>
    [Flags]
    public enum StringFormatFlags
    {
        /// <summary>
        /// If set, the reading order of the string SHOULD be right to left. For
        /// horizontal text, this means that characters are read from right to left. For
        /// vertical text, this means that columns are read from right to left.
        /// If clear, horizontal or vertical text SHOULD be read from left to right.
        /// </summary>
        DirectionRightToLeft = 0x00000001,

        /// <summary>
        /// If set, individual lines of text SHOULD be drawn vertically on the display
        /// device.
        /// If clear, individual lines of text SHOULD be drawn horizontally, with each
        /// new line below the previous line.
        /// </summary>
        DirectionVertical = 0x00000002,

        /// <summary>
        /// If set, parts of characters MUST be allowed to overhang the text layout
        /// rectangle.
        /// If clear, characters that overhang the boundaries of the text layout
        /// rectangle MUST be repositioned to avoid overhang.
        /// An italic, "f" is an example of a character that can have overhanging parts
        /// </summary>
        NoFitBlackBox = 0x00000004,

        /// <summary>
        /// If set, control characters SHOULD appear in the output as representative
        /// Unicode glyphs.
        /// </summary>
        DisplayFormatControl = 0x00000020,

        /// <summary>
        /// If set, an alternate font SHOULD be used for characters that are not
        /// supported in the requested font.
        /// If clear, a character missing from the requested font SHOULD appear as a
        /// "font missing" character, which MAY be an open square.
        /// </summary>
        NoFontFallback = 0x00000400,

        /// <summary>
        /// If set, the space at the end of each line MUST be included in measurements
        /// of string length.
        /// If clear, the space at the end of each line MUST be excluded from
        /// measurements of string length.
        /// </summary>
        MeasureTrailingSpaces = 0x00000800,

        /// <summary>
        /// If set, a string that extends past the end of the text layout rectangle MUST
        /// NOT be wrapped to the next line.
        /// If clear, a string that extends past the end of the text layout rectangle
        /// MUST be broken at the last word boundary within the bounding rectangle,
        /// and the remainder of the string MUST be wrapped to the next line.
        /// </summary>
        NoWrap = 0x00001000,

        /// <summary>
        /// If set, whole lines of text SHOULD be output and SHOULD NOT be clipped
        /// by the string's layout rectangle.
        /// If clear, text layout SHOULD continue until all lines are output, or until
        /// additional lines would not be visible as a result of clipping.
        /// This flag can be used either to deny or allow a line of text to be partially
        /// obscured by a layout rectangle that is not a multiple of line height. For all
        /// text to be visible, a layout rectangle at least as tall as the height of one
        /// line.
        /// </summary>
        LineLimit = 0x00001000,

        /// <summary>
        /// If set, text extending outside the string layout rectangle SHOULD be
        /// allowed to show.
        /// If clear, all text that extends outside the layout rectangle SHOULD be
        /// clipped
        /// </summary>
        NoClip = 0x00004000,

        /// <summary>
        /// This flag MAY be used to specify an implementation-specific process for
        /// rendering text.
        /// </summary>
        BypassGDI = unchecked((int)0x80000000)
    }
}
