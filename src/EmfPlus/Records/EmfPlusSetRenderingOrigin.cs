using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the rendering origin for graphics output.
    /// [MS-EMFPLUS] 2.3.6.6
    /// </summary>
    public class EmfPlusSetRenderingOrigin : EmfPlusRecord
    {
        public EmfPlusSetRenderingOrigin(MetafileReader reader) : base(reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();
        }

        public override string Name => "EmfPlusSetRenderingOrigin";

        /// <summary>
        /// A 32-bit unsigned integer that defines the horizontal coordinate
        /// value of the rendering origin.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// A 32-bit unsigned integer that defines the vertical coordinate
        /// value of the rendering origin.
        /// </summary>
        public int Y { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("X", 4);
            yield return new RecordValues("Y", 4);
        }
    }
}
