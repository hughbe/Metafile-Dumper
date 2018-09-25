using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Performs a scaling on the current world space transform.
    /// [MS-EMFPLUS] 2.3.9.4
    /// </summary>
    public class EmfPlusScaleWorldTransform : EmfPlusRecord
    {
        public EmfPlusScaleWorldTransform(MetafileReader reader) : base(reader)
        {
            Sx = reader.ReadSingle();
            Sy = reader.ReadSingle();
        }

        public override string Name => "EmfPlusScaleWorldTransform";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, the transform matrix is post-multiplied. If clear, it is pre-multiplied.
        /// </summary>
        public bool PostMultiplied => (Flags & 0b10000000000000) != 0;

        /// <summary>
        /// A 32-bit floating-point value that defines the horizontal scale factor.
        /// </summary>
        public float Sx { get; }

        /// <summary>
        /// A 32-bit floating-point value that defines the vertical scale factor.
        /// </summary>
        public float Sy { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("sx", 4);
            yield return new RecordValues("sy", 4);
        }
    }
}
