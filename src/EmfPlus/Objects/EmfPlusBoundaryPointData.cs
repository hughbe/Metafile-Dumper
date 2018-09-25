using System.Collections.Generic;
using System.Linq;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a closed cardinal spline boundary for a gradient brush.
    /// [MS-EMFPLUS] 2.2.2.7
    /// </summary>
    public class EmfPlusBoundaryPointData : ObjectBase
    {
        public EmfPlusBoundaryPointData(MetafileReader reader)
        {
            PointCount = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, false, false, PointCount).Cast<EmfPlusPointF>();
        }

        public override uint Size => 4 + 8 * PointCount;

        /// <summary>
        /// A 32-bit signed integer that specifies the number of points in the
        /// BoundaryPointData field.
        /// </summary>
        public uint PointCount { get; }

        /// <summary>
        /// An array of BoundaryPointCount EmfPlusPointF objects that specify the
        /// boundary of the brush.
        /// </summary>
        public IEnumerable<EmfPlusPointF> Points { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Size", 4);

            int i = 0;
            foreach (ObjectBase point in Points)
            {
                foreach (RecordValues values in point.GetValues())
                {
                    yield return new RecordValues(values.Name + (i + 1), values.Length);
                }

                i++;
            }
        }
    }
}
