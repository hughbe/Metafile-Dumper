using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a sequence of connected Bezier curves.
    /// [MS-EMFPLUS] 2.3.4.3
    /// </summary>
    public class EmfPlusDrawBeziers : EmfPlusRecord
    {
        public EmfPlusDrawBeziers(MetafileReader reader) : base(reader)
        {
            Count = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, RelativeLocations, DataCompressed, Count);
        }

        public override string Name => "EmfPlusDrawBeziers";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | X | X | P | X | X | X |           Object Id           |
        /// <summary>
        /// If set, PointData specifies absolute locations in the coordinate space with
        /// 16-bit integer coordinates.
        /// If clear, PointData specifies absolute locations in the coordinate space with
        /// 32-bit floating-point coordinates.
        /// Note: If the P flag (below) is set, this flag is undefined and MUST be ignored
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
        /// Bezier curves.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points in the PointData
        /// array.
        /// At least 4 points MUST be specified.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of Count points that specify the starting, ending, and control points
        /// of the Bezier curves.
        /// The ending coordinate of one Bezier curve is the starting coordinate of the next.
        /// The control points are used for producing the Bezier effect.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Count",   4);

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
