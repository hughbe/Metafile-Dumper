using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Specifies a logical color space for the playback device context, which can
    /// be the name of a color profile in ASCII characters.
    /// [MS-WMF] 2.2.2.11
    /// </summary>
    public class LogColorSpace : ObjectBase
    {
        public LogColorSpace(MetafileReader reader)
        {
            Signature = reader.ReadUInt32();
            Version = reader.ReadUInt32();
            Size = reader.ReadUInt32();
            ColorSpace = (LogicalColorSpace)reader.ReadInt32();
            Intent = (GamutMappingIntent)reader.ReadInt32();
            Endpoints = new CIEXYZTriple(reader);
            GammaRed = reader.ReadUInt32();
            GammaBlue = reader.ReadUInt32();
            GammaGreen = reader.ReadUInt32();
            FileName = Utilities.GetAnsiString(reader, Size - 68);
        }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the signature of color space objects;
        /// it MUST be set to the value 0x50534F43, which is the ASCII encoding of the
        /// string "PSOC".
        /// </summary>
        public uint Signature { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines a version number;
        /// it MUST be 0x00000400.
        /// </summary>
        public uint Version { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the size of this object, in bytes.
        /// </summary>
        public override uint Size { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the color space type.
        /// It MUST be defined in the LogicalColorSpace Enumeration(section 2.1.1.14).
        /// If this value is LCS_sRGB or LCS_WINDOWS_COLOR_SPACE, the sRGB color space
        /// MUST be used.
        /// </summary>
        public LogicalColorSpace ColorSpace { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the gamut mapping intent.
        /// It MUST be defined in the GamutMappingIntent Enumeration(section 2.1.1.11).
        /// </summary>
        public GamutMappingIntent Intent { get; }

        /// <summary>
        /// A CIEXYZTriple Object (section 2.2.2.7) that defines the CIE chromaticity x, y,
        /// and z coordinates of the three colors that correspond to the RGB endpoints for
        /// the logical color space associated with the bitmap.
        /// If the ColorSpaceType field does not specify LCS_CALIBRATED_RGB, this field
        /// MUST be ignored.
        /// </summary>
        public CIEXYZTriple Endpoints { get; }

        /// <summary>
        /// A 32-bit fixed point value that defines the toned response curve for red.
        /// If the ColorSpaceType field does not specify LCS_CALIBRATED_RGB, this field
        /// MUST be ignored.
        /// </summary>
        public uint GammaRed { get; }

        /// <summary>
        /// A 32-bit fixed point value that defines the toned response curve for green.
        /// If the ColorSpaceType field does not specify LCS_CALIBRATED_RGB, this field
        /// MUST be ignored.
        /// </summary>
        public uint GammaGreen { get; }

        /// <summary>
        /// A 32-bit fixed point value that defines the toned response curve for blue.
        /// If the ColorSpaceType field does not specify LCS_CALIBRATED_RGB, this field
        /// MUST be ignored.
        /// </summary>
        public uint GammaBlue { get; }

        /// <summary>
        /// An optional, ASCII charactger string that specifies the name of a file that
        /// contains a color profile.If a file name is specified, and the ColorSpaceType
        /// field is set to LCS_CALIBRATED_RGB, the other fields of this structure
        /// SHOULD be ignored.
        /// </summary>
        public string FileName { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Signature",   4);
            yield return new RecordValues("Version",     4);
            yield return new RecordValues("Size",        4);
            yield return new RecordValues("Color Space", 4);
            yield return new RecordValues("Intent",      4);
            yield return new RecordValues("Endpoints",   36);
            yield return new RecordValues("Gamma Red",   4);
            yield return new RecordValues("Gamma Green", 4);
            yield return new RecordValues("Gamma Blue",  4);
            yield return new RecordValues("Filename",    Size - 68);
        }
    }
}
