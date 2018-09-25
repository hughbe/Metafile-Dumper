using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Specifies colors as device-independent values, which can be defined
    /// entirely by an application.
    /// [MS-WMF] 2.2.1.3
    /// </summary>
    public class Palette : ObjectBase
    {
        public Palette(MetafileReader reader)
        {
            Start = reader.ReadUInt16();
            NumberOfEntries = reader.ReadUInt16();

            var entries = new PaletteEntry[NumberOfEntries];
            for (uint i = 0; i < NumberOfEntries; i++)
            {
                entries[i] = new PaletteEntry(reader);
            }
            Entries = entries;
        }

        public override uint Size => 4 + (uint)NumberOfEntries * 4;

        /// <summary>
        /// A 16-bit unsigned integer that defines the offset into the Palette Object when
        /// used with the META_SETPALENTRIES and META_ANIMATEPALETTE record types.
        /// When used with META_CREATEPALETTE record type, it MUST be 0x0300.
        /// </summary>
        public ushort Start { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the number of objects in aPaletteEntries.
        /// </summary>
        public ushort NumberOfEntries { get; }

        /// <summary>
        /// An array of NumberOfEntries 32-bit PaletteEntry Objects (section 2.2.2.13).
        /// </summary>
        public IEnumerable<PaletteEntry> Entries { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Start",             2);
            yield return new RecordValues("Number of Entries", 2);
            yield return new RecordValues("Entries",           (uint)NumberOfEntries * 4);
        }
    }
}
