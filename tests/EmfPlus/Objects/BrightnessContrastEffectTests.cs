using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class BrightnessContrastEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Brightness Level */ 0x01, 0x00, 0x00, 0x00,
                /* Contrast Level */   0x02, 0x00, 0x00, 0x00
            }, 0);

            var effect = new BrightnessContrastEffect(reader);
            Assert.Equal(1, effect.BrightnessLevel);
            Assert.Equal(2, effect.ContrastLevel);
            Assert.Equal(8u, effect.Size);
            Assert.Equal(new Guid("{D3A1DBE1-8EC4-4C17-9F4C-EA97AD1C343D}"), effect.Identifier);
        }
    }
}
