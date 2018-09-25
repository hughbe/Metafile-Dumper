using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies properties of graphics palettes.
    /// [MS-EMFPLUS] Section 2.1.2.5
    /// </summary>
    [Flags]
    public enum PaletteStyleFlags : uint
    {
        /// <summary>
        /// If set, one or more of the palette entries MUST contain alpha transparency
        /// information. 
        /// </summary>
        HasAlpha = 0x00000001,

        /// <summary>
        /// If set, the palette MUST contain only grayscale entries.
        /// </summary>
        GrayScale = 0x00000002,

        /// <summary>
        /// If set, the palette MUST contain discrete color values that can be used
        /// for halftoning.
        /// </summary>
        Halftone = 0x00000004
    }
}
