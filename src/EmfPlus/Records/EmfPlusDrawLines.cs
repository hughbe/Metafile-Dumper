using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a series of connected lines.
    /// [MS-EMFPLUS] 2.3.4.10
    /// </summary>
    public class EmfPlusDrawLines : EmfPlusRecord
    {
        public EmfPlusDrawLines(MetafileReader reader) : base(reader)
        {
            Count = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, RelativeLocations, DataCompressed, Count);
        }

        public override string Name => "EmfPlusDrawLines";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | L | X | P | X | X | X |           Object Id           |
        /// <summary>
        /// If set, PointData specifies absolute locations in the coordinate space with
        /// 16-bit integer coordinates.
        /// If clear, PointData specifies absolute locations in the coordinate space with
        /// 32-bit floating-point coordinates.
        /// Note: If the P flag (below) is set, this flag is undefined and MUST be ignored.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// This bit indicates whether to draw an extra line between the last point
        /// and the first point, to close the shape.
        /// </summary>
        public bool LinesClosed => (Flags & 0b0010000000000000) != 0;

        /// <summary>
        /// If set, each element in PointData specifies a location in the coordinate space that
        /// is relative to the location specified by the previous element in the array.
        /// In the case of the first element in PointData, a previous location at
        /// coordinates (0,0) is assumed.
        /// If clear, PointData specifies absolute locations according to the C flag.
        /// Note: If this flag is set, the C flag (above) is undefined and MUST be ignored.
        /// </summary>
        public bool RelativeLocations => (Flags & 0b0000100000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusPen object in the EMF+ Object Table to draw the
        /// lines.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points in the PointData
        /// array.
        /// At least 2 points MUST be specified.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of Count points that specify the starting and ending points of the
        /// lines to be drawn.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Count", 4);

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
