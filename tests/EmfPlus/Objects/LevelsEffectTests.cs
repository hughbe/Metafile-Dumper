using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class LevelsEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Highlight */ 0x01, 0x00, 0x00, 0x00,
                /* Mid Tone */  0x02, 0x00, 0x00, 0x00,
                /* Shadow */    0x03, 0x00, 0x00, 0x00
            }, 0);

            var effect = new LevelsEffect(reader);
            Assert.Equal(1, effect.Highlight);
            Assert.Equal(2, effect.MidTone);
            Assert.Equal(3, effect.Shadow);
            Assert.Equal(12u, effect.Size);
            Assert.Equal(new Guid("{99C354EC-2A31-4F3A-8C34-17A803B33A25}"), effect.Identifier);
        }
    }
}
