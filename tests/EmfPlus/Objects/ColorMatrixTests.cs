using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class ColorMatrixTests
    {
        [Fact]
        public void Ctor_Reader()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* M0 */ 0x01, 0x00, 0x00, 0x00,
                /* M1 */ 0x02, 0x00, 0x00, 0x00,
                /* M2 */ 0x03, 0x00, 0x00, 0x00,
                /* M3 */ 0x04, 0x00, 0x00, 0x00,
                /* M4 */ 0x05, 0x00, 0x00, 0x00,
            }, 0);

            var effect = new ColorMatrix(reader);
            Assert.Equal(1, effect.Matrix0);
            Assert.Equal(2, effect.Matrix1);
            Assert.Equal(3, effect.Matrix2);
            Assert.Equal(4, effect.Matrix3);
            Assert.Equal(5, effect.Matrix4);
            Assert.Equal(20u, effect.Size);
        }
    }
}
