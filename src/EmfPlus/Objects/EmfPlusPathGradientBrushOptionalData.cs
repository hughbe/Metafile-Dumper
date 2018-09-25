using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies optional data for a texture brush.
    /// [MS-EMFPLUS] 2.2.2.46
    /// </summary>
    public class EmfPlusTextureBrushOptionalData : ObjectBase
    {
        public EmfPlusTextureBrushOptionalData(MetafileReader reader, BrushDataFlags flags, uint size)
        {
            if ((flags & BrushDataFlags.HasTransform) != 0)
            {
                Transform = new EmfPlusTransformMatrix(reader);
            }
            Image = new EmfPlusImage(reader, size);
        }

        /// <summary>
        /// An optional EmfPlusTransformMatrix object that specifies a world space to
        /// device space transform for the path gradient brush.
        /// This field MUST be present if the BrushDataTransform flag is set in the
        /// BrushDataFlags field of the EmfPlusTextureBrushData object.
        /// </summary>
        public EmfPlusTransformMatrix Transform { get; }

        /// <summary>
        /// An optional EmfPlusImage object that specifies the brush texture.
        /// This field MUST be present if the size of the EmfPlusObject record that defines
        /// this texture brush is large enough to accommodate an EmfPlusImage object in
        /// addition to the required fields of the EmfPlusTextureBrushData object and
        /// optionally an EmfPlusTransformMatrix object.
        /// </summary>
        public EmfPlusImage Image { get; }

        public override uint Size
        {
            get
            {
                uint result = 0;

                if (Transform != null)
                {
                    result += Transform.Size;
                }

                result += Image.Size;

                return result;
            }
        }

        public override IEnumerable<RecordValues> GetValues()
        {
            if (Transform != null)
            {
                foreach (RecordValues values in Transform.GetValues())
                {
                    yield return values;
                }
            }

            foreach (RecordValues values in Image.GetValues())
            {
                yield return values;
            }
        }
    }
}
