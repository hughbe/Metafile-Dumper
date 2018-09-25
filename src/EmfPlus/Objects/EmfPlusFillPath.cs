using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics path for filling a custom line cap.
    /// [MS-EMFPLUS] 2.2.2.17
    /// </summary>
    public class EmfPlusFillPath : ObjectBase
    {
        public EmfPlusFillPath(MetafileReader reader)
        {
            DataSize = reader.ReadUInt32();
            Data = new EmfPlusPath(reader, DataSize);
        }

        public override uint Size => 4 + DataSize;

        /// <summary>
        /// A 32-bit signed integer that specifies the length in bytes of the FillPath
        /// field.
        /// </summary>
        public uint DataSize { get; }

        /// <summary>
        /// An EmfPlusPath, which specifies the area to fill.
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
