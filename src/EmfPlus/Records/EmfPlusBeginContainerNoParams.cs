using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Starts a new graphics state container.
    /// [MS-EMFPLUS] 2.3.7.2
    /// </summary>
    public class EmfPlusBeginContainerNoParams : EmfPlusRecord
    {
        public EmfPlusBeginContainerNoParams(MetafileReader reader) : base(reader)
        {
            StackIndex = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusBeginContainerNoParams";

        /// <summary>
        /// A 32-bit unsigned integer that specifies an index to associate with the
        /// graphics state container.
        /// The index MUST be referenced by a subsequent EmfPlusEndContainer
        /// record to close the graphics state container.
        /// </summary>
        public uint StackIndex { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Stack Index", 4);
        }
    }
}
