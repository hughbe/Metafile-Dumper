using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies adjustments to the colors in an image.
    /// [MS-EMFPLUS] 2.2.3.5
    /// </summary>
    public class ColorLookupTableEffect : EmfPlusImageEffectBase
    {
        public ColorLookupTableEffect(MetafileReader reader) : base(ImageEffects.ColorLookupTableEffectGuid)
        {
            BlueTable = Utilities.ReadBytes(reader, 256);
            GreenTable = Utilities.ReadBytes(reader, 256);
            RedTable = Utilities.ReadBytes(reader, 256);
            AlphaTable = Utilities.ReadBytes(reader, 256);
        }

        public override uint Size => 256 * 4;

        /// <summary>
        /// An array of 256 bytes that specifies the adjustment for the blue color channel.
        /// </summary>
        public IEnumerable<byte> BlueTable { get; }

        /// <summary>
        /// An array of 256 bytes that specifies the adjustment for the green color channel.
        /// </summary>
        public IEnumerable<byte> GreenTable { get; }

        /// <summary>
        /// An array of 256 bytes that specifies the adjustment for the red color channel.
        /// </summary>
        public IEnumerable<byte> RedTable { get; }

        /// <summary>
        /// An array of 256 bytes that specifies the adjustment for the alpha color channel.
        /// </summary>
        public IEnumerable<byte> AlphaTable { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Blue Table",  256);
            yield return new RecordValues("Green Table", 256);
            yield return new RecordValues("Red Table",   256);
            yield return new RecordValues("Alpha Table", 256);
        }
    }
}
