using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    public class DIBPatternBrushData : BrushHatchData
    {
        public DIBPatternBrushData(MetafileReader reader)
        {
            Bitmap = new DeviceIndependentBitmap(reader);
        }

        public override uint Size => Bitmap.Size;

        public DeviceIndependentBitmap Bitmap { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Bitmap.GetValues())
            {
                yield return values;
            }
        }
    }
}
