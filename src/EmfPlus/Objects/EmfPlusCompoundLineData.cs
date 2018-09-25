using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies line and space data for a compound line.
    /// [MS-EMFPLUS] 2.2.2.9
    /// </summary>
    public class EmfPlusCompoundLineData : ObjectBase
    {
        public EmfPlusCompoundLineData(MetafileReader reader)
        {
            CompoundLineCount = reader.ReadUInt32();
            CompoundLineData = Utilities.ReadFloats(reader, CompoundLineCount);
        }

        public override uint Size => 4 + 4 * CompoundLineCount;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of elements
        /// in the CompoundLineData field.
        /// </summary>
        public uint CompoundLineCount { get; }

        /// <summary>
        /// An array of CompoundLineDataSize floating-point values that specify the
        /// compound line of a pen.
        /// The elements MUST be in increasing order, and their values MUST be
        /// between 0.0 and 1.0, inclusive
        /// </summary>
        public IEnumerable<float> CompoundLineData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Size", 4);
            yield return new RecordValues("Data", 4 * CompoundLineCount);
        }
    }
}
