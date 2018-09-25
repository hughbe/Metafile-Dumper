using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines the x- and y-extents of a rectangle.
    /// [MS-WMF] 2.2.2.22
    /// </summary>
    public class SizeL : ObjectBase
    {
        public SizeL(MetafileReader reader)
        {
            Cx = reader.ReadUInt32();
            Cy = reader.ReadUInt32();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit unsigned integer that defines the x-coordinate of the point.
        /// </summary>
        public uint Cx { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the y-coordinate of the point.
        /// </summary>
        public uint Cy { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 4);
            yield return new RecordValues("Y", 4);
        }
    }
}
