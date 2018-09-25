using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an addition of black or white to a specified hue in an image.
    /// [MS-EMFPLUS] 2.2.3.11
    /// </summary>
    public class TintEffect : EmfPlusImageEffectBase
    {
        public TintEffect(MetafileReader reader) : base(ImageEffects.TintEffectGuid)
        {
            Hue = reader.ReadInt32();
            Amount = reader.ReadInt32();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit signed integer that specifies the hue to which the tint effect is applied
        /// </summary>
        public int Hue { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies how much the hue is strengthened or
        /// weakened.
        /// </summary>
        public int Amount { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Hue",    4);
            yield return new RecordValues("Amount", 4);
        }
    }
}
