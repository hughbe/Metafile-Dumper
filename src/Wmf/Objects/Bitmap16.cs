using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Specifies information about the dimensions and color format of a bitmap.
    /// [MS-WMF] 2.2.2.1
    /// </summary>
    public class Bitmap16 : ObjectBase
    {
        public Bitmap16(MetafileReader reader)
        {
            Type = reader.ReadInt16();
            Width = reader.ReadInt16();
            Height = reader.ReadInt16();
            WidthBytes = reader.ReadInt16();
            NumberOfPlanes = reader.ReadByte();
            BitsPerPixel = reader.ReadByte();
            Bits = Utilities.ReadBytes(reader, DataSize);
        }

        public override uint Size => 10 + DataSize;

        private uint DataSize
        {
            get
            {
                if (Width > 0 && Height > 0 && BitsPerPixel > 0)
                {
                    return ((((uint)Width * BitsPerPixel + 15) >> 4) << 1) * (uint)Height;
                }

                return 0;
            }
        }

        /// <summary>
        /// A 16-bit signed integer that defines the bitmap type.
        /// </summary>
        public short Type { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the width of the bitmap in pixels.
        /// </summary>
        public short Width { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the height of the bitmap in scan lines.
        /// </summary>
        public short Height { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the number of bytes per scan line.
        /// </summary>
        public short WidthBytes { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the number of color planes in the bitmap.
        /// The value of this field MUST be 0x01.
        /// </summary>
        public byte NumberOfPlanes { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the number of adjacent color bits on each
        /// plane.
        /// </summary>
        public byte BitsPerPixel { get; }

        /// <summary>
        /// A variable length array of bytes that defines the bitmap pixel data.
        /// </summary>
        public IEnumerable<byte> Bits { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Type",             2);
            yield return new RecordValues("Width",            2);
            yield return new RecordValues("Height",           2);
            yield return new RecordValues("Width Bytes",      2);
            yield return new RecordValues("Number of Planes", 1);
            yield return new RecordValues("Bits per Pixel",   1);
            yield return new RecordValues("Bits",             DataSize);
        }
    }
}
