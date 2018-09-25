using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Contains information about the dimensions and color format of a
    /// device-independent bitmap (DIB).
    /// [MS-WMF] 2.2.2.3
    /// </summary>
    public class BitmapInfoHeader : ObjectBase
    {
        public BitmapInfoHeader(MetafileReader reader)
        {
            HeaderSize = reader.ReadUInt32();
            Width = reader.ReadInt32();
            Height = reader.ReadInt32();
            NumberOfPlanes = reader.ReadUInt16();
            BitsPerPixel = (BitCount)reader.ReadUInt16();
            Compression = (Compression)reader.ReadUInt32();
            PixelsPerMeterX = reader.ReadInt32();
            PixelsPerMeterY = reader.ReadInt32();
            ColorsUsed = reader.ReadUInt32();
            ColorsImportant = reader.ReadUInt32();
        }

        public override uint Size => 40;

        /// <summary>
        /// A 32-bit unsigned integer that defines the size of this object, in bytes.
        /// </summary>
        public uint HeaderSize { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the width of the DIB, in pixels.
        /// This value MUST be positive.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the height of the DIB, in pixels.
        /// This value MUST NOT be zero.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the number of planes for the target device.
        /// This value MUST be 0x0001.
        /// </summary>
        public ushort NumberOfPlanes { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the format of each pixel, and the
        /// maximum number of colors in the DIB.
        /// This value MUST be in the BitCount Enumeration (section 2.1.1.3).
        /// </summary>
        public BitCount BitsPerPixel { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the compression mode of the DIB.
        /// This value MUST be in the Compression Enumeration(section 2.1.1.7).
        /// This value MUST NOT specify a compressed format if the DIB is a top-down
        /// bitmap, as indicated by the Height value
        /// </summary>
        public Compression Compression { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the size, in bytes, of the image.
        /// If the Compression value is BI_RGB, this value SHOULD be zero and MUST
        /// be ignored.
        /// If the Compression value is BI_JPEG or BI_PNG, this value MUST specify the
        /// size  of the JPEG or PNG image buffer, respectively.
        /// </summary>
        public uint ImageSize { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the horizontal resolution, in
        /// pixels-per-meter, of the target device for the DIB.
        /// </summary>
        public int PixelsPerMeterX { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the vertical resolution, in
        /// pixels-per-meter, of the target device for the DIB.
        /// </summary>
        public int PixelsPerMeterY { get; }

        /// <summary>
        ///  32-bit unsigned integer that specifies the number of indexes in the color
        ///  table used by the DIB.
        ///  If this value is zero, the DIB uses the maximum number of colors that
        ///  correspond to the BitCount value.
        ///  If this value is nonzero and the BitCount value is less than 16, this value
        ///  specifies the number of colors used by the DIB.
        ///  If this value is nonzero and the BitCount value is 16 or greater, this value
        ///  specifies the size of the color table used to optimize performance of the
        ///  system palette.
        /// </summary>
        public uint ColorsUsed { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the number of color indexes that are
        /// required for displaying the DIB.
        /// If this value is zero, all color indexes are required.
        /// </summary>
        public uint ColorsImportant { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Header Size",       4);
            yield return new RecordValues("Width",             4);
            yield return new RecordValues("Height",            4);
            yield return new RecordValues("Number of Planes",  2);
            yield return new RecordValues("Bits per Pixel",    2);
            yield return new RecordValues("Compression",       4);
            yield return new RecordValues("Size",              4);
            yield return new RecordValues("Pixels Per MeterX", 4);
            yield return new RecordValues("Pixels Per MeterY", 4);
            yield return new RecordValues("Colors Used",       4);
            yield return new RecordValues("Colors Important",  4);
        }
    }
}
