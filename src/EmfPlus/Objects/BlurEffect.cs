using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a decrease in the difference in intensity between pixels in an image.
    /// [MS-EMFPLUS] 2.2.3.1
    /// </summary>
    public class BlurEffect : EmfPlusImageEffectBase
    {
        public BlurEffect(MetafileReader reader) : base(ImageEffects.BlurEffectGuid)
        {
            BlurRadius = reader.ReadSingle();
            ExpandEdge = reader.ReadBoolean();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit floating-point number that specifies the blur radius in pixels, which
        /// determines the number of pixels involved in calculating the new value of a
        /// given pixel.
        /// This value MUST be in the range 0.0 through 255.0.
        /// As this value increases, the number of pixels involved in the calculation
        /// increases, and the resulting bitmap SHOULD become more blurry.
        /// </summary>
        public float BlurRadius { get; }

        /// <summary>
        /// A 32-bit Boolean value that specifies whether the bitmap expands by an
        /// amount equal to the value of the BlurRadius to produce soft edges.
        /// </summary>
        public bool ExpandEdge { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Blur Radius", 4);
            yield return new RecordValues("Expand Edge", 4);
        }
    }
}
