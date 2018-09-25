using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    public class EmfPlusRegionNodeRect : EmfPlusRegionNodeData
    {
        public EmfPlusRegionNodeRect(MetafileReader reader) : base(RegionNodeDataType.Rect)
        {
            Rect = new EmfPlusRectF(reader);
        }

        public override uint Size => 16;

        public EmfPlusRectF Rect { get; set; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Rect.GetValues())
            {
                yield return values;
            }
        }
    }
}
