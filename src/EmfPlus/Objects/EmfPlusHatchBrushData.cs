using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a hatch pattern for a graphics brush.
    /// [MS-EMFPLUS] 2.2.2.20
    /// </summary>
    public class EmfPlusHatchBrushData : EmfPlusBrushDataBase
    {
        public EmfPlusHatchBrushData(MetafileReader reader) : base(BrushType.HatchFill)
        {
            Style = (HatchStyle)reader.ReadInt32();
            ForegroundColor = reader.ReadUInt32();
            BackgroundColor = reader.ReadUInt32();
        }

        public override uint Size => 4 + 4 + 4;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the brush hatch style.
        /// It MUST be defined in the HatchStyle enumeration.
        /// </summary>
        public HatchStyle Style { get; }

        /// <summary>
        /// A 32-bit EmfPlusARGB object that specifies the color used to draw the lines
        /// of the hatch pattern.
        /// </summary>
        public uint ForegroundColor { get; }

        /// <summary>
        /// A 32-bit EmfPlusARGB object that specifies the color used to paint the
        /// background of the hatch pattern.
        /// </summary>
        public uint BackgroundColor { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style",            4);
            yield return new RecordValues("Foreground Color", 4);
            yield return new RecordValues("Background Color", 4);
        }
    }
}
