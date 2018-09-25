using System.Collections.Generic;
using System.Linq;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Specifies line and curve segments that define a shape.
    /// [MS-WMF] 2.2.1.5
    /// </summary>
    public class Region : ObjectBase
    {
        public Region(MetafileReader reader)
        {
            NextInChain = reader.ReadUInt16();
            ObjectType = reader.ReadInt16();
            ObjectCount = reader.ReadUInt32();
            RegionCount = reader.ReadInt16();
            ScansCount = reader.ReadInt16();
            MaximumScanPointCount = reader.ReadInt16();
            BoundingRectangle = new Rect(reader);

            if (ScansCount > 0)
            {
                var scans = new Scan[ScansCount];
                for (int i = 0; i < ScansCount; i++)
                {
                    scans[i] = new Scan(reader);
                }
                Scans = scans;
            }
            else
            {
                Scans = Enumerable.Empty<Scan>();
            }
        }

        public override uint Size => 22 + (uint)Scans.Sum(s => s.Size);

        /// <summary>
        /// A value that MUST be ignored.
        /// </summary>
        public ushort NextInChain { get; }

        /// <summary>
        /// A 16-bit signed integer that specifies the region identifier. It MUST be 0x0006.
        /// </summary>
        public short ObjectType { get; }

        /// <summary>
        /// A value that MUST be ignored.
        /// </summary>
        public uint ObjectCount { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the size of the region in bytes plus the
        /// size of aScans in bytes.
        /// </summary>
        public short RegionCount { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the number of scanlines composing the
        /// region.
        /// </summary>
        public short ScansCount { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the maximum number of points in any one
        /// scan in this region
        /// </summary>
        public short MaximumScanPointCount { get; }

        /// <summary>
        /// A Rect Object (section 2.2.2.18) that defines the bounding rectangle.
        /// </summary>
        public Rect BoundingRectangle { get; }

        /// <summary>
        /// An array of Scan Objects (section 2.2.2.21) that define the scanlines in the
        /// region.
        /// </summary>
        public IEnumerable<Scan> Scans { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style", 2);
            yield return new RecordValues("Width", 4);
            yield return new RecordValues("Color", 4);
        }
    }
}
