using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.Wmf.Objects
{
    public class HatchBrushData : BrushHatchData
    {
        public HatchBrushData(MetafileReader reader)
        {
            HatchStyle = (HatchStyle)reader.ReadUInt16();
        }

        public override uint Size => 2;

        public HatchStyle HatchStyle { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style", 2);
        }
    }
}
