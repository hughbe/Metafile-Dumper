using MetafileDumper.Wmf.Data;
using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Contains information about the dimensions and color format of a
    /// device-independent bitmap (DIB).
    /// It is an extension of the BitmapInfoHeader Object(section 2.2.2.3).
    /// [MS-WMF] 2.2.2.3
    /// </summary>
    public class BitmapV4Header : BitmapInfoHeader
    {
        public BitmapV4Header(MetafileReader reader) : base(reader)
        {
            RedMask = reader.ReadUInt32();
            GreenMask = reader.ReadUInt32();
            BlueMask = reader.ReadUInt32();
            AlphaMask = reader.ReadUInt32();
            ColorSpace = (LogicalColorSpace)reader.ReadUInt32();
            Endpoints = new CIEXYZTriple(reader);
            GammaRed = reader.ReadUInt32();
            GammaGreen = reader.ReadUInt32();
            GammaBlue = reader.ReadUInt32();
        }

        public override uint Size => 108;

        /// <summary>
        /// A 32-bit unsigned integer that defines the color mask that specifies the red
        /// component of each pixel.
        /// If the Compression value in the BitmapInfoHeader object is not BI_BITFIELDS,
        /// this value MUST be ignored.
        /// </summary>
        public uint RedMask { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the color mask that specifies the green
        /// component of each pixel.
        /// If the Compression value in the BitmapInfoHeader object is not BI_BITFIELDS,
        /// this value MUST be ignored.
        /// </summary>
        public uint GreenMask { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the color mask that specifies the blue
        /// component of each pixel.
        /// If the Compression value in the BitmapInfoHeader object is not BI_BITFIELDS,
        /// this value MUST be ignored.
        /// </summary>
        public uint BlueMask { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the color mask that specifies the alpha
        /// component of each pixel.
        /// </summary>
        public uint AlphaMask { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the color space of the
        /// DeviceIndependentBitmap Object(section 2.2.2.9).
        /// If this value is LCS_CALIBRATED_RGB from the LogicalColorSpace Enumeration
        /// (section 2.1.1.14), the color values in the DIB are calibrated RGB values,
        /// and the endpoints and gamma values in this structure SHOULD be used to
        /// translate the color values before they are passed to the device.
        /// </summary>
        public LogicalColorSpace ColorSpace { get; }

        /// <summary>
        /// A CIEXYZTriple Object (section 2.2.2.7) that defines the CIE chromaticity x, y,
        /// and z coordinates of the three colors that correspond to the red, green, and
        /// blue endpoints for the logical color space associated with the DIB.
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

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in base.GetValues())
            {
                yield return values;
            }

            yield return new RecordValues("Red Mask" ,   4);
            yield return new RecordValues("Green Mask",  4);
            yield return new RecordValues("Blue Mask",   4);
            yield return new RecordValues("Alpha Mask",  4);
            yield return new RecordValues("Color Space", 4);
            yield return new RecordValues("Endpoints",   36);
            yield return new RecordValues("Gamma Red",   4);
            yield return new RecordValues("Gamma Green", 4);
            yield return new RecordValues("Gamma Blue",  4);
        }
    }
}
