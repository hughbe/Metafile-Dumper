using MetafileDumper.EmfPlus.Enumerations;
using System;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a series of line and curve segments.
    /// [MS-EMFPLUS] 2.2.1.6
    /// </summary>
    public class EmfPlusPath : EmfPlusObjectData
    {
        public EmfPlusPath(MetafileReader reader, uint size) : base(reader, size)
        {
            PointCount = reader.ReadUInt32();
            PointFlags = reader.ReadUInt32();
            Points = Utilities.GetPoints(reader, false, CompressedPoints, PointCount);

            var types = new List<byte>();
            for (uint i = 0; i < PointCount; i++)
            {
                byte type = reader.ReadByte();
                types.Add(type);
            }
            Types = types;

            uint padding = PointCount % 4;
            for (uint i = 0; i < padding; i++)
            {
                reader.ReadByte();
            }
        }

        public override ObjectType ObjectType => ObjectType.Path;

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30 | 31 | 32
        // ---------------------------------------------------------------
        // X | X | X | X |     CM        |           Object Id           |
        public bool Relative => (PointFlags & 0b100000000000) != 0;

        public bool CompressedPoints => (PointFlags & 0b100000000000000) != 0;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of points and
        /// associated point types that are defined by this object.
        /// </summary>
        public uint PointCount { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies how to interpret the points and
        /// associated point types that are defined by this object.
        /// </summary>
        public uint PointFlags { get; }

        /// <summary>
        /// An array of PathPointCount points that specify the path. The type of
        /// objects in this array is specified by the PathPointFlags field.
        /// </summary>
        public IEnumerable<EmfPlusPointBase> Points { get; }

        /// <summary>
        /// An array of PathPointCount objects that specifies how the points in
        /// the PathPoints field are used to draw the path.
        /// </summary>
        public IEnumerable<byte> Types { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",    4);
            yield return new RecordValues("PointCount", 4);
            yield return new RecordValues("PointFlags", 4);

            if (Relative)
            {
                throw new InvalidOperationException("Don't know how to read relative points.");
            }

            int pointsCounter = 0;
            foreach (ObjectBase rect in Points)
            {
                foreach (RecordValues values in rect.GetValues())
                {
                    yield return new RecordValues(values.Name + (pointsCounter + 1), values.Length);
                }

                pointsCounter++;
            }

            for (int i = 0; i < PointCount; i++)
            {
                yield return new RecordValues("Type " + (i + 1), 1);
            }

            uint padding = PointCount % 4;
            if (padding != 0)
            {
                yield return new RecordValues("Padding", 4 - padding);
            }
        }
    }
}
