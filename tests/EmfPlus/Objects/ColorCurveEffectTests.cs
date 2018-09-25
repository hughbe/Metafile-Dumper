using MetafileDumper.EmfPlus.Enumerations;
using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class ColorCurveEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Curve Adjustment */     0x01, 0x00, 0x00, 0x00,
                /* Curve Channel */        0x02, 0x00, 0x00, 0x00,
                /* Adjustment Intensity */ 0x03, 0x00, 0x00, 0x00
            }, 0);

            var effect = new ColorCurveEffect(reader);
            Assert.Equal((CurveAdjustments)1, effect.CurveAdjustment);
            Assert.Equal((CurveChannel)2, effect.CurveChannel);
            Assert.Equal(3, effect.AdjustmentIntensity);
            Assert.Equal(12u, effect.Size);
            Assert.Equal(new Guid("{DD6A0022-58E4-4A67-9D9B-D48EB881A53D}"), effect.Identifier);
        }
    }
}
