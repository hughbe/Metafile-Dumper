using System.Collections.Generic;

namespace MetafileDumper
{
    public abstract class ObjectBase
    {
        public abstract uint Size { get; }

        public abstract IEnumerable<RecordValues> GetValues();
    }
}
