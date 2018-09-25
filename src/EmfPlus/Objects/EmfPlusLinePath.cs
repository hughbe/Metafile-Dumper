using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics path for outlining a custom line cap.
    /// [MS-EMFPLUS] 2.2.2.26 
    /// </summary>
    public class EmfPlusLinePath : ObjectBase
    {
        public EmfPlusLinePath(MetafileReader reader)
        {
            DataSize = reader.ReadUInt32();
            Data = new EmfPlusPath(reader, DataSize);
        }

        public override uint Size => 4 + DataSize;

        /// <summary>
        /// A 32-bit signed integer that defines the length in bytes of the LinePath field.
        /// </summary>
        public uint DataSize { get; }

        /// <summary>
        /// An EmfPlusPath object that defines the outline.
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
