using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class HueSaturationLightnessEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Hue Level */        0x01, 0x00, 0x00, 0x00,
                /* Saturation Level */ 0x02, 0x00, 0x00, 0x00,
                /* Lightness Level */  0x03, 0x00, 0x00, 0x00
            }, 0);

            var effect = new HueSaturationLightnessEffect(reader);
            Assert.Equal(1, effect.HueLevel);
            Assert.Equal(2, effect.SaturationLevel);
            Assert.Equal(3, effect.LightnessLevel);
            Assert.Equal(12u, effect.Size);
            Assert.Equal(new Guid("{8B2DD6C3-EB07-4D87-A5F0-7108E26A9C5F}"), effect.Identifier);
        }
    }
}
