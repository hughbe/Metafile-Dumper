using MetafileDumper.Wmf.Data;
using System;
using System.Linq;
using Xunit;

namespace MetafileDumper.EmfPlus.Objects.Tests
{
    public class RedEyeCorrectionEffectTests
    {
        [Fact]
        public void Ctor_Reader_Negative()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Number of Areas */ 0xFF, 0xFF, 0xFF, 0xFF
            }, 0);

            var effect = new RedEyeCorrectionEffect(reader);
            Assert.Equal(-1, effect.NumberOfAreas);
            Assert.Empty(effect.Areas);
            Assert.Equal(4u, effect.Size);
            Assert.Equal(new Guid("{74D29D05-69A4-4266-9549-3CC52836B632}"), effect.Identifier);
        }

        [Fact]
        public void Ctor_Reader_Zero()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Number of Areas */ 0x00, 0x00, 0x00, 0x00
            }, 0);

            var effect = new RedEyeCorrectionEffect(reader);
            Assert.Equal(0, effect.NumberOfAreas);
            Assert.Empty(effect.Areas);
            Assert.Equal(4u, effect.Size);
            Assert.Equal(new Guid("{74D29D05-69A4-4266-9549-3CC52836B632}"), effect.Identifier);
        }

        [Fact]
        public void Ctor_Reader_Positive()
        {
            var reader = new MetafileReader(new byte[]
            {
                /* Number of Areas */ 0x02, 0x00, 0x00, 0x00,
                /* Left 1 */          0x01, 0x00, 0x00, 0x00,
                /* Top 1 */           0x02, 0x00, 0x00, 0x00,
                /* Right 1 */         0x03, 0x00, 0x00, 0x00,
                /* Bottom 1 */        0x04, 0x00, 0x00, 0x00,
                /* Left 1 */          0x05, 0x00, 0x00, 0x00,
                /* Top 1 */           0x06, 0x00, 0x00, 0x00,
                /* Right 1 */         0x07, 0x00, 0x00, 0x00,
                /* Bottom 1 */        0x08, 0x00, 0x00, 0x00,
            }, 0);

            var effect = new RedEyeCorrectionEffect(reader);
            Assert.Equal(2, effect.NumberOfAreas);

            RectL[] rects = effect.Areas.ToArray();
            Assert.Equal(2, rects.Length);
            Assert.Equal(1, rects[0].Left);
            Assert.Equal(2, rects[0].Top);
            Assert.Equal(3, rects[0].Right);
            Assert.Equal(4, rects[0].Bottom);
            Assert.Equal(5, rects[1].Left);
            Assert.Equal(6, rects[1].Top);
            Assert.Equal(7, rects[1].Right);
            Assert.Equal(8, rects[1].Bottom);

            Assert.Equal(36u, effect.Size);
            Assert.Equal(new Guid("{74D29D05-69A4-4266-9549-3CC52836B632}"), effect.Identifier);
        }
    }
}
