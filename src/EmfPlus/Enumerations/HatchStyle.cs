namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines hatch patterns used by graphics brushes. A hatch pattern consists
    /// of a solid background color and lines drawn over the background.
    /// [MS-EMFPLUS] section 2.1.1.13
    /// </summary>
    public enum HatchStyle
    {
        /// <summary>
        /// Specifies equally spaced horizontal lines.
        /// </summary>
        Horizontal = 0x00000000,

        /// <summary>
        /// Specifies equally spaced vertical lines.
        /// </summary>
        Vertical = 0x00000001,

        /// <summary>
        /// Specifies lines on a diagonal from upper left to lower right.
        /// </summary>
        ForwardDiagonal = 0x00000002,

        /// <summary>
        /// Specifies lines on a diagonal from upper right to lower left.
        /// </summary>
        BackwardDiagonal = 0x00000003,

        /// <summary>
        /// Specifies crossing horizontal and vertical lines.
        /// </summary>
        LargeGrid = 0x00000004,

        /// <summary>
        /// Specifies crossing forward diagonal and backward diagonal lines with
        /// anti-aliasing.
        /// </summary>
        DiagonalCross = 0x00000005,

        /// <summary>
        /// Specifies a 5-percent hatch, which is the ratio of foreground color to
        /// background color equal to 5:100.
        /// </summary>
        HatchStyle05Percent = 0x00000006,

        /// <summary>
        /// Specifies a 10-percent hatch, which is the ratio of foreground color to
        /// background color equal to 10:100.
        /// </summary>
        HatchStyle10Percent = 0x00000007,

        /// <summary>
        /// Specifies a 20-percent hatch, which is the ratio of foreground color to
        /// background color equal to 20:100.
        /// </summary>
        HatchStyle20Percent = 0x00000008,

        /// <summary>
        /// Specifies a 25-percent hatch, which is the ratio of foreground color to
        /// background color equal to 25:100.
        /// </summary>
        HatchStyle25Percent = 0x00000009,

        /// <summary>
        /// Specifies a 30-percent hatch, which is the ratio of foreground color to
        /// background color equal to 30:100.
        /// </summary>
        HatchStyle30Percent = 0x0000000A,

        /// <summary>
        /// Specifies a 40-percent hatch, which is the ratio of foreground color to
        /// background color equal to 40:100.
        /// </summary>
        HatchStyle40Percent = 0x0000000B,

        /// <summary>
        /// Specifies a 50-percent hatch, which is the ratio of foreground color to
        /// background color equal to 50:100.
        /// </summary>
        HatchStyle50Percent = 0x0000000C,

        /// <summary>
        /// Specifies a 60-percent hatch, which is the ratio of foreground color to
        /// background color equal to 60:100.
        /// </summary>
        HatchStyle60Percent = 0x0000000D,

        /// <summary>
        /// Specifies a 70-percent hatch, which is the ratio of foreground color to
        /// background color equal to 70:100.
        /// </summary>
        HatchStyle70Percent = 0x0000000E,

        /// <summary>
        /// Specifies a 75-percent hatch, which is the ratio of foreground color to
        /// background color equal to 75:100.
        /// </summary>
        HatchStyle75Percent = 0x0000000F,

        /// <summary>
        /// Specifies a 80-percent hatch, which is the ratio of foreground color to
        /// background color equal to 80:100.
        /// </summary>
        HatchStyle80Percent = 0x00000010,

        /// <summary>
        /// Specifies a 90-percent hatch, which is the ratio of foreground color to
        /// background color equal to 90:100.
        /// </summary>
        HatchStyle90Percent = 0x00000011,

        /// <summary>
        /// Specifies diagonal lines that slant to the right from top to bottom points with
        /// no anti-aliasing. They are spaced 50 percent further apart than lines in the
        /// HatchStyleForwardDiagonal pattern
        /// </summary>
        LightDownwardDiagonal = 0x00000012,

        /// <summary>
        /// Specifies diagonal lines that slant to the left from top to bottom points with
        /// no anti-aliasing. They are spaced 50 percent further apart than lines in the
        /// HatchStyleBackwardDiagonal pattern.
        /// </summary>
        LightUpwardDiagonal = 0x00000013,

        /// <summary>
        /// Specifies diagonal lines that slant to the right from top to bottom points with
        /// no anti-aliasing. They are spaced 50 percent closer and are twice the width of
        /// lines in the HatchStyleForwardDiagonal pattern.
        /// </summary>
        DarkDownwardDiagonal = 0x00000014,

        /// <summary>
        /// Specifies diagonal lines that slant to the left from top to bottom points with
        /// no anti-aliasing. They are spaced 50 percent closer and are twice the width of
        /// lines in the HatchStyleBackwardDiagonal pattern.
        /// </summary>
        DarkUpwardDiagonal = 0x00000015,

        /// <summary>
        /// Specifies diagonal lines that slant to the right from top to bottom points with
        /// no anti-aliasing. They have the same spacing between lines in
        /// HatchStyleWideDownwardDiagonal pattern and HatchStyleForwardDiagonal pattern, but
        /// HatchStyleWideDownwardDiagonal has the triple line width of
        /// HatchStyleForwardDiagonal.
        /// </summary>
        WideDownwardDiagonal = 0x00000016,

        /// <summary>
        /// Specifies diagonal lines that slant to the left from top to bottom points with
        /// no anti-aliasing. They have the same spacing between lines in
        /// HatchStyleWideUpwardDiagonal pattern and HatchStyleBackwardDiagonal pattern, but
        /// HatchStyleWideUpwardDiagonal has the triple line width of
        /// HatchStyleWideUpwardDiagonal.
        /// </summary>
        WideUpwardDiagonal = 0x00000017,

        /// <summary>
        /// Specifies vertical lines that are spaced 50 percent closer together than
        /// lines in the HatchStyleVertical pattern.
        /// </summary>
        LightVertical = 0x00000018,

        /// <summary>
        /// Specifies horizontal lines that are spaced 50 percent closer than lines
        /// in the HatchStyleHorizontal pattern.
        /// </summary>
        LightHorizontal = 0x00000019,

        /// <summary>
        /// Specifies vertical lines that are spaced 75 percent closer than lines in
        /// the HatchStyleVertical pattern; or 25 percent closer than lines in the
        /// HatchStyleLightVertical pattern.
        /// </summary>
        NarrowVertical = 0x0000001A,

        /// <summary>
        /// Specifies horizontal lines that are spaced 75 percent closer than lines in
        /// the HatchStyleHorizontal pattern; or 25 percent closer than lines in the
        /// HatchStyleLightHorizontal pattern.
        /// </summary>
        NarrowHorizontal = 0x0000001B,

        /// <summary>
        /// Specifies lines that are spaced 50 percent closer than lines in the
        /// HatchStyleVertical pattern.
        /// </summary>
        DarkVertical = 0x0000001C,

        /// <summary>
        /// Specifies lines that are spaced 50 percent closer than lines in the
        /// HatchStyleHorizontal pattern.
        /// </summary>
        DarkHorizontal = 0x0000001D,

        /// <summary>
        /// Specifies dashed diagonal lines that slant to the right from
        /// top to bottom points.
        /// </summary>
        DashedDownwardDiagonal = 0x0000001E,

        /// <summary>
        /// Specifies dashed diagonal lines that slant to the left from top
        /// to bottom points.
        /// </summary>
        DashedUpwardDiagonal = 0x0000001F,

        /// <summary>
        /// Specifies dashed horizontal lines.
        /// </summary>
        DashedHorizontal = 0x00000020,

        /// <summary>
        /// Specifies dashed vertical lines.
        /// </summary>
        DashedVertical = 0x00000021,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of confetti.
        /// </summary>
        SmallConfetti = 0x00000022,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of confetti, and is
        /// composed of larger pieces than the HatchStyleSmallConfetti pattern.
        /// </summary>
        LargeConfetti = 0x00000023,

        /// <summary>
        /// Specifies horizontal lines that are composed of zigzags.
        /// </summary>
        ZigZag = 0x00000024,

        /// <summary>
        /// Specifies horizontal lines that are composed of tildes.
        /// </summary>
        Wave = 0x00000025,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of layered bricks
        /// that slant to the left from top to bottom points.
        /// </summary>
        DiagonalBrick = 0x00000026,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of horizontally
        /// layered bricks.
        /// </summary>
        HorizontalBrick = 0x00000027,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a woven material.
        /// </summary>
        Weave = 0x00000028,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a plaid material.
        /// </summary>
        Plaid = 0x00000029,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of divots.
        /// </summary>
        Divot = 0x0000002A,

        /// <summary>
        /// Specifies crossing horizontal and vertical lines, each of which is composed of
        /// dots.
        /// </summary>
        DottedGrid = 0x0000002B,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of diagonally layered
        /// shingles that slant to the right from top to bottom points.
        /// </summary>
        DottedDiamond = 0x0000002C,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of diagonally layered
        /// shingles that slant to the right from top to bottom points.
        /// </summary>
        Shingle = 0x0000002D,
        
        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a trellis.
        /// </summary>
        Trellis = 0x0000002E,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of spheres laid adjacent to
        /// each other.
        /// </summary>
        Sphere = 0x0000002F,

        /// <summary>
        /// Specifies crossing horizontal and vertical lines that are spaced 50 percent
        /// closer together than HatchStyleLargeGrid.
        /// </summary>
        SmallGrid = 0x00000030,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a checkerboard.
        /// </summary>
        SmallCheckerBoard = 0x00000031,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a checkerboard, with
        /// squares that are twice the size of the squares in the
        /// HatchStyleSmallCheckerBoard pattern.
        /// </summary>
        LargeCheckerBoard = 0x00000032,

        /// <summary>
        /// Specifies crossing forward and backward diagonal lines; the lines are not
        /// anti-aliased.
        /// </summary>
        OutlinedDiamond = 0x00000033,

        /// <summary>
        /// Specifies a pattern of lines that has the appearance of a checkerboard placed
        /// diagonally.
        /// </summary>
        SolidDiamond = 0x00000034
    }
}
