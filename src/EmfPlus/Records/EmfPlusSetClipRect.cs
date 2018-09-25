using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Combines the current clipping region with a rectangle.
    /// [MS-EMFPLUS] 2.3.1.4
    /// </summary>
    public class EmfPlusSetClipRect : EmfPlusRecord
    {
        public EmfPlusSetClipRect(MetafileReader reader) : base(reader)
        {
            ClipRect = new EmfPlusRectF(reader);
        }

        public override string Name => "EmfPlusSetClipRect";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X |     CM        | X | X | X | X | X | X | X | X |
        /// <summary>
        /// Specifies the logical operation for combining two regions. See the CombineMode
        /// enumeration for the meanings of the values.
        /// </summary>
        public CombineMode CombineMode => (CombineMode)(Flags >> 8);

        /// <summary>
        /// An EmfPlusRectF object that defines the rectangle to use in the CombineMode
        /// operation.
        /// </summary>
        public EmfPlusRectF ClipRect { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in ClipRect.GetValues())
            {
                yield return values;
            }
        }
    }
}
