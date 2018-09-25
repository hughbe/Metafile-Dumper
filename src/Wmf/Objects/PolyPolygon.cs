using System.Collections.Generic;
using System.Linq;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines a series of closed polygons.
    /// [MS-WMF] 2.2.2.17
    /// </summary>
    public class PolyPolygon : ObjectBase
    {
        public PolyPolygon(MetafileReader reader)
        {
            NumberOfPolygons = reader.ReadUInt16();
            PointsPerPolygon = Utilities.ReadUInt16s(reader, NumberOfPolygons);
            PolygonPoints = Utilities.GetPointSs(reader, NumberOfPolygonPoints);
        }

        public override uint Size => 4 + (uint)NumberOfPolygons * 2 + NumberOfPolygonPoints * 4;

        private uint NumberOfPolygonPoints => (uint)PointsPerPolygon.Sum(p => (uint)p);

        /// <summary>
        /// A 16-bit unsigned integer that defines the number of polygons in the object.
        /// </summary>
        public ushort NumberOfPolygons { get; }

        /// <summary>
        /// A NumberOfPolygons array of 16-bit unsigned integers that define
        /// the number of points for each polygon in the object.
        /// </summary>
        public IEnumerable<ushort> PointsPerPolygon { get; }

        /// <summary>
        /// An array of 16-bit unsigned integers that define the coordinates of the polygons.
        /// </summary>
        public IEnumerable<PointS> PolygonPoints { get; } 

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Count",              2);
            yield return new RecordValues("Points per Polygon", 2 * (uint)NumberOfPolygons);
            yield return new RecordValues("Polygon Points",     4 * NumberOfPolygonPoints);
        }
    }
}
