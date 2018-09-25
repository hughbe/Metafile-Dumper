using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a solid color for a graphics brush.
    /// [MS-EMFPLUS] Section 2.2.2.43
    /// </summary>
    public class EmfPlusSolidBrushData : EmfPlusBrushDataBase
    {
        public EmfPlusSolidBrushData(MetafileReader reader) : base(BrushType.SolidColor)
        {
            Color = reader.ReadUInt32();
        }

        public override uint Size => 4;

        /// <summary>
        /// An EmfPlusARGB object that specifies the color of the brush.
        /// </summary>
        public uint Color { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Color", 4);
        }
    }
}
