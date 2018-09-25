using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies text layout, display manipulations, and language identification.
    /// [MS-EMFPLUS] Section 2.2.1.9
    /// </summary>
    public class EmfPlusStringFormat : EmfPlusObjectData
    {
        public EmfPlusStringFormat(MetafileReader reader, uint size) : base(reader, size)
        {
            Flags = (StringFormatFlags)reader.ReadUInt32();
            Language = reader.ReadUInt32();
            Align = (StringAlignment)reader.ReadUInt32();
            LineAlign = (StringAlignment)reader.ReadUInt32();
            DigitSubstitution = (StringDigitSubstitution)reader.ReadUInt32();
            DigitLanguage = reader.ReadUInt32();
            FirstTabOffset = reader.ReadSingle();
            HotkeyPrefix = (HotkeyPrefix)reader.ReadInt32();
            LeadingMargin = reader.ReadSingle();
            TrailingMargin = reader.ReadSingle();
            Tracking = reader.ReadSingle();
            Trimming = (StringTrimming)reader.ReadInt32();
            TabStopCount = reader.ReadInt32();
            RangeCount = reader.ReadInt32();
            Data = new EmfPlusStringFormatData(reader, TabStopCount, RangeCount);
        }

        public override ObjectType ObjectType => ObjectType.StringFormat;

        /// <summary>
        /// A 32-bit unsigned integer that specifies text layout options for formatting,
        /// clipping and font handling.
        /// This value MUST be composed of StringFormat flags.
        /// </summary>
        public StringFormatFlags Flags { get; }

        /// <summary>
        /// An EmfPlusLanguageIdentifier object that specifies the language to use for the
        /// string. 
        /// </summary>
        public uint Language { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies how to align the string horizontally
        /// in the layout rectangle.
        /// This value MUST be defined in the StringAlignment enumeration.
        /// </summary>
        public StringAlignment Align { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies how to align the string vertically in
        /// the layout rectangle.
        /// This value MUST be defined in the StringAlignment enumeration.
        /// </summary>
        public StringAlignment LineAlign { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies how to substitute numeric digits in
        /// the string according to a locale or language.
        /// This value MUST be defined in the StringDigitSubstitution enumeration.
        /// </summary>
        public StringDigitSubstitution DigitSubstitution { get; }

        /// <summary>
        /// An EmfPlusLanguageIdentifier object that specifies the language to use for
        /// numeric digits in the string. For example, if this string contains Arabic
        /// digits, this field MUST contain a language identifier that specifies an
        /// Arabic language.
        /// </summary>
        public uint DigitLanguage { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the number of spaces between
        /// the beginning of a text line and the first tab stop.
        /// </summary>
        public float FirstTabOffset { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the type of processing that is performed
        /// on a string when a keyboard shortcut prefix(that is, an ampersand) is encountered.
        /// Basically, this field specifies whether to display keyboard shortcut prefixes
        /// that relate to text.
        /// The value MUST be defined in the HotkeyPrefix enumeration.
        /// </summary>
        public HotkeyPrefix HotkeyPrefix { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the length of the space to add
        /// to the starting position of a string.
        /// The default is 1/6 inch; for typographic fonts, the default value is 0.
        /// </summary>
        public float LeadingMargin { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the length of the space to leave
        /// following a string.
        /// The default is 1/6 inch; for typographic fonts, the default value is 0.
        /// </summary>
        public float TrailingMargin { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the ratio of the horizontal space
        /// allotted to each character in a specified string to the font-defined width
        /// of the character.Large values for this property specify ample space between
        /// characters; values less than 1 can produce character overlap.
        /// The default is 1.03; for typographic fonts, the default value is 1.00.
        /// </summary>
        public float Tracking { get; }

        /// <summary>
        /// Specifies how to trim characters from a string that is too large to fit into a
        /// layout rectangle.
        /// This value MUST be defined in the StringTrimming enumeration.
        /// </summary>
        public StringTrimming Trimming { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the number of tab stops defined in
        /// the StringFormatData field.
        /// </summary>
        public int TabStopCount { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the number of EmfPlusCharacterRange
        /// object defined in the StringFormatData field.
        /// </summary>
        public int RangeCount { get; }

        /// <summary>
        /// An EmfPlusStringFormatData object that specifies optional text layout data.
        /// </summary>
        public EmfPlusStringFormatData Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",            4);
            yield return new RecordValues("Flags",              4);
            yield return new RecordValues("Language",           4);
            yield return new RecordValues("Align",              4);
            yield return new RecordValues("Line Align",         4);
            yield return new RecordValues("Digit Substitution", 4);
            yield return new RecordValues("Digit Language",     4);
            yield return new RecordValues("First Tab Offset",   4);
            yield return new RecordValues("Hotkey Prefix",      4);
            yield return new RecordValues("Leading Margin",     4);
            yield return new RecordValues("Trailing Margin",    4);
            yield return new RecordValues("Trailing",           4);
            yield return new RecordValues("Trimming",           4);
            yield return new RecordValues("Tab Stop Count",     4);
            yield return new RecordValues("Range Count",        4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
