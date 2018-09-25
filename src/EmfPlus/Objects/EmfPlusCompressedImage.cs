using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an image with compressed data.
    /// [MS-EMFPLUS] 2.2.2.10
    /// </summary>
    public class EmfPlusCompressedImage : EmfPlusBitmapDataBase
    {
        public EmfPlusCompressedImage(MetafileReader reader, uint size) : base(size)
        {
            for (uint i = 0; i < size; i++)
            {
                reader.ReadByte();
            }
        }

        public override BitmapDataType BitmapType => BitmapDataType.Compressed;

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", Size);
        }
    }
}
