using System.Collections.Generic;

namespace MetafileDumper.EMFRecords.Data
{
    public class XForm : ObjectBase
    {
        public XForm(MetafileReader reader)
        {
            M11 = reader.ReadSingle();
            M21 = reader.ReadSingle();
            M12 = reader.ReadSingle();
            M22 = reader.ReadSingle();
            Dx = reader.ReadSingle();
            Dy = reader.ReadSingle();
        }

        public override uint Size => 20;

        public float M11 { get; }
        public float M21 { get; }
        public float M12 { get; }
        public float M22 { get; }
        public float Dx { get; }
        public float Dy { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("m11", 4);
            yield return new RecordValues("m21", 4);
            yield return new RecordValues("m12", 4);
            yield return new RecordValues("m22", 4);
            yield return new RecordValues("dx", 4);
            yield return new RecordValues("dy", 4);
        }
    }
}
