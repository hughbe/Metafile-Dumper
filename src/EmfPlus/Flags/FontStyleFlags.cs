using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies styles of graphics font typefaces.
    /// [MS-EMFPLUS] Section 2.1.2.4
    /// </summary>
    [Flags]
    public enum FontStyleFlags
    {
        /// <summary>
        /// If set, the font typeface MUST be rendered with a heavier weight or thickness.
        /// If clear, the font typeface MUST be rendered with a normal thickness.
        /// </summary>
        Bold = 0x00000001,

        /// <summary>
        /// If set, the font typeface MUST be rendered with the vertical stems of the
        /// characters at an increased angle or slant relative to the baseline.
        /// If clear, the font typeface MUST be rendered with the vertical stems of the
        /// characters at a normal angle.
        /// </summary>
        Italic = 0x00000002,

        /// <summary>
        /// If set, the font typeface MUST be rendered with a line underneath the baseline
        /// of the characters.
        /// If clear, the font typeface MUST be rendered without a line underneath the
        /// baseline.
        /// </summary>
        Underline = 0x00000004,

        /// <summary>
        /// If set, the font typeface MUST be rendered with a line parallel to the baseline
        /// drawn through the middle of the characters.
        /// If clear, the font typeface MUST be rendered without a line through the characters.
        /// </summary>
        Strikeout = 0x00000008
    }
}
