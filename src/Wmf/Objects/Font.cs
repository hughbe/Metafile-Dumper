using System.Collections.Generic;
using MetafileDumper.Wmf.Data;
using MetafileDumper.Wmf.Enumerations;
using MetafileDumper.Wmf.Flags;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Specifies properties that determine the appearance of text, including
    /// typeface, size, and style.
    /// [MS-WMF] 2.2.2
    /// </summary>
    public class Font : ObjectBase
    {
        public Font(MetafileReader reader)
        {
            Height = reader.ReadInt16();
            Width = reader.ReadInt16();
            Escapement = reader.ReadInt16();
            Orientation = reader.ReadInt16();
            Weight = reader.ReadInt16();
            Italic = reader.ReadByte() != 0;
            Underline = reader.ReadByte() != 0;
            StrikeOut = reader.ReadByte() != 0;
            CharSet = (CharacterSet)reader.ReadByte();
            OutPrecision = (OutPrecision)reader.ReadByte();
            ClipPrecision = (ClipPrecisionFlags)reader.ReadByte();
            Quality = (FontQuality)reader.ReadByte();
            PitchAndFamily = new PitchAndFamily(reader);
            FaceName = Utilities.GetString(reader, 32);
        }

        public override uint Size => 18 + (uint)FaceName.Length;

        /// <summary>
        /// A 16-bit signed integer that specifies the height, in logical units, of the
        /// font's character cell.
        /// The character height is computed as the character cell height minus the
        /// internal leading.
        /// </summary>
        public short Height { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the average width, in logical units, of
        /// characters in the font.
        /// If Width is 0x0000, the aspect ratio of the device SHOULD be matched against
        /// the digitization aspect ratio of the available fonts to find the closest match,
        /// determined by the absolute value of the difference.
        /// </summary>
        public short Width { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the angle, in tenths of degrees, between
        /// the escapement vector and the x-axis of the device.
        /// The escapement vector is parallel to the base line of a row of text. 
        /// </summary>
        public short Escapement { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the angle, in tenths of degrees, between
        /// each character's base line and the x-axis of the device.
        /// </summary>
        public short Orientation { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the weight of the font in the range 0 through
        /// 1000.
        /// For example, 400 is normal and 700 is bold.If this value is 0x0000, a default
        /// weight SHOULD be used.
        /// </summary>
        public short Weight { get; }

        /// <summary>
        /// A 8-bit Boolean value that specifies the italic attribute of the font.
        /// </summary>
        public bool Italic { get; }

        /// <summary>
        /// An 8-bit Boolean value that specifies the underline attribute of the font.
        /// </summary>
        public bool Underline { get; }

        /// <summary>
        ///  An 8-bit Boolean value that specifies the strikeout attribute of the font.
        /// </summary>
        public bool StrikeOut { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the character set.
        /// It SHOULD be set to a value in the CharacterSet Enumeration(section 2.1.1.5).
        /// The DEFAULT_CHARSET value MAY be used to allow the name and size of a font
        /// to fully describe the logical font.If the specified font name does not
        /// exist, a font in another character set MAY be substituted.
        /// The DEFAULT_CHARSET value is set to a value based on the current system locale.
        /// For example, when the system locale is United States, it is set to ANSI_CHARSET.
        /// If a typeface name in the FaceName field is specified, the CharSet value MUST
        /// match the character set of that typeface.
        /// </summary>
        public CharacterSet CharSet { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the output precision.
        /// The output precision defines how closely the output matches the requested font
        /// height, width, character orientation, escapement, pitch, and font type.
        /// It MUST be one of the values from the OutPrecision Enumeration (section 2.1.1.21).
        /// Applications can use the OUT_DEVICE_PRECIS, OUT_RASTER_PRECIS, OUT_TT_PRECIS, and
        /// OUT_PS_ONLY_PRECIS values to control how the font mapper selects a font when the
        /// operating system contains more than one font with a specified name.
        /// For example, if an operating system contains a font named "Symbol" in raster and
        /// TrueType forms, specifying OUT_TT_PRECIS forces the font mapper to select the
        /// TrueType version.
        /// Specifying OUT_TT_ONLY_PRECIS forces the font mapper to select a TrueType font,
        /// even if it substitutes a TrueType font of another name.
        /// </summary>
        public OutPrecision OutPrecision { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the clipping precision.
        /// The clipping precision defines how to clip characters that are partially
        /// outside the clipping region.
        /// It MUST be a combination of one or more of the bit settings in the
        /// ClipPrecision Flags(section 2.1.2.1).
        /// </summary>
        public ClipPrecisionFlags ClipPrecision { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the output quality.
        /// The output quality defines how carefully to attempt to match the logical
        /// font attributes to those of an actual physical font.
        /// It MUST be one of the values in the FontQuality Enumeration (section 2.1.1.10).
        /// </summary>
        public FontQuality Quality { get; }

        /// <summary>
        /// A PitchAndFamily Object (section 2.2.2.14) that defines the pitch and the
        /// family of the font.
        /// Font families specify the look of fonts in a general way and are intended for
        /// specifying fonts when the exact typeface wanted is not available.
        /// </summary>
        public PitchAndFamily PitchAndFamily { get; }

        /// <summary>
        /// A null-terminated string of 8-bit Latin-1 [ISO/IEC-8859-1] ANSI characters
        /// that specifies the typeface name of the font.
        /// The length of this string MUST NOT exceed 32 8-bit characters, including
        /// the terminating null.
        /// </summary>
        public string FaceName { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Height",         2);
            yield return new RecordValues("Width",          2);
            yield return new RecordValues("Escapement",     2);
            yield return new RecordValues("Orientation",    2);
            yield return new RecordValues("Weight",         2);
            yield return new RecordValues("Italic",         1);
            yield return new RecordValues("Underline",      1);
            yield return new RecordValues("StrikeOut",      1);
            yield return new RecordValues("Char Set",       1);
            yield return new RecordValues("Out Precision",  1);
            yield return new RecordValues("Clip Precision", 1);
            yield return new RecordValues("Quality",        1);
            yield return new RecordValues("PitchAndFamily", 1);
            yield return new RecordValues("Face Name",      32);
        }
    }
}
