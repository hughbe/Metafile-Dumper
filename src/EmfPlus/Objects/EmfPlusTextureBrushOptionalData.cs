using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies optional data for a path gradient brush.
    /// [MS-EMFPLUS] 2.2.2.30
    /// </summary>
    public class EmfPlusPathGradientBrushOptionalData : ObjectBase
    {
        public EmfPlusPathGradientBrushOptionalData(MetafileReader reader, BrushDataFlags flags)
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
            if ((flags & BrushDataFlags.HasHorizontalBlendColors) != 0)
            {
                HorizontalBlend = new EmfPlusBlendFactors(reader);
            }
            
            if ((flags & BrushDataFlags.HasFocusScales) != 0)
            {
                FocusScaleData = new EmfPlusFocusScaleData(reader);
            }
        }

        /// <summary>
        /// An optional EmfPlusTransformMatrix object that specifies a world space to
        /// device space transform for the path gradient brush.
        /// This field MUST be present if the BrushDataTransform flag is set in the
        /// BrushDataFlags field of the EmfPlusPathGradientBrushData object.
        /// </summary>
        public EmfPlusTransformMatrix Transform { get; }

        public EmfPlusBlendColors PresetColors { get; }

        public EmfPlusBlendFactors HorizontalBlend { get; }

        /// <summary>
        /// An optional EmfPlusFocusScaleData object that specifies focus scales for
        /// the path gradient brush.
        /// This field MUST be present if the BrushDataFocusScales flag is set in the
        /// BrushDataFlags field of the EmfPlusPathGradientBrushData object.
        /// </summary>
        public EmfPlusFocusScaleData FocusScaleData { get; }

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
                if (HorizontalBlend != null)
                {
                    result += PresetColors.Size;
                }
                if (FocusScaleData != null)
                {
                    result += FocusScaleData.Size;
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
            if (HorizontalBlend != null)
            {
                foreach (RecordValues values in HorizontalBlend.GetValues())
                {
                    yield return values;
                }
            }
            if (FocusScaleData != null)
            {
                foreach (RecordValues values in FocusScaleData.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
