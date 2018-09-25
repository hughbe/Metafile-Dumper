using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class ColorBalanceEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Cyan Red */      0x01, 0x00, 0x00, 0x00,
                /* Magenta Green */ 0x02, 0x00, 0x00, 0x00,
                /* Yellow Blue */   0x03, 0x00, 0x00, 0x00
            }, 0);

            var effect = new ColorBalanceEffect(reader);
            Assert.Equal(1, effect.CyanRed);
            Assert.Equal(2, effect.MagentaGreen);
            Assert.Equal(3, effect.YellowBlue);
            Assert.Equal(12u, effect.Size);
            Assert.Equal(new Guid("{537E597D-251E-48DA-9664-29CA496B70F8}"), effect.Identifier);
        }
    }
}
