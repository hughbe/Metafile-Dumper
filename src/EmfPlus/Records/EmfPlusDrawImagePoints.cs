using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a scaled image inside a parallelogram.
    /// [MS-EMFPLUS] 2.3.4.9
    /// </summary>
    public class EmfPlusDrawImagePoints : EmfPlusRecord
    {
        public EmfPlusDrawImagePoints(MetafileReader reader) : base(reader)
        {
            ImageAttributesId = reader.ReadUInt32();
            SrcUnit = (UnitType)reader.ReadInt32();
            SrcRect = new EmfPlusRectF(reader);
            Count = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, RelativeLocations, DataCompressed, Count);
        }

        public override string Name => "EmfPlusDrawImagePoints";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | E | X | P | X | X | X |           Object Id           |
        /// <summary>
        /// If set, PointData specifies absolute locations in the coordinate space with
        /// 16-bit integer coordinates.
        /// If clear, PointData specifies absolute locations in the coordinate space with
        /// 32-bit floating-point coordinates.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// If set, an object of the Effect class MUST have been specified in an earlier
        /// EmfPlusSerializableObject record.
        /// </summary>
        public bool HasEffect => (Flags & 0b0010000000000000) != 0;

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
        /// The index of an EmfPlusImage object in the EMF+ Object Table, which
        /// specifies the image to render.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public int ImageId => Flags & 0b11111111;

        /// <summary>
        /// A 32-bit unsigned integer that contains the index of the optional
        /// EmfPlusImageAttributes object in the EMF+ Object Table.
        /// </summary>
        public uint ImageAttributesId { get; }

        /// <summary>
        /// A 32-bit signed integer that defines the units of the SrcRect field.
        /// It MUST be the UnitPixel value of the UnitType enumeration.
        /// </summary>
        public UnitType SrcUnit { get; }

        /// <summary>
        /// An EmfPlusRectF object that defines a portion of the image to be rendered.
        /// </summary>
        public EmfPlusRectF SrcRect { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points in the PointData
        /// array.
        /// Exactly 3 points MUST be specified.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of Count points that specify three points of a parallelogram.
        /// The three points represent the upper-left, upper-right, and lower-left
        /// corners of the parallelogram.
        /// The fourth point of the parallelogram is extrapolated from the first three.
        /// The portion of the image specified by the SrcRect field SHOULD have scaling
        /// and shearing transforms applied if necessary to fit inside the parallelogram.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Image Attributes Id", 4);
            yield return new RecordValues("Source Unit",         4);

            foreach (RecordValues values in SrcRect.GetValues())
            {
                yield return values;
            }

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
