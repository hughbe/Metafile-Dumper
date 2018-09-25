using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Performs a rotation on the current world space transform.
    /// [MS-EMFPLUS] 2.3.9.3
    /// </summary>
    public class EmfPlusRotateWorldTransform : EmfPlusRecord
    {
        public EmfPlusRotateWorldTransform(MetafileReader reader) : base(reader)
        {
            Angle = reader.ReadSingle();
        }

        public override string Name => "EmfPlusRotateWorldTransform";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, the transform matrix is post-multiplied. If clear, it is pre-multiplied.
        /// </summary>
        public bool PostMultiplied => (Flags & 0b10000000000000) != 0;

        /// <summary>
        /// A 32-bit floating-point value that specifies the angle of rotation in degrees.
        /// </summary>
        public float Angle { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Angle", 4);
        }
    }
}
