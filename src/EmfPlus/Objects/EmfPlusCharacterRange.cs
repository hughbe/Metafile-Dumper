using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a range of character positions for a text string.
    /// [MS-EMFPLUS] 2.2.2.8
    /// </summary>
    public class EmfPlusCharacterRange : ObjectBase
    {
        public EmfPlusCharacterRange(MetafileReader reader)
        {
            First = reader.ReadInt32();
            Last = reader.ReadInt32();
        }

        public override uint Size => 4 + 4;

        /// <summary>
        /// A 32-bit signed integer that specifies the first position of this range.
        /// </summary>
        public int First { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the number of positions in this range.
        /// </summary>
        public int Last { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("First", 4);
            yield return new RecordValues("Last",  4);
        }
    }
}
