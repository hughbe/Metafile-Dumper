using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a bitmap image with pixel data.
    /// [MS-EMFPLUS] 2.2.2.3
    /// </summary>
    public class EmfPlusBitmapData : EmfPlusBitmapDataBase
    {
        public EmfPlusBitmapData(MetafileReader reader, uint size) : base(size)
        {
        }

        public override BitmapDataType BitmapType => BitmapDataType.Pixel;

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", Size);
        }
    }
}
