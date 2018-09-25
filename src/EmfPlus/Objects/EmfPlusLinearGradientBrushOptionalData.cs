using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies optional data for a linear gradient brush.
    /// [MS-EMFPLUS] 2.2.2.25
    /// </summary>
    public class EmfPlusLinearGradientBrushOptionalData : ObjectBase
    {
        public EmfPlusLinearGradientBrushOptionalData(MetafileReader reader, BrushDataFlags flags)
        {
            if ((flags & BrushDataFlags.HasTransform) != 0)
            {
                Transform = new EmfPlusTransformMatrix(reader);
            }

            // TODO: check ordering and also mutually exclusivity.
            if ((flags & BrushDataFlags.HasPresetColors) != 0)
            {
                PresetColors = new EmfPlusBlendColors(reader);
            }
            if ((flags & BrushDataFlags.HasVerticalBlendColors) != 0)
            {
                VerticalBlend = new EmfPlusBlendFactors(reader);
            }
            if ((flags & BrushDataFlags.HasHorizontalBlendColors) != 0)
            {
                HorizontalBlend = new EmfPlusBlendFactors(reader);
            }
        }

        /// <summary>
        /// An optional EmfPlusTransformMatrix object that specifies a world space to
        /// device space transform for the linear gradient brush.
        /// This field MUST be present if the BrushDataTransform flag is set in the
        /// BrushDataFlags field of the EmfPlusLinearGradientBrushData object.
        /// </summary>
        public EmfPlusTransformMatrix Transform { get; }

        public EmfPlusBlendColors PresetColors { get; }

        public EmfPlusBlendFactors VerticalBlend { get; }

        public EmfPlusBlendFactors HorizontalBlend { get; }

        public override uint Size
        {
            get
            {
                uint result = 0;

                if (Transform != null)
                {
                    result += Transform.Size;
                }
                if (PresetColors != null)
                {
                    result += PresetColors.Size;
                }
                if (VerticalBlend != null)
                {
                    result += PresetColors.Size;
                }
                if (HorizontalBlend != null)
                {
                    result += PresetColors.Size;
                }

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
            if (PresetColors != null)
            {
                foreach (RecordValues values in PresetColors.GetValues())
                {
                    yield return values;
                }
            }
            if (VerticalBlend != null)
            {
                foreach (RecordValues values in VerticalBlend.GetValues())
                {
                    yield return values;
                }
            }
            if (HorizontalBlend != null)
            {
                foreach (RecordValues values in HorizontalBlend.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
