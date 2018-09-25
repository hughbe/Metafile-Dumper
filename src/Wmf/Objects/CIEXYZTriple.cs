using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines information about the CIEXYZTriple color object.
    /// [MS-WMF] 2.2.2.7
    /// </summary>
    public class CIEXYZTriple : ObjectBase
    {
        public CIEXYZTriple(MetafileReader reader)
        {
            Red = new CIEXYZ(reader);
            Green = new CIEXYZ(reader);
            Blue = new CIEXYZ(reader);
        }

        public override uint Size => 36;

        public CIEXYZ Red { get; }
        public CIEXYZ Green { get; }
        public CIEXYZ Blue { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Red",   12);
            yield return new RecordValues("Green", 12);
            yield return new RecordValues("Blue",  12);
        }
    }
}
