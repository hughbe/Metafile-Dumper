using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies filling the interior of a polygon.
    /// [MS-EMFPLUS] 2.3.4.19
    /// </summary>
    public class EmfPlusFillPolygon : EmfPlusRecord
    {
        public EmfPlusFillPolygon(MetafileReader reader) : base(reader)
        {
            BrushIdOrColor = reader.ReadUInt32();
            Count = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, RelativeLocations, DataCompressed, Count);
        }

        public override string Name => "EmfPlusFillPolygon";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // S | C | X | X | P | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, BrushId specifies a color as an EmfPlusARGB object.
        /// If clear, BrushId contains the index of an EmfPlusBrush object in the
        /// EMF+ Object Table.
        /// </summary>
        public bool BrushIdFieldIsColor => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// If set, PointData specifies absolute locations in the coordinate space with
        /// 16-bit integer coordinates.
        /// If clear, PointData specifies absolute locations in the coordinate space with
        /// 32- bit floating-point coordinates.
        /// Note: If the P flag (below) is set, this flag is undefined and MUST be ignored.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// If set, each element in PointData specifies a location in the coordinate space that
        /// is relative to the location specified by the previous element in the array.
        /// In the case of the first element in PointData, a previous location at
        /// coordinates (0,0) is assumed.
        /// If clear, PointData specifies absolute locations according to the C flag.
        /// Note: If this flag is set, the C flag (above) is undefined and MUST be ignored
        /// </summary>
        public bool RelativeLocations => (Flags & 0b0000100000000000) != 0;

        /// <summary>
        /// A 32-bit unsigned integer that defines the brush, the content of which is
        /// determined by the S bit in the Flags field.
        /// </summary>
        public uint BrushIdOrColor { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points in the PointData
        /// field.At least 3 points MUST be specified.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of Count points that define the vertices of the polygon. The first two
        /// points in the array specify the first side of the polygon.
        /// Each additional point specifies a new side, the vertices of which include the
        /// point and the previous point.If the last point and the first point do not
        /// coincide, they specify the last side of the polygon.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            if (BrushIdFieldIsColor)
            {
                yield return new RecordValues("Brush Color", 4);
            }
            else
            {
                yield return new RecordValues("Brush ID",    4);
            }

            yield return new RecordValues("Count",           4);

            int i = 0;
            foreach (EmfPlusPointBase point in Points)
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
