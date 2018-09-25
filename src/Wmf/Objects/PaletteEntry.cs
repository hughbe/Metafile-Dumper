using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Ddefines the color and usage of an entry in a palette.
    /// [MS-WMF] 2.2.2.13
    /// </summary>
    public class PaletteEntry : ObjectBase
    {
        public PaletteEntry(MetafileReader reader)
        {
            Flags = (PaletteEntryFlag)reader.ReadByte();
            Blue = reader.ReadByte();
            Green = reader.ReadByte();
            Red = reader.ReadByte();
        }

        public override uint Size => 4;

        /// <summary>
        /// An 8-bit unsigned integer that defines how the palette entry is to be used.
        /// The Values field MUST be 0x00 or one of the values in the PaletteEntryFlag
        /// Enumeration(section 2.1.1.22) table.
        /// </summary>
        public PaletteEntryFlag Flags { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the blue intensity value for the
        /// palette entry.
        /// </summary>
        public byte Blue { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the green intensity value for the
        /// palette entry.
        /// </summary>
        public byte Green { get; }

        /// <summary>
        /// An 8-bit unsigned integer that defines the red intensity value for the
        /// palette entry.
        /// </summary>
        public byte Red { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Flags", 1);
            yield return new RecordValues("Blue",     1);
            yield return new RecordValues("Green",    1);
            yield return new RecordValues("Red",      1);
        }
    }
}
