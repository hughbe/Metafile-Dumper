using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies text output with character positions.
    /// [MS-EMFPLUS] 2.3.4.6
    /// </summary>
    public class EmfPlusDrawDriverString : EmfPlusRecord
    {
        public EmfPlusDrawDriverString(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
            OptionsFlags = (DriverStringOptionsFlags)reader.ReadUInt32();
            MatrixPresent = reader.ReadBoolean();
            GlyphCount = reader.ReadUInt32();

            var glyphs = new List<ushort>();
            for (int i = 0; i < GlyphCount; i++)
            {
                ushort glyph = reader.ReadUInt16();
                glyphs.Add(glyph);
            }
            Glyphs = glyphs;

            var positions = new List<EmfPlusPointF>();
            for (uint i = 0; i < GlyphCount; i++)
            {
                var position = new EmfPlusPointF(reader);
                positions.Add(position);
            }
            Positions = positions;

            if (MatrixPresent)
            {
                Transform = new EmfPlusTransformMatrix(reader);
            }
        }

        public override string Name => "EmfPlusDrawDriverString";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // S | X | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, BrushId specifies the color value in an EmfPlusARGB object.
        /// If clear, BrushId contains the EMF+ Object Table index of an EmfPlusBrush object.
        /// </summary>
        public bool BrushIdFieldIsColor => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// The EMF+ Object Table index of an EmfPlusFont object to render the text.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public int FontId => Flags & 0b11111111;

        /// <summary>
        /// A 32-bit unsigned integer that specifies either the foreground color of the
        /// text or a graphics brush, depending on the value of the S flag in the Flags.
        /// </summary>
        public uint BrushIdOrColor { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the spacing, orientation, and quality
        /// of rendering for the string.
        /// This value MUST be composed of DriverStringOptions flags.
        /// </summary>
        public DriverStringOptionsFlags OptionsFlags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies whether a transform matrix is
        /// present in the TransformMatrix field.
        /// </summary>
        public bool MatrixPresent { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies number of glyphs in the string.
        /// </summary>
        public uint GlyphCount { get; }

        /// <summary>
        /// An array of 16-bit values that define the text string to draw.
        /// </summary>
        public IEnumerable<ushort> Glyphs { get; }

        /// <summary>
        /// An array of EmfPlusPointF objects that specify the output position of each
        /// character glyph.
        /// There MUST be GlyphCount elements, which have a one-to-one correspondence
        /// with the elements in the Glyphs array.
        /// </summary>
        public IEnumerable<EmfPlusPointF> Positions { get; }

        /// <summary>
        /// An optional EmfPlusTransformMatrix object that specifies the transformation to
        /// apply to each value in the text array.
        /// The presence of this data is determined from the MatrixPresent field.
        /// </summary>
        public EmfPlusTransformMatrix Transform { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            if (BrushIdFieldIsColor)
            {
                yield return new RecordValues("Brush Color",  4);
            }
            else
            {
                yield return new RecordValues("Brush ID",     4);
            }

            yield return new RecordValues("Options Flags",  4);
            yield return new RecordValues("Matrix Present", 4);
            yield return new RecordValues("Glyph Count",    4);
            yield return new RecordValues("Glyphs",         GlyphCount * 2);
            yield return new RecordValues("Positions",      GlyphCount * 8);

            if (MatrixPresent)
            {
                foreach (RecordValues values in Transform.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
