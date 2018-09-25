using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Restores a saved graphics state
    /// [MS-EMFPLUS] 2.3.7.4
    /// </summary>
    public class EmfPlusRestore : EmfPlusRecord
    {
        public EmfPlusRestore(MetafileReader reader) : base(reader)
        {
            StackIndex = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusRestore";

        /// <summary>
        /// A 32-bit unsigned integer that specifies the level associated with a graphics
        /// state.
        /// The level value was assigned to the graphics state by a previous
        /// EmfPlusSave record.
        /// </summary>
        public uint StackIndex { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Stack Index", 4);
        }
    }
}
