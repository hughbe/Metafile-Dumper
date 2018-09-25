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
    public class BitmapV5Header : BitmapV4Header
    {
        public BitmapV5Header(MetafileReader reader) : base(reader)
        {
            Intent = (LogicalColorSpace)reader.ReadUInt32();
            ProfileDataOffset = reader.ReadUInt32();
            ProfileDataSize = reader.ReadUInt32();
        }

        public override uint Size => 124;

        /// <summary>
        ///  A 32-bit unsigned integer that defines the rendering intent for the DIB.
        ///  This MUST be defined in the LogicalColorSpace Enumeration(section 2.1.1.14).
        /// </summary>
        public LogicalColorSpace Intent { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the offset, in bytes, from the beginning
        /// of this structure to the start of the color profile data
        /// </summary>
        public uint ProfileDataOffset { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the size, in bytes, of embedded color
        /// profile data.
        /// </summary>
        public uint ProfileDataSize { get; }

        /// <summary>
        /// A 32-bit unsigned integer that is undefined and SHOULD be ignored.
        /// </summary>
        public uint Reserved { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in base.GetValues())
            {
                yield return values;
            }

            yield return new RecordValues("Intent",              4);
            yield return new RecordValues("Profile Data Offset", 4);
            yield return new RecordValues("Profile Data Size",   4);
            yield return new RecordValues("Reserved",            4);
        }
    }
}
