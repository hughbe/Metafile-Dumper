using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class BlurEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Blur Radius */ 0x00, 0x00, 0x20, 0x41,
                /* Expand Edge */ 0x01, 0x00, 0x00, 0x00
            }, 0);

            var effect = new BlurEffect(reader);
            Assert.Equal(10, effect.BlurRadius);
            Assert.True(effect.ExpandEdge);
            Assert.Equal(8u, effect.Size);
            Assert.Equal(new Guid("{633C80A4-1843-482B-9EF2-BE2834C5FDD4}"), effect.Identifier);
        }
    }
}
