using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// The PointL Object defines the coordinates of a point.
    /// [MS-WMF] 2.2.2.15
    /// </summary>
    public class PointL : ObjectBase
    {
        public PointL(MetafileReader reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit signed integer that defines the horizontal (x) coordinate of the point.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the vertical (y) coordinate of the point.
        /// </summary>
        public int Y { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 4);
            yield return new RecordValues("Y", 4);
        }
    }
}
