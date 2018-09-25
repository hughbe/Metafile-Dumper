using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Clears the output coordinate space and initializes it with a background
    /// color and transparency.
    /// [MS-EMFPLUS] 2.3.4.1
    /// </summary>
    public class EmfPlusClear : EmfPlusRecord
    {
        public EmfPlusClear(MetafileReader reader) : base(reader)
        {
            Color = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusClear";

        /// <summary>
        /// An EmfPlusARGB object that defines the color to paint the screen.
        /// All colors are specified in [IEC-RGB], unless otherwise noted.
        /// </summary>
        public uint Color { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Color", 4);
        }
    }
}
