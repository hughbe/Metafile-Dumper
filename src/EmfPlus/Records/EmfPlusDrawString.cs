using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies text output with string formatting.
    /// [MS-EMFPLUS] 2.3.4.14
    /// </summary>
    public class EmfPlusDrawString : EmfPlusRecord
    {
        public EmfPlusDrawString(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
            StringFormatId = reader.ReadUInt32();
            StringLength = reader.ReadUInt32();
            LayoutRectangle = new EmfPlusRectF(reader);
            String = Utilities.GetString(reader, StringLength);

            uint padding = (StringLength * 2) % 4;
            for (uint i = 0; i < padding; i++)
            {
                reader.ReadByte();
            }
        }

        public override string Name => "EmfPlusDrawString";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // S | X | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, BrushId specifies a color as an EmfPlusARGB object.
        /// If clear, BrushId contains the index of an EmfPlusBrush object in the
        /// EMF+ Object Table.
        /// </summary>
        public bool BrushIdFieldIsColor => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusFont object in the EMF+ Object Table to render the
        /// text.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint FontId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the brush, the content of which is
        /// determined by the S bit in the Flags field.
        /// This definition is used to paint the foreground text color; that is, just
        /// the glyphs themselves.
        /// </summary>
        public uint BrushIdOrColor { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the index of an optional
        /// EmfPlusStringFormat object in the EMF+ Object Table.
        /// This object specifies text layout information and display manipulations
        /// to be applied to a string.
        /// </summary>
        public uint StringFormatId { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of characters in the string
        /// </summary>
        public uint StringLength { get; }

        /// <summary>
        /// An EmfPlusRectF object that defines the bounding area of the destination
        /// that will receive the string.
        /// </summary>
        public EmfPlusRectF LayoutRectangle { get; }

        /// <summary>
        /// An array of 16-bit Unicode characters that specifies the string to be drawn.
        /// </summary>
        public string String { get; }

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

            yield return new RecordValues("String Format Id", 4);
            yield return new RecordValues("String Length",    4);

            foreach (RecordValues values in LayoutRectangle.GetValues())
            {
                yield return values;
            }

            yield return new RecordValues("String Data",       StringLength * 2);

            uint padding = (StringLength * 2) % 4;
            if (padding != 0)
            {
                yield return new RecordValues("Padding",       4 - padding);
            }
        }
    }
}
