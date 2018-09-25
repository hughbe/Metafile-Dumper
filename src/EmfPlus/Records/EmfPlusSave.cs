using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Saves the current graphics state.
    /// [MS-EMFPLUS] 2.3.7.5
    /// </summary>
    public class EmfPlusSave : EmfPlusRecord
    {
        public EmfPlusSave(MetafileReader reader) : base(reader)
        {
            StackIndex = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusSave";

        /// <summary>
        /// A 32-bit unsigned integer that specifies a level to associate with the graphics
        /// state.
        /// The level value can be used by a subsequent EmfPlusRestore record to retrieve
        /// the graphics state.
        /// </summary>
        public uint StackIndex { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Stack Index", 4);
        }
    }
}
