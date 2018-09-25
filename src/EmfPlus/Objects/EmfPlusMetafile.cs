using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a metafile that contains a graphics image.
    /// [MS-EMFPLUS] 2.2.2.27
    /// </summary>
    public class EmfPlusMetafile : EmfPlusImageData
    {
        public EmfPlusMetafile(MetafileReader reader, uint size) : base(size)
        {
            Type = (MetafileDataType)reader.ReadUInt32();
            DataSize = reader.ReadUInt32();

            for (uint i = 0; i < DataSize; i++)
            {
                reader.ReadByte();
            }
        }

        public override ImageDataType ImageType => ImageDataType.Metafile;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the type of metafile that is embedded
        /// in the MetafileData field.
        /// This value MUST be defined in the MetafileDataType enumeration.
        /// </summary>
        public MetafileDataType Type { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the size in bytes of the metafile
        /// data in the MetafileData field.
        /// </summary>
        public uint DataSize { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Type",      4);
            yield return new RecordValues("Data Size", 4);
            yield return new RecordValues("Data",      DataSize);
        }
    }
}
