namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines color curve effects that can be applied to an image.
    /// [MS-EMFPLUS] section 2.1.1.7
    /// </summary>
    public enum CurveAdjustments
    {
        /// <summary>
        /// Specifies the simulation of increasing or decreasing the exposure of an image.
        /// </summary>
        AdjustExposure = 0x00000000,

        /// <summary>
        /// Specifies the simulation of increasing or decreasing the density of an image
        /// </summary>
        AdjustDensity = 0x00000001,

        /// <summary>
        /// Specifies an increase or decrease of the contrast of an image.
        /// </summary>
        AdjustContrast = 0x00000002,

        /// <summary>
        /// Specifies an increase or decrease of the value of a color channel of an image,
        /// if that channel already has a value that is above half intensity. This
        /// adjustment can be used to increase definition in the light areas of an image
        /// without affecting the dark areas.
        /// </summary>
        AdjustHighlight = 0x00000003,

        /// <summary>
        /// Specifies an increase or decrease of the value of a color channel of an image,
        /// if that channel already has a value that is below half intensity. This
        /// adjustment can be used to increase efinition in the dark areas of an image
        /// without affecting the light areas.
        /// </summary>
        AdjustShadow = 0x00000004,

        /// <summary>
        /// Specifies an adjustment that lightens or darkens an image. Color channel values
        /// in the middle of the intensity range are altered more than color channel values
        /// near the minimum or maximum extremes of intensity.
        /// This adjustment can be used to lighten or darken an image without losing the
        /// contrast between the darkest and lightest parts of the image.
        /// </summary>
        AdjustMidtone = 0x00000005,

        /// <summary>
        /// Specifies an adjustment to the white saturation of an image, defined as the
        /// maximum value in the range of intensities for a given color channel, whose range
        /// is typically 0 to 255.
        /// </summary>
        AdjustWhiteSaturation = 0x00000006,

        /// <summary>
        /// Specifies an adjustment to the black saturation of an image, which is the
        /// minimum value in the range of intensities for a given color channel,
        /// which is typically 0 to 255
        /// </summary>
        AdjustBlackSaturation = 0x00000007
    }
}
