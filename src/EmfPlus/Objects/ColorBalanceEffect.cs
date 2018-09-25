using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies adjustments to the relative amounts of red, green, and blue
    /// in an image.
    /// [MS-EMFPLUS] 2.2.3.3
    /// </summary>
    public class ColorBalanceEffect : EmfPlusImageEffectBase
    {
        public ColorBalanceEffect(MetafileReader reader) : base(ImageEffects.ColorBalanceEffectGuid)
        {
            CyanRed = reader.ReadInt32();
            MagentaGreen = reader.ReadInt32();
            YellowBlue = reader.ReadInt32();
        }

        public override uint Size => 12;

        /// <summary>
        /// 32-bit signed integer that specifies a change in the amount of red in the
        /// image.
        /// This value MUST be in the range -100 through 100.
        /// </summary>
        public int CyanRed { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies a change in the amount of green in
        /// the image.
        /// This value MUST be in the range -100 through 100.
        /// </summary>
        public int MagentaGreen { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies a change in the amount of blue in the
        /// image.
        /// This value MUST be in the range -100 through 100.
        /// </summary>
        public int YellowBlue { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Cyan Red",      4);
            yield return new RecordValues("Magenta Green", 4);
            yield return new RecordValues("Yellow Blue",   4);
        }
    }
}
