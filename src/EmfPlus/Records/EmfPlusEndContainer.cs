using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Closes a graphics state container that was previously opened by a
    /// begin container operation.
    /// [MS-EMFPLUS] 2.3.7.3
    /// </summary>
    public class EmfPlusEndContainer : EmfPlusRecord
    {
        public EmfPlusEndContainer(MetafileReader reader) : base(reader)
        {
            StackIndex = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusEndContainer";

        /// <summary>
        /// A 32-bit unsigned integer that specifies the index of a graphics state
        /// container.
        /// The index MUST match the value associated with a graphics state container
        /// opened by a previous EmfPlusBeginContainer or
        /// EmfPlusBeginContainerNoParams record.
        /// </summary>
        public uint StackIndex { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Stack Index", 4);
        }
    }
}
