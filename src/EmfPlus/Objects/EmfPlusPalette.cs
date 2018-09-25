using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies the colors that make up a palette.
    /// [MS-EMFPLUS] 2.2.2.28
    /// </summary>
    public class EmfPlusPalette : ObjectBase
    {
        public EmfPlusPalette(MetafileReader reader)
        {
            StyleFlags = (PaletteStyleFlags)reader.ReadInt32();
            Count = reader.ReadUInt32();

            var entries = new List<uint>();
            for (int i = 0; i < Count; i++)
            {
                uint entry = reader.ReadUInt32();
                entries.Add(entry);
            }
            Entries = entries;
        }

        public override uint Size => 4 + 4 + 4 * Count;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the attributes of data in the palette.
        /// This value MUST be composed of PaletteStyle flags.
        /// </summary>
        public PaletteStyleFlags StyleFlags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of entries in the
        /// PaletteEntries array.
        /// </summary>
        public uint Count { get; }

        /// <summary>
        /// An array of PaletteCount EmfPlusARGB objects that specify the data in
        /// the palette.
        /// </summary>
        public IEnumerable<uint> Entries { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style Flags", 4);
            yield return new RecordValues("Count",       4);
            yield return new RecordValues("Entries",     Count * 4);
        }
    }
}
