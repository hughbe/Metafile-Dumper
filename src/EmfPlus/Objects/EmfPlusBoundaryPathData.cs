using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a path boundary for a gradient brush.
    /// [MS-EMFPLUS] 2.2.2.6
    /// </summary>
    public class EmfPlusBoundaryPathData : ObjectBase
    {
        public EmfPlusBoundaryPathData(MetafileReader reader)
        {
            DataSize = reader.ReadUInt32();
            Data = new EmfPlusPath(reader, DataSize);
        }

        public override uint Size => 4 + DataSize;

        /// <summary>
        /// A 32-bit signed integer that specifies the size in bytes of the
        /// BoundaryPathData field.
        /// </summary>
        public uint DataSize { get; }

        /// <summary>
        /// An EmfPlusPath object, which specifies the boundary of the brush.
        /// </summary>
        public EmfPlusPath Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Size", 4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
