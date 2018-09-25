using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies properties of graphics brushes. 
    /// [MS-EMFPLUS] 2.1.2.1
    /// </summary>
    [Flags]
    public enum BrushDataFlags
    {
        /// <summary>
        /// This flag is meaningful in EmfPlusPathGradientBrushData objects.
        /// If set, an EmfPlusBoundaryPathData object MUST be specified in the
        /// BoundaryData field of the brush data object.
        /// If clear, an EmfPlusBoundaryPointData object MUST be specified in the
        /// BoundaryData field of the brush data object.
        /// </summary>
        HasPath = 0x00000001,

        /// <summary>
        /// This flag is meaningful in EmfPlusLinearGradientBrushData objects,
        /// EmfPlusPathGradientBrushData objects, and EmfPlusTextureBrushData objects.
        /// If set, a 2x3 world space to device space transform matrix MUST be specified
        /// in the OptionalData field of the brush data object.
        /// </summary>
        HasTransform = 0x00000002,

        /// <summary>
        /// This flag is meaningful in EmfPlusLinearGradientBrushData and
        /// EmfPlusPathGradientBrushData objects.
        /// If set, an EmfPlusBlendColors object MUST be specified in the OptionalData field
        /// of the brush data object.
        /// </summary>
        HasPresetColors = 0x00000004,

        /// <summary>
        /// This flag is meaningful in EmfPlusLinearGradientBrushData and
        /// EmfPlusPathGradientBrushData objects.
        /// If set, an EmfPlusBlendFactors object that specifies a blend pattern along a
        /// horizontal gradient MUST be specified in the OptionalData field of the brush
        /// data object.
        /// </summary>
        HasHorizontalBlendColors = 0x00000008,

        /// <summary>
        /// This flag is meaningful in EmfPlusLinearGradientBrushData objects.
        /// If set, an EmfPlusBlendFactors object that specifies a blend pattern along a
        /// vertical gradient MUST be specified in the OptionalData field of the brush data
        /// object.
        /// </summary>
        HasVerticalBlendColors = 0x00000010,

        /// <summary>
        /// This flag is meaningful in EmfPlusPathGradientBrushData objects.
        /// If set, an EmfPlusFocusScaleData object MUST be specified in the OptionalData
        /// field of the brush data object.
        /// </summary>
        HasFocusScales = 0x00000040,

        /// <summary>
        /// This flag is meaningful in EmfPlusLinearGradientBrushData,
        /// EmfPlusPathGradientBrushData, and EmfPlusTextureBrushData objects.
        /// If set, the brush MUST already be gamma corrected; that is, output brightness
        /// and intensity have been corrected to match the input image.
        /// </summary>
        IsGammaCorrected = 0x00000080,

        /// <summary>
        /// This flag is meaningful in EmfPlusTextureBrushData objects.
        /// If set, a world space to device space transform SHOULD NOT be applied to the
        /// texture brush.
        /// </summary>
        DoNotTransform = 0x00000100
    }
}
