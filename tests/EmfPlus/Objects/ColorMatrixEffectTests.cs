using System;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class ColorMatrixEffectTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Matrix_N_0 */ 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00,
                /* Matrix_N_1 */ 0x05, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00,
                /* Matrix_N_2 */ 0x0A, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x0D, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00,
                /* Matrix_N_3 */ 0x0F, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x11, 0x00, 0x00, 0x00, 0x12, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00,
                /* Matrix_N_4 */ 0x14, 0x00, 0x00, 0x00, 0x15, 0x00, 0x00, 0x00, 0x16, 0x00, 0x00, 0x00, 0x17, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00,
            }, 0);

            var effect = new ColorMatrixEffect(reader);
            Assert.Equal(0, effect.Matrix0.Matrix0);
            Assert.Equal(1, effect.Matrix0.Matrix1);
            Assert.Equal(2, effect.Matrix0.Matrix2);
            Assert.Equal(3, effect.Matrix0.Matrix3);
            Assert.Equal(4, effect.Matrix0.Matrix4);
            Assert.Equal(5, effect.Matrix1.Matrix0);
            Assert.Equal(6, effect.Matrix1.Matrix1);
            Assert.Equal(7, effect.Matrix1.Matrix2);
            Assert.Equal(8, effect.Matrix1.Matrix3);
            Assert.Equal(9, effect.Matrix1.Matrix4);
            Assert.Equal(10, effect.Matrix2.Matrix0);
            Assert.Equal(11, effect.Matrix2.Matrix1);
            Assert.Equal(12, effect.Matrix2.Matrix2);
            Assert.Equal(13, effect.Matrix2.Matrix3);
            Assert.Equal(14, effect.Matrix2.Matrix4);
            Assert.Equal(15, effect.Matrix3.Matrix0);
            Assert.Equal(16, effect.Matrix3.Matrix1);
            Assert.Equal(17, effect.Matrix3.Matrix2);
            Assert.Equal(18, effect.Matrix3.Matrix3);
            Assert.Equal(19, effect.Matrix3.Matrix4);
            Assert.Equal(20, effect.Matrix4.Matrix0);
            Assert.Equal(21, effect.Matrix4.Matrix1);
            Assert.Equal(22, effect.Matrix4.Matrix2);
            Assert.Equal(23, effect.Matrix4.Matrix3);
            Assert.Equal(24, effect.Matrix4.Matrix4);
            Assert.Equal(100u, effect.Size);
            Assert.Equal(new Guid("{718F2615-7933-40E3-A511-5F68FE14DD74}"), effect.Identifier);
        }
    }
}
