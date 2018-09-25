using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies adjustments to the hue, saturation, and lightness of an image.
    /// [MS-EMFPLUS 2.2.3.7]
    /// </summary>
    public class HueSaturationLightnessEffect : EmfPlusImageEffectBase
    {
        public HueSaturationLightnessEffect(MetafileReader reader) : base(ImageEffects.HueSaturationLightnessEffectGuid)
        {
            HueLevel = reader.ReadInt32();
            SaturationLevel = reader.ReadInt32();
            LightnessLevel = reader.ReadInt32();
        }

        public override uint Size => 12;

        /// <summary>
        /// Specifies the adjustment to the hue.
        /// </summary>
        public int HueLevel { get; }

        /// <summary>
        /// Specifies the adjustment to the saturation.
        /// </summary>
        public int SaturationLevel { get; }

        /// <summary>
        /// Specifies the adjustment to the lightness.
        /// </summary>
        public int LightnessLevel { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Hue Level",        4);
            yield return new RecordValues("Saturation Level", 4);
            yield return new RecordValues("Lightness Level",  4);
        }
    }
}
