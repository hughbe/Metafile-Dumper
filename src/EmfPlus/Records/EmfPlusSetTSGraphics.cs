using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the state of a graphics device context for a terminal server.
    /// [MS-EMFPLUS] 2.3.8.2
    /// </summary>
    public class EmfPlusSetTSGraphics : EmfPlusRecord
    {
        public EmfPlusSetTSGraphics(MetafileReader reader) : base(reader)
        {
            SmoothingMode = (SmoothingMode)reader.ReadByte();
            TextRenderingHint = (TextRenderingHint)reader.ReadByte();
            CompositingMode = (CompositingMode)reader.ReadByte();
            CompositingQuality = (CompositingQuality)reader.ReadByte();
            RenderOriginX = reader.ReadInt16();
            RenderOriginY = reader.ReadInt16();
            TextContrast = reader.ReadUInt16();
            FilterType = (FilterType)reader.ReadByte();
            PixelOffsetMode = (PixelOffsetMode)reader.ReadByte();
            WorldToDeviceTransform = new EmfPlusTransformMatrix(reader);
            if (HasPalette)
            {
                Palette = new EmfPlusPalette(reader);
            }
        }

        public override string Name => "EmfPlusSetTSGraphics";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X | X | X | X | X | X | X | V | T |
        /// <summary>
        /// If set, the palette contains only the basic VGA colors.
        /// </summary>
        public bool PaletteOnlyContainsBasicVGAColors => (Flags & 0b10) != 0;

        /// <summary>
        /// If set, this record contains an EmfPlusPalette object in the Palette
        /// field following the graphics state data.
        /// </summary>
        public bool HasPalette => (Flags & 0b1) != 0;

        /// <summary>
        /// An 8-bit unsigned integer that specifies the quality of line rendering,
        /// including the type of line anti-aliasing.
        /// It MUST be defined in the SmoothingMode enumeration.
        /// </summary>
        public SmoothingMode SmoothingMode { get; }

        /// <summary>
        /// An 8-bit unsigned integer that specifies the quality of text rendering,
        /// including the type of text anti-aliasing.
        /// It MUST be defined in the TextRenderingHint enumeration.
        /// </summary>
        public TextRenderingHint TextRenderingHint { get; }

        /// <summary>
        /// An 8-bit unsigned integer that specifies how source colors are
        /// combined with background colors.
        /// It MUST be a value in the CompositingMode enumeration.
        /// </summary>
        public CompositingMode CompositingMode { get; }

        /// <summary>
        /// An 8-bit unsigned integer that specifies the degree of smoothing to apply
        /// to lines, curves and the edges of filled areas to make them appear more
        /// continuous or sharply defined.
        /// It MUST be a value in the CompositingQuality enumeration.
        /// </summary>
        public CompositingQuality CompositingQuality { get; }

        /// <summary>
        /// A 16-bit signed integer, which is the horizontal coordinate of the origin for
        /// rendering halftoning and dithering matrixes.
        /// </summary>
        public short RenderOriginX { get; }

        /// <summary>
        /// A 16-bit signed integer, which is the vertical coordinate of the origin for
        /// rendering halftoning and dithering matrixes.
        /// </summary>
        public short RenderOriginY { get; }

        /// <summary>
        /// A 16-bit unsigned integer that specifies the gamma correction value used
        /// for rendering anti-aliased and ClearType text.
        /// This value MUST be in the range 0 to 12, inclusive.
        /// </summary>
        public ushort TextContrast { get; }

        /// <summary>
        /// An 8-bit unsigned integer that specifies how scaling, including stretching and
        /// shrinking, is performed.
        /// It MUST be a value in the FilterType enumeration.
        /// </summary>
        public FilterType FilterType { get; }

        /// <summary>
        /// An 8-bit unsigned integer that specifies the overall quality of the image and
        /// text-rendering process.
        /// It MUST be a value in the PixelOffsetMode enumeration.
        /// </summary>
        public PixelOffsetMode PixelOffsetMode { get; }

        /// <summary>
        /// An 192-bit EmfPlusTransformMatrix object that specifies the world space
        /// to device space transforms.
        /// </summary>
        public EmfPlusTransformMatrix WorldToDeviceTransform { get; }

        /// <summary>
        /// An optional EmfPlusPalette object.
        /// </summary>
        public EmfPlusPalette Palette { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Smoothing Mode",      1);
            yield return new RecordValues("Text Rendering Hint", 1);
            yield return new RecordValues("Compositing Mode",    1);
            yield return new RecordValues("Compositing Quality", 1);
            yield return new RecordValues("Render Origin X",     2);
            yield return new RecordValues("Render Origin Y",     2);
            yield return new RecordValues("Text Contrast",       2);
            yield return new RecordValues("Filter Type",         1);
            yield return new RecordValues("Pixel Offset Mode",   1);
            
            foreach (RecordValues values in WorldToDeviceTransform.GetValues())
            {
                yield return values;
            }

            if (Palette != null)
            {
                foreach (RecordValues values in Palette.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
