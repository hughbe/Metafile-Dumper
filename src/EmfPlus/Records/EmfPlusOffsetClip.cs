using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Applies a translation transform on the current clipping region for the world space.
    /// [MS-EMFPLUS] 2.3.1.1
    /// </summary>
    public class EmfPlusOffsetClip : EmfPlusRecord
    {
        public EmfPlusOffsetClip(MetafileReader reader) : base(reader)
        {
            Dx = reader.ReadSingle();
            Dy = reader.ReadSingle();
        }

        public override string Name => "EmfPlusOffsetClip";

        /// <summary>
        /// A 32-bit floating-point value that specifies the horizontal offset for
        /// the translation.
        /// </summary>
        public float Dx { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the vertical offset for
        /// the translation.
        /// </summary>
        public float Dy { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("dx", 4);
            yield return new RecordValues("dy", 4);
        }
    }
}
