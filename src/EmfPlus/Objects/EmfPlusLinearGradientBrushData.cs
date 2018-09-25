using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a linear gradient for a graphics brush.
    /// [MS-EMFPLUS] 2.2.2.24
    /// </summary>
    public class EmfPlusLinearGradientBrushData : EmfPlusBrushDataBase
    {
        public EmfPlusLinearGradientBrushData(MetafileReader reader) : base(BrushType.LinearGradient)
        {
            Flags = (BrushDataFlags)reader.ReadUInt32();
            WrapMode = (WrapMode)reader.ReadInt32();
            Points = new EmfPlusRectF(reader);
            StartColor = reader.ReadUInt32();
            EndColor = reader.ReadUInt32();
            Reserved1 = reader.ReadUInt32();
            Reserved2 = reader.ReadUInt32();
            OptionalData = new EmfPlusLinearGradientBrushOptionalData(reader, Flags);
        }

        public override uint Size => 40 + OptionalData.Size;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the data in the OptionalData field.
        /// This value MUST be composed of BrushData flags.
        /// </summary>
        public BrushDataFlags Flags { get; }

        /// <summary>
        /// A 32-bit signed integer from the WrapMode enumeration that specifies whether
        /// to paint the area outside the boundary of the brush.
        /// When painting outside the boundary, the wrap mode specifies how the color
        /// gradient is repeated.
        /// </summary>
        public WrapMode WrapMode { get; }

        /// <summary>
        /// An EmfPlusRectF object that specifies the starting and ending points of the
        /// gradient line.
        /// The upper-left corner of the rectangle is the starting point.
        /// The lower-right corner is the ending point.
        /// </summary>
        public EmfPlusRectF Points { get; }

        /// <summary>
        /// An EmfPlusARGB object, which specifies the color at the starting boundary
        /// point of the linear gradient brush.
        /// </summary>
        public uint StartColor { get; }

        /// <summary>
        /// An EmfPlusARGB object that specifies the color at the ending boundary point of
        /// the linear gradient brush.
        /// </summary>
        public uint EndColor { get; }

        /// <summary>
        /// This field is reserved and SHOULD be ignored.
        /// </summary>
        public uint Reserved1 { get; }

        /// <summary>
        /// This field is reserved and SHOULD be ignored.
        /// </summary>
        public uint Reserved2 { get; }

        /// <summary>
        /// An optional EmfPlusLinearGradientBrushOptionalData object that specifies
        /// additional data for the linear gradient brush.
        /// The specific contents of this field are determined by the value of the
        /// BrushDataFlags field.
        /// </summary>
        public EmfPlusLinearGradientBrushOptionalData OptionalData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Flags",       4);
            yield return new RecordValues("Wrap Mode",   4);
            yield return new RecordValues("Points",      16);
            yield return new RecordValues("Start Color", 4);
            yield return new RecordValues("End Color",   4);
            yield return new RecordValues("Reserved1",   4);
            yield return new RecordValues("Reserved2",   4);

            foreach (RecordValues values in OptionalData.GetValues())
            {
                yield return values;
            }
        }
    }
}
