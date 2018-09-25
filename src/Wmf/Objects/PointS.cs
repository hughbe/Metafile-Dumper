using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines the x- and y-coordinates of a point.
    /// [MS-WMF] 2.2.2.16
    /// </summary>
    public class PointS : ObjectBase
    {
        public PointS(MetafileReader reader)
        {
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
        }

        public override uint Size => 4;

        /// <summary>
        /// A 16-bit signed integer that defines the horizontal (x) coordinate of the point.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the vertical (y) coordinate of the point.
        /// </summary>
        public int Y { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 2);
            yield return new RecordValues("Y", 2);
        }
    }
}
