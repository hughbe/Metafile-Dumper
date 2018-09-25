using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies focus scales for the blend pattern of a path gradient brush.
    /// [MS-EMFPLUS] 2.2.2.18
    /// </summary>
    public class EmfPlusFocusScaleData : ObjectBase
    {
        public EmfPlusFocusScaleData(MetafileReader reader)
        {
            ScaleCount = reader.ReadUInt32();
            ScaleX = reader.ReadSingle();
            ScaleY = reader.ReadSingle();
        }

        public override uint Size => 12;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of focus scales.
        /// This value MUST be 2.
        /// </summary>
        public uint ScaleCount { get; }

        /// <summary>
        /// A floating-point value that defines the horizontal focus scale.
        /// The focus scale MUST be a value between 0.0 and 1.0, exclusive.
        /// </summary>
        public float ScaleX { get; }

        /// <summary>
        /// A floating-point value that defines the vertical focus scale.
        /// The focus scale MUST be a value between 0.0 and 1.0, exclusive.
        /// </summary>
        public float ScaleY { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Scale Count", 4);
            yield return new RecordValues("Scale X",     4);
            yield return new RecordValues("Scale Y",     4);
        }
    }
}
