using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    public class ColorMatrix : ObjectBase
    {
        public ColorMatrix(MetafileReader reader)
        {
            Matrix0 = reader.ReadInt32();
            Matrix1 = reader.ReadInt32();
            Matrix2 = reader.ReadInt32();
            Matrix3 = reader.ReadInt32();
            Matrix4 = reader.ReadInt32();
        }

        public override uint Size => 20;

        public int Matrix0 { get; }
        public int Matrix1 { get; }
        public int Matrix2 { get; }
        public int Matrix3 { get; }
        public int Matrix4 { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Data", 20);
        }
    }
}
