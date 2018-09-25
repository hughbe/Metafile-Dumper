using MetafileDumper.EmfPlus.Constants;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusImageEffectBase : ObjectBase
    {
        public EmfPlusImageEffectBase(Guid identifier)
        {
            Identifier = identifier;
        }

        public Guid Identifier { get; }

        public static EmfPlusImageEffectBase GetImageEffect(MetafileReader reader, Guid identifier)
        {
            EmfPlusImageEffectBase effect;

            if (identifier == ImageEffects.BlurEffectGuid)
            {
                effect = new BlurEffect(reader);
            }
            else if (identifier == ImageEffects.BrightnessContrastEffectGuid)
            {
                effect = new BrightnessContrastEffect(reader);
            }
            else if (identifier == ImageEffects.ColorBalanceEffectGuid)
            {
                effect = new ColorBalanceEffect(reader);
            }
            else if (identifier == ImageEffects.ColorCurveEffectGuid)
            {
                effect = new ColorCurveEffect(reader);
            }
            else if (identifier == ImageEffects.ColorLookupTableEffectGuid)
            {
                effect = new ColorLookupTableEffect(reader);
            }
            else if (identifier == ImageEffects.ColorMatrixEffectGuid)
            {
                effect = new ColorMatrixEffect(reader);
            }
            else if (identifier == ImageEffects.HueSaturationLightnessEffectGuid)
            {
                effect = new HueSaturationLightnessEffect(reader);
            }
            else if (identifier == ImageEffects.LevelsEffectGuid)
            {
                effect = new LevelsEffect(reader);
            }
            else if (identifier == ImageEffects.RedEyeCorrectionEffectGuid)
            {
                effect = new RedEyeCorrectionEffect(reader);
            }
            else if (identifier == ImageEffects.SharpenEffectGuid)
            {
                effect = new SharpenEffect(reader);
            }
            else if (identifier == ImageEffects.TintEffectGuid)
            {
                effect = new TintEffect(reader);
            }
            else
            {
                throw new InvalidOperationException($"Unknown image effect {identifier}.");
            }

            return effect;
        }
    }
}
