using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics image in the form of a bitmap or metafile.
    /// [MS-EMFPLUS] 2.2.1.4
    public class EmfPlusImage : EmfPlusObjectData
    {
        public EmfPlusImage(MetafileReader reader, uint size) : base(reader, size)
        {
            Type = (ImageDataType)reader.ReadUInt32();
            Data = EmfPlusImageData.GetImageData(reader, Type, size - 8);
        }

        public override ObjectType ObjectType => ObjectType.Image;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the type of data in the ImageData field.
        /// This value MUST be defined in the ImageDataType enumeration.
        /// </summary>
        public ImageDataType Type { get; }

        /// <summary>
        /// Variable-length data that defines the image data specified in the Type field.
        /// The content and format of the data can be different for every image type.
        /// </summary>
        public EmfPlusImageData Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version", 4);
            yield return new RecordValues("Type",    4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
