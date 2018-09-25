using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    public class PatternBrushData : BrushHatchData
    {
        public PatternBrushData(MetafileReader reader)
        {
            Bitmap = new Bitmap16(reader);
        }

        public override uint Size => Bitmap.Size;

        public Bitmap16 Bitmap { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Bitmap.GetValues())
            {
                yield return values;
            }
        }
    }
}
