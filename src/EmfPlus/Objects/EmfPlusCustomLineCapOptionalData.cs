using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies optional fill and outline data for a custom line cap.
    /// [MS-EMFPLUS] 2.2.2.14
    /// </summary>
    public class EmfPlusCustomLineCapOptionalData : ObjectBase
    {
        public EmfPlusCustomLineCapOptionalData(MetafileReader reader, CustomLineCapDataFlags flags)
        {
            if ((flags & CustomLineCapDataFlags.HasFillPath) != 0)
            {
                FillPath = new EmfPlusFillPath(reader);
            }
            if ((flags & CustomLineCapDataFlags.HasStrokePath) != 0)
            {
                StrokePath = new EmfPlusLinePath(reader);
            }
        }

        /// <summary>
        /// An optional EmfPlusFillPath object that specifies the path for filling a custom
        /// graphics line cap.
        /// This field MUST be present if the CustomLineCapDataFillPath flag is set in the
        /// CustomLineCapDataFlags field of the EmfPlusCustomLineCapData object.
        /// </summary>
        public EmfPlusFillPath FillPath { get; }

        /// <summary>
        /// An optional EmfPlusLinePath object that specifies the path for outlining a
        /// custom graphics line cap.
        /// This field MUST be present if the CustomLineCapDataLinePath flag is set in the
        /// CustomLineCapDataFlags field of the EmfPlusCustomLineCapData object.
        /// </summary>
        public EmfPlusLinePath StrokePath { get; }

        public override uint Size
        {
            get
            {
                uint result = 0;

                if (FillPath != null)
                {
                    result += FillPath.Size;
                }
                if (StrokePath != null)
                {
                    result += StrokePath.Size;
                }

                return result;
            }
        }

        public override IEnumerable<RecordValues> GetValues()
        {
            if (FillPath != null)
            {
                foreach (RecordValues values in FillPath.GetValues())
                {
                    yield return new RecordValues("Fill " + values.Name, values.Length);
                }
            }
            if (StrokePath != null)
            {
                foreach (RecordValues values in StrokePath.GetValues())
                {
                    yield return new RecordValues("Stroke " + values.Name, values.Length);
                }
            }
        }
    }
}
