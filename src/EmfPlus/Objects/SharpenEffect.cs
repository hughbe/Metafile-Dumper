using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an increase in the difference in intensity between pixels in an image.
    /// [MS-EMFPLUS] 2.2.3.10
    /// </summary>
    public class SharpenEffect : EmfPlusImageEffectBase
    {
        public SharpenEffect(MetafileReader reader) : base(ImageEffects.SharpenEffectGuid)
        {
            Radius = reader.ReadSingle();
            Amount = reader.ReadSingle();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit floating-point number that specifies the sharpening radius in pixels,
        /// which determines the number of pixels involved in calculating the new value
        /// of a given pixel.
        /// </summary>
        public float Radius { get; }

        /// <summary>
        /// A 32-bit floating-point number that specifies the difference in intensity
        /// between a given pixel and the surrounding pixels.
        /// </summary>
        public float Amount { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Radius", 4);
            yield return new RecordValues("Amount", 4);
        }
    }
}
