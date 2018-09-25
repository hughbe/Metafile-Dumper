using System;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// The EmfPlusPointR object specifies an ordered pair of integer (X,Y) values that define
    /// a relative location in a coordinate space.
    /// [MS-EMFPLUS] 2.2.2.37
    /// </summary>
    public class EmfPlusPointR : ObjectBase
    {
        public EmfPlusPointR(byte[] buffer, int index)
        {
            Buffer = buffer;
            Index = index;

            // TODO: 7 bits or 15 bits.
            X = BitConverter.ToInt16(buffer, index);
            Y = BitConverter.ToInt16(buffer, index + 4);
        }

        public byte[] Buffer { get; }
        public int Index { get; }
        public override uint Size => 4;

        /// <summary>
        /// A signed integer that specifies the horizontal coordinate.
        /// This value MUST be specified by either an EmfPlusInteger7 object or an
        /// EmfPlusInteger15 object.
        /// </summary>
        public short X { get; }

        /// <summary>
        /// A signed integer that specifies the vertical coordinate.
        /// This value MUST be specified by either an EmfPlusInteger7 object or an
        /// EmfPlusInteger15 object
        /// </summary>
        public short Y { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 2);
            yield return new RecordValues("Y", 2);
        }
    }
}
