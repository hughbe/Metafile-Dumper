using MetafileDumper.EmfPlus.Constants;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies one of eight adjustments to an image, including exposure, density,
    /// contrast, highlight, shadow, midtone, white saturation, or black saturation.
    /// [MS-EMFPLUS] 2.2.3.4
    /// </summary>
    public class ColorCurveEffect : EmfPlusImageEffectBase
    {
        public ColorCurveEffect(MetafileReader reader) : base(ImageEffects.ColorCurveEffectGuid)
        {
            CurveAdjustment = (CurveAdjustments)reader.ReadUInt32();
            CurveChannel = (CurveChannel)reader.ReadUInt32();
            AdjustmentIntensity = reader.ReadInt32();
        }

        public override uint Size => 12;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the curve adjustment to apply to
        /// the colors in bitmap.
        /// This value MUST be defined in the CurveAdjustments enumeration.
        /// </summary>
        public CurveAdjustments CurveAdjustment { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the color channel to which the
        /// curve adjustment applies.
        /// This value MUST be defined in the CurveChannel enumeration.
        /// </summary>
        public CurveChannel CurveChannel { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the intensity of the curve adjustment
        /// to the color channel specified by CurveChannel.
        /// The ranges of meaningful values for this field vary according to the
        /// CurveAdjustment value.
        /// </summary>
        public int AdjustmentIntensity { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Curve Adjusment",       4);
            yield return new RecordValues("Curve Channel",         4);
            yield return new RecordValues("Adjustment Intensity ", 4);
        }
    }
}
