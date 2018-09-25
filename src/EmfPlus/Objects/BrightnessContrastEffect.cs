using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an expansion or contraction of the lightest and darkest areas
    /// of an image.
    /// [MS-EMFPLUS] 2.2.3.2
    /// </summary>
    public class BrightnessContrastEffect : EmfPlusImageEffectBase
    {
        public BrightnessContrastEffect(MetafileReader reader) : base(ImageEffects.BrightnessContrastEffectGuid)
        {
            BrightnessLevel = reader.ReadInt32();
            ContrastLevel = reader.ReadInt32();
        }

        public override uint Size => 8;

        /// <summary>
        /// 32-bit signed integer that specifies the brightness level.
        /// This value MUST be in the range -255 through 255.
        /// </summary>
        public int BrightnessLevel { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the contrast level.
        /// This value MUST be in the range -100 through 100.
        /// </summary>
        public int ContrastLevel { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Brightness Level", 4);
            yield return new RecordValues("Contrast Level",   4);
        }
    }
}
