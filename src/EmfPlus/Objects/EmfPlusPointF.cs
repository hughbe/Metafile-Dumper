using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an ordered pair of floating-point (X,Y) values that defines an
    /// absolute location in a coordinate space.
    /// [MS-EMFPLUS] 2.2.2.36
    /// </summary>
    public class EmfPlusPointF : EmfPlusPointBase
    {
        public EmfPlusPointF(MetafileReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 32-bit floating-point value that specifies the horizontal coordinate.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the vertical coordinate.
        /// </summary>
        public float Y { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 4);
            yield return new RecordValues("Y", 4);
        }
    }
}
