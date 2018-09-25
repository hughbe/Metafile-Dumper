using System;

namespace MetafileDumper.EmfPlus.Constants
{
    public static class ImageEffects
    {
        public static Guid BlurEffectGuid { get; } = new Guid("{633C80A4-1843-482B-9EF2-BE2834C5FDD4}");

        public static Guid BrightnessContrastEffectGuid { get; } = new Guid("{D3A1DBE1-8EC4-4C17-9F4C-EA97AD1C343D}");

        public static Guid ColorBalanceEffectGuid { get; } = new Guid("{537E597D-251E-48DA-9664-29CA496B70F8}");

        public static Guid ColorCurveEffectGuid { get; } = new Guid("{DD6A0022-58E4-4A67-9D9B-D48EB881A53D}");

        public static Guid ColorLookupTableEffectGuid { get; } = new Guid("{A7CE72A9-0F7F-40D7-B3CC-D0C02D5C3212}");

        public static Guid ColorMatrixEffectGuid { get; } = new Guid("{718F2615-7933-40E3-A511-5F68FE14DD74}");

        public static Guid HueSaturationLightnessEffectGuid { get; } = new Guid("{8B2DD6C3-EB07-4D87-A5F0-7108E26A9C5F}");

        public static Guid LevelsEffectGuid { get; } = new Guid("{99C354EC-2A31-4F3A-8C34-17A803B33A25}");

        public static Guid RedEyeCorrectionEffectGuid { get; } = new Guid("{74D29D05-69A4-4266-9549-3CC52836B632}");

        public static Guid SharpenEffectGuid { get; } = new Guid("{63CBF3EE-C526-402C-8F71-62C540BF5142}");

        public static Guid TintEffectGuid { get; } = new Guid("{1077AF00-2848-4441-9489-44AD4C2D7A2C}");
    }
}
