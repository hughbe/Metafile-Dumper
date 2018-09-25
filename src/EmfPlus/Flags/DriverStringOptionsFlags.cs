using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies properties of graphics text positioning and rendering.
    /// [MS-EMFPLUS] Section 2.1.2.3
    /// </summary>
    [Flags]
    public enum DriverStringOptionsFlags : uint
    {
        /// <summary>
        /// If set, the positions of character glyphs SHOULD be specified in a
        /// character map lookup table.
        /// If clear, the glyph positions SHOULD be obtained from an array of
        /// coordinates.
        /// </summary>
        CmapLookup = 0x00000001,

        /// <summary>
        /// If set, the string SHOULD be rendered vertically.
        /// If clear, the string SHOULD be rendered horizontally.
        /// </summary>
        Vertical = 0x00000002,

        /// <summary>
        /// If set, character glyph positions SHOULD be calculated relative to the
        /// position of the first glyph.
        /// If clear, the glyph positions SHOULD be obtained from an array of
        /// coordinates.
        /// </summary>
        RealizedAdvance = 0x00000004,

        /// <summary>
        /// If set, less memory SHOULD be used to cache anti-aliased glyphs, which
        /// produces lower quality text rendering.
        /// If clear, more memory SHOULD be used, which produces higher quality
        /// text rendering.
        /// </summary>
        LimitSubpixel = 0x00000008
    }
}
