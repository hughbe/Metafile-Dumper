using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Sets the current world space transform according to the values in a
    /// specified transform matrix.
    /// [MS-EMFPLUS] 2.3.9.6
    /// </summary>
    public class EmfPlusSetWorldTransform : EmfPlusRecord
    {
        public EmfPlusSetWorldTransform(MetafileReader reader) : base(reader)
        {
            MatrixData = new EmfPlusTransformMatrix(reader);
        }

        public override string Name => "EmfPlusSetWorldTransform";

        /// <summary>
        /// An EmfPlusTransformMatrix object that defines the new current world transform.
        /// </summary>
        public EmfPlusTransformMatrix MatrixData { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in MatrixData.GetValues())
            {
                yield return values;
            }
        }
    }
}
