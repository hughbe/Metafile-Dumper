using MetafileDumper.EmfPlus.Constants;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an affine transform to be applied to an image.
    /// [MS-EMFPLUS] 2.2.3.6
    /// </summary>
    public class ColorMatrixEffect : EmfPlusImageEffectBase
    {
        public ColorMatrixEffect(MetafileReader reader) : base(ImageEffects.ColorMatrixEffectGuid)
        {
            Matrix0 = new ColorMatrix(reader);
            Matrix1 = new ColorMatrix(reader);
            Matrix2 = new ColorMatrix(reader);
            Matrix3 = new ColorMatrix(reader);
            Matrix4 = new ColorMatrix(reader);
        }

        public override uint Size => 20 * 5;

        /// <summary>
        /// Matrix[N][0] of the 5x5 color matrix. This row is used for transforms.
        /// </summary>
        public ColorMatrix Matrix0 { get; }

        /// <summary>
        /// Matrix[N][1] of the 5x5 color matrix. This row is used for transforms.
        /// </summary>
        public ColorMatrix Matrix1 { get; }

        /// <summary>
        /// Matrix[N][2] of the 5x5 color matrix. This row is used for transforms.
        /// </summary>
        public ColorMatrix Matrix2 { get; }

        /// <summary>
        /// Matrix[N][3] of the 5x5 color matrix. This row is used for transforms.
        /// </summary>
        public ColorMatrix Matrix3 { get; }

        /// <summary>
        /// Matrix[N][4] of the 5x5 color matrix. This row is used for color translations.
        /// </summary>
        public ColorMatrix Matrix4 { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Matrix0.GetValues())
            {
                yield return new RecordValues("Matrix 0 " + values.Name, values.Length);
            }

            foreach (RecordValues values in Matrix1.GetValues())
            {
                yield return new RecordValues("Matrix 1 " + values.Name, values.Length);
            }

            foreach (RecordValues values in Matrix2.GetValues())
            {
                yield return new RecordValues("Matrix 2 " + values.Name, values.Length);
            }

            foreach (RecordValues values in Matrix3.GetValues())
            {
                yield return new RecordValues("Matrix 3 " + values.Name, values.Length);
            }

            foreach (RecordValues values in Matrix4.GetValues())
            {
                yield return new RecordValues("Matrix 4 " + values.Name, values.Length);
            }
        }
    }
}
