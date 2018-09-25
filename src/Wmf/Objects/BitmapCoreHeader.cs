using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Specifies information about the dimensions and color format of a bitmap.
    /// [MS-WMF] 2.2.2.2
    /// </summary>
    public class BitmapCoreHeader : ObjectBase
    {
        public BitmapCoreHeader(MetafileReader reader)
        {
            HeaderSize = reader.ReadUInt32();
            Width = reader.ReadUInt16();
            Height = reader.ReadUInt16();
            NumberOfPlanes = reader.ReadUInt16();
            BitsPerPixel = (BitCount)reader.ReadUInt16();
        }

        public override uint Size => 12;

        /// <summary>
        /// A 32-bit unsigned integer that defines the size of this object, in bytes.
        /// </summary>
        public uint HeaderSize { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the width of the DIB, in pixels.
        /// </summary>
        public ushort Width { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the height of the DIB, in pixels.
        /// </summary>
        public ushort Height { get; }

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

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Header Size",      4);
            yield return new RecordValues("Width",            2);
            yield return new RecordValues("Height",           2);
            yield return new RecordValues("Number of Planes", 2);
            yield return new RecordValues("Bits per Pixel",   2);
        }
    }
}
