using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Multiplies the current world space transform by a specified transform matrix.
    /// [MS-EMFPLUS] 2.3.9.1
    /// </summary>
    public class EmfPlusMultiplyWorldTransform : EmfPlusRecord
    {
        public EmfPlusMultiplyWorldTransform(MetafileReader reader) : base(reader)
        {
            MatrixData = new EmfPlusTransformMatrix(reader);
        }

        public override string Name => "EmfPlusMultiplyWorldTransform";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, the transform matrix is post-multiplied. If clear, it is pre-multiplied.
        /// </summary>
        public bool PostMultiplied => (Flags & 0b10000000000000) != 0;

        /// <summary>
        /// An EmfPlusTransformMatrix object that defines the multiplication matrix.
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
