using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines the pixel color values in an uncompressed DIB Object (section 2.2.2.9).
    /// [MS-WMF] 2.2.2.20
    /// </summary>
    public class RGBQuad : ObjectBase
    {
        public RGBQuad(MetafileReader reader)
        {
            Blue = reader.ReadByte();
            Green = reader.ReadByte();
            Red = reader.ReadByte();
            Reserved = reader.ReadByte();
        }

        public override uint Size => 4;

        /// <summary>
        /// An 8-bit unsigned integer that defines the relative intensity of blue.
        /// </summary>
        public byte Blue { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the relative intensity of green.
        /// </summary>
        public byte Green { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the relative intensity of red.
        /// </summary>
        public byte Red { get; }

        /// <summary>
        /// An 8-bit unsigned integer that MUST be 0x00.
        /// </summary>
        public byte Reserved { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Blue",     1);
            yield return new RecordValues("Green",    1);
            yield return new RecordValues("Red",      1);
            yield return new RecordValues("Reserved", 1);
        }
    }
}
