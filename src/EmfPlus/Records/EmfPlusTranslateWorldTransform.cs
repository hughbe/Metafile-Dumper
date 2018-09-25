using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// [MS-EMFPLUS] 2.3.9.7
    /// </summary>
    public class EmfPlusTranslateWorldTransform : EmfPlusRecord
    {
        public EmfPlusTranslateWorldTransform(MetafileReader reader) : base(reader)
        {
            Dx = reader.ReadSingle();
            Dy = reader.ReadSingle();
        }

        public override string Name => "EmfPlusTranslateWorldTransform";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | A | X | X | X | X | X | X | X | X | X | X | X | X | X |
        /// <summary>
        /// If set, the transform matrix is post-multiplied. If clear, it is pre-multiplied.
        /// </summary>
        public bool PostMultiplied => (Flags & 0b10000000000000) != 0;

        /// <summary>
        /// A 32-bit floating-point value that defines the horizontal distance.
        /// </summary>
        public float Dx { get; }

        /// <summary>
        /// A 32-bit floating-point value that defines the vertical distance value
        /// </summary>
        public float Dy { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("dx", 4);
            yield return new RecordValues("dy", 4);
        }
    }
}
