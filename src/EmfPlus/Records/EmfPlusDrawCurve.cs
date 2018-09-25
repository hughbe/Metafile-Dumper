using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a cardinal spline.
    /// [MS-EMFPLUS] 2.3.4.5
    /// </summary>
    public class EmfPlusDrawCurve : EmfPlusRecord
    {
        public EmfPlusDrawCurve(MetafileReader reader) : base(reader)
        {
            Tension = reader.ReadSingle();
            Offset = reader.ReadUInt32();
            NumberOfSegments = reader.ReadUInt32();
            Count = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, RelativeLocations, DataCompressed, Count);
        }

        public override string Name => "EmfPlusDrawClosedCurve";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | X | X | P | X | X | X |           Object Id           |
        /// <summary>
        /// If set, PointData contains an array of EmfPlusPoint objects.
        /// If clear, PointData contains an array of EmfPlusPointF objects.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// If set, each element in PointData specifies a location in the coordinate space
        /// that is relative to the location specified by the previous element in the array.
        /// In the case of the first element in PointData, a previous location at
        /// coordinates (0,0) is assumed.
        /// If clear, PointData specifies absolute locations according to the C flag.
        /// Note: If this flag is set, the C flag (above) is undefined and MUST be ignored.
        /// </summary>
        public bool RelativeLocations => (Flags & 0b0000100000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusPen object in the EMF+ Object Table to draw the
        /// curve.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit floating point number that specifies how tightly the spline bends as it
        /// passes through the points.
        /// A value of 0 specifies that the spline is a sequence of straight lines.
        /// As the value increases, the curve becomes more rounded.
        /// For more information, see [SPLINE77] and [PETZOLD].
        /// </summary>
        public float Tension { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the element in the PointData array that
        /// defines the starting point of the spline.
        /// </summary>
        public uint Offset { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of line segments
        /// making up the spline.
        /// </summary>
        public uint NumberOfSegments { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points in the PointData
        /// array.
        /// The minimum number of points for drawing a curve is 2—the starting and ending
        /// points.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of either 32-bit signed integers or 32-bit floating-point numbers of
        /// Count length that defines coordinate values of the endpoints of the lines to
        /// be stroked.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Tension",            4);
            yield return new RecordValues("Offset",             4);
            yield return new RecordValues("Number of Segments", 4);
            yield return new RecordValues("Count",              4);

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
