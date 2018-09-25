using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class SharpenEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Radius */ 0x00, 0x00, 0x20, 0x41,
                /* Amount */ 0x00, 0x00, 0x30, 0x41
            }, 0);

            var effect = new SharpenEffect(reader);
            Assert.Equal(10, effect.Radius);
            Assert.Equal(11, effect.Amount);
            Assert.Equal(8u, effect.Size);
            Assert.Equal(new Guid("{63CBF3EE-C526-402C-8F71-62C540BF5142}"), effect.Identifier);
        }
    }
}
