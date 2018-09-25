using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies an ordered pair of integer (X,Y) values that defines an absolute
    /// location in a coordinate space.
    /// [MS-EMFPLUS] 2.2.2.35
    /// </summary>
    public class EmfPlusPoint : EmfPlusPointBase
    {
        public EmfPlusPoint(MetafileReader reader)
        {
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
        }

        public override uint Size => 4;

        /// <summary>
        /// A 16-bit signed integer that defines the horizontal coordinate.
        /// </summary>
        public short X { get; }

        /// <summary>
        /// A 16-bit signed integer that defines the vertical coordinate.
        /// </summary>
        public short Y { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 2);
            yield return new RecordValues("Y", 2);
        }
    }
}
