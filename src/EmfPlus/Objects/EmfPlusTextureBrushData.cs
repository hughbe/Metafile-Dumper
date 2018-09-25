using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a texture image for a graphics brush.
    /// [MS-EMFPLUS] 2.2.2.45
    /// </summary>
    public class EmfPlusTextureBrushData : EmfPlusBrushDataBase
    {
        public EmfPlusTextureBrushData(MetafileReader reader) : base(BrushType.TextureFill)
        {
            Flags = (BrushDataFlags)reader.ReadUInt32();
            WrapMode = (WrapMode)reader.ReadInt32();
            OptionalData = new EmfPlusTextureBrushOptionalData(reader, Flags, Size - 8);
        }

        public override uint Size => 4 + 4 + 4;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the data in the OptionalData field.
        /// This value MUST be composed of BrushData flags.
        /// </summary>
        public BrushDataFlags Flags { get; }

        /// <summary>
        /// A 32-bit signed integer from the WrapMode enumeration that specifies how to
        /// repeat the texture image across a shape, when the image is smaller than the
        /// area being filled.
        /// </summary>
        public WrapMode WrapMode { get; }

        /// <summary>
        /// An optional EmfPlusTextureBrushOptionalData object that specifies additional
        /// data for the texture brush.
        /// The specific contents of this field are determined by the value of the
        /// BrushDataFlags field.
        /// </summary>
        public EmfPlusTextureBrushOptionalData OptionalData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Flags",     4);
            yield return new RecordValues("Wrap Mode", 4);

            foreach (RecordValues values in OptionalData.GetValues())
            {
                yield return values;
            }
        }
    }
}
