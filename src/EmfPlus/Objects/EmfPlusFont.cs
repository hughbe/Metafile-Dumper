using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies properties that determine the appearance of text, including
    /// typeface, size, and style.
    /// [MS-EMFPLUS] 2.2.1.3
    /// /// </summary>
    public class EmfPlusFont : EmfPlusObjectData
    {
        public EmfPlusFont(MetafileReader reader, uint size) : base(reader, size)
        {
            EmSize = reader.ReadSingle();
            Unit = (UnitType)reader.ReadUInt32();
            StyleFlags = (FontStyleFlags)reader.ReadInt32();
            Reserved = reader.ReadUInt32();
            NameLength = reader.ReadUInt32();
            Name = Utilities.GetString(reader, NameLength);
        }

        public override ObjectType ObjectType => ObjectType.Font;

        /// <summary>
        /// A 32-bit floating-point value that specifies the em size of the font in units
        /// specified by the SizeUnit field.
        /// </summary>
        public float EmSize { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the units used for the EmSize field.
        /// These are typically the units that were employed when designing the font.
        /// The value MUST be in the UnitType enumeration.
        /// </summary>
        public UnitType Unit { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies attributes of the character glyphs
        /// that affect the appearance of the font, such as bold and italic.
        /// This value MUST be composed of FontStyle flags.
        /// </summary>
        public FontStyleFlags StyleFlags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that is reserved and MUST be ignored.
        /// </summary>
        public uint Reserved { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of characters in the
        /// FamilyName field.
        /// </summary>
        public uint NameLength { get; }

        /// <summary>
        /// A string of Length Unicode characters that contains the name of the font
        /// family.
        /// </summary>
        public string Name { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",     4);
            yield return new RecordValues("Em Size",     4);
            yield return new RecordValues("Unit",        4);
            yield return new RecordValues("Style Flags", 4);
            yield return new RecordValues("Reserved",    4);
            yield return new RecordValues("Name Length", 4);

            if (NameLength != 0)
            {
                yield return new RecordValues("Name", NameLength * 2);
            }
        }
    }
}
