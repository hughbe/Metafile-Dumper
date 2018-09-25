using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines information about the CIEXYZ chromaticity object
    /// [MS-WMF] 2.2.2.9
    /// </summary>
    public class CIEXYZ : ObjectBase
    {
        public CIEXYZ(MetafileReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
        }

        public override uint Size => 12;

        /// <summary>
        /// A 32-bit 2.30 fixed point type that defines the x chromaticity value.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// A 32-bit 2.30 fixed point type that defines the y chromaticity value.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// A 32-bit 2.30 fixed point type that defines the z chromaticity value.
        /// </summary>
        public float Z { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 4);
            yield return new RecordValues("Y", 4);
            yield return new RecordValues("Z", 4);
        }
    }
}
