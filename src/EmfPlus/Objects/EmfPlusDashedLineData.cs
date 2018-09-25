using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies properties of a dashed line for a graphics pen.
    /// [MS-EMFPLUS] 2.2.2.16
    /// </summary>
    public class EmfPlusDashedLineData : ObjectBase
    {
        public EmfPlusDashedLineData(MetafileReader reader)
        {
            DashedLineDataCount = reader.ReadUInt32();
        }

        public override uint Size => 4 + 4 * DashedLineDataCount;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of elements in the
        /// DashedLineData field.
        /// </summary>
        public uint DashedLineDataCount { get; }

        /// <summary>
        /// An array of DashedLineDataSize floating-point values that specify
        /// the lengths of the dashes and spaces in a dashed line.
        /// </summary>
        public IEnumerable<float> DashedLineData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Size", 4);
            yield return new RecordValues("Data", DashedLineDataCount);
        }
    }
}
