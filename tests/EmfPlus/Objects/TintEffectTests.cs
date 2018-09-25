using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class TintEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Hue */    0x01, 0x00, 0x00, 0x00,
                /* Amount */ 0x02, 0x00, 0x00, 0x00
            }, 0);

            var effect = new TintEffect(reader);
            Assert.Equal(1, effect.Hue);
            Assert.Equal(2, effect.Amount);
            Assert.Equal(8u, effect.Size);
            Assert.Equal(new Guid("{1077AF00-2848-4441-9489-44AD4C2D7A2C}"), effect.Identifier);
        }
    }
}
