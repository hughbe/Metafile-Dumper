using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies adjustments to the highlights, midtones, and shadows of an image.
    /// [MS-EMFPLUS] 2.2.3.8
    /// </summary>
    public class LevelsEffect : EmfPlusImageEffectBase
    {
        public LevelsEffect(MetafileReader reader) : base(ImageEffects.LevelsEffectGuid)
        {
            Highlight = reader.ReadInt32();
            MidTone = reader.ReadInt32();
            Shadow = reader.ReadInt32();
        }

        public override uint Size => 12;

        /// <summary>
        /// Specifies how much to lighten the highlights of an image. The color channel
        /// values at the high end of the intensity range are altered more than values
        /// near the middle or low ends, which means an image can be lightened without
        /// losing the contrast between the darker portions of the image.
        /// </summary>
        public int Highlight { get; }

        /// <summary>
        /// Specifies how much to lighten or darken the midtones of an image. Color channel
        /// values in the middle of the intensity range are altered more than values near
        /// the high or low ends, which means an image can be lightened or darkened
        /// without losing the contrast between the darkest and lightest portions of
        /// the image.
        /// </summary>
        public int MidTone { get; }

        /// <summary>
        /// Specifies how much to darken the shadows of an image. Color channel values at
        /// the low end of the intensity range are altered more than values near the
        /// middle or high ends, which means an image can be darkened without losing
        /// the contrast between the lighter portions of the image.
        /// </summary>
        public int Shadow { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Highlight", 4);
            yield return new RecordValues("Mid Tone",  4);
            yield return new RecordValues("Shadow",    4);
        }
    }
}
