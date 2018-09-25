using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Specifies the pitch and family properties of a Font Object (section 2.2.1.2).
    /// Pitch refers to the width of the characters, and family refers to the general
    /// appearance of a font.
    /// [MS-WMF] 2.2.2.14
    /// </summary>
    public class PitchAndFamily : ObjectBase
    {
        public PitchAndFamily(MetafileReader reader)
        {
            Data = reader.ReadByte();
        }

        public override uint Size => 1;

        public byte Data { get; }

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // -------------------------------
        //     Family    | X | X | Pitch |
        public FamilyFont Family => (FamilyFont)((Data >> 4) & 0b1111);

        public PitchFont Pitch => (PitchFont)(Data & 0b11);

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("PitchAndFamily", 1);
        }
    }
}
