using MetafileDumper.EmfPlus.Constants;
using MetafileDumper.Wmf.Data;
using System.Collections.Generic;
using System.Linq;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies areas of an image to which a red-eye correction effect is applied.
    /// [MS-EMFPLUS] 2.2.3.9
    /// </summary>
    public class RedEyeCorrectionEffect : EmfPlusImageEffectBase
    {
        public RedEyeCorrectionEffect(MetafileReader reader) : base(ImageEffects.RedEyeCorrectionEffectGuid)
        {
            NumberOfAreas = reader.ReadInt32();

            if (NumberOfAreas > 0)
            {
                var areas = new List<RectL>(NumberOfAreas);
                for (int i = 0; i < NumberOfAreas; i++)
                {
                    var area = new RectL(reader);
                    areas.Add(area);
                }
                Areas = areas;
            }
            else
            {
                Areas = Enumerable.Empty<RectL>();
            }
        }

        public override uint Size
        {
            get
            {
                uint size = 4;
                if (NumberOfAreas > 0)
                {
                    size += (uint)NumberOfAreas * 16;
                }
                return size;
            }
        }

        /// <summary>
        /// A 32-bit signed integer that specifies the number of rectangles in the
        /// Areas field.
        /// </summary>
        public int NumberOfAreas { get; }

        /// <summary>
        /// An array of NumberOfAreas WMF RectL objects [MS-WMF]. Each rectangle specifies
        /// an area of the bitmap image to which the red-eye correction effect SHOULD
        /// be applied.
        /// </summary>
        public IEnumerable<RectL> Areas { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Number of Areas", 4);

            int i = 0;
            foreach (RectL rect in Areas)
            {
                foreach (RecordValues values in rect.GetValues())
                {
                    yield return new RecordValues(values.Name + (i + 1), values.Length);
                }

                i++;
            }
        }
    }
}
