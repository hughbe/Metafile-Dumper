using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a path gradient for a graphics brush.
    /// [MS-EMFPLUS] 2.2.2.29
    /// </summary>
    public class EmfPlusPathGradientBrushData : EmfPlusBrushDataBase
    {
        public EmfPlusPathGradientBrushData(MetafileReader reader) : base(BrushType.PathGradient)
        {
            Flags = (BrushDataFlags)reader.ReadUInt32();
            WrapMode = (WrapMode)reader.ReadInt32();
            CenterColor = reader.ReadUInt32();
            CenterPoint = new EmfPlusPointF(reader);
            SurroundingColorCount = reader.ReadUInt32();
            SurroundingColors = Utilities.ReadUInt32s(reader, SurroundingColorCount);
            if ((Flags & BrushDataFlags.HasPath) != 0)
            {
                BoundaryData = new EmfPlusBoundaryPathData(reader);
            }
            else
            {
                BoundaryData = new EmfPlusBoundaryPointData(reader);
            }
            OptionalData = new EmfPlusPathGradientBrushOptionalData(reader, Flags);
        }

        public override uint Size => 24 + SurroundingColorCount * 4 + BoundaryData.Size + OptionalData.Size;

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
        /// An EmfPlusARGB object that specifies the center color of the path gradient
        /// brush, which is the color that appears at the center point of the brush.
        /// The color of the brush changes gradually from the boundary color to the
        /// center color as it moves from the boundary to the center point.
        /// </summary>
        public uint CenterColor { get; }

        /// <summary>
        /// An EmfPlusPointF object that specifies the center point of the path gradient
        /// brush, which can be any location inside or outside the boundary.
        /// The color of the brush changes gradually from the boundary color to the
        /// center color as it moves from the boundary to the center point.
        /// </summary>
        public EmfPlusPointF CenterPoint { get; }

        /// <summary>
        /// An unsigned 32-bit integer that specifies the number of colors specified in the
        /// SurroundingColor field.The surrounding colors are colors specified for discrete
        /// points on the boundary of the brush
        /// </summary>
        public uint SurroundingColorCount { get; }

        /// <summary>
        /// An array of SurroundingColorCount EmfPlusARGB objects that specify the colors
        /// for discrete points on the boundary of the brush.
        /// </summary>
        public IEnumerable<uint> SurroundingColors { get; }

        /// <summary>
        /// The boundary of the path gradient brush, which is specified by either a path
        /// or a closed cardinal spline.
        /// If the BrushDataPath flag is set in the BrushDataFlags field, this field
        /// MUST contain an EmfPlusBoundaryPathData object; otherwise, this field MUST
        /// contain an EmfPlusBoundaryPointData object.
        /// </summary>
        public ObjectBase BoundaryData { get; }

        /// <summary>
        /// An optional EmfPlusPathGradientBrushOptionalData object that specifies
        /// additional data for the path gradient brush.
        /// The specific contents of this field are determined by the value of the
        /// BrushDataFlags field.
        /// </summary>
        public EmfPlusPathGradientBrushOptionalData OptionalData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Flags",                   4);
            yield return new RecordValues("Wrap Mode",               4);
            yield return new RecordValues("Center Color",            4);
            yield return new RecordValues("Center Point",            8);
            yield return new RecordValues("Surrounding Color Count", 4);
            yield return new RecordValues("Surrounding Colors",      4 * SurroundingColorCount);

            foreach (RecordValues values in BoundaryData.GetValues())
            {
                yield return values;
            }
            foreach (RecordValues values in OptionalData.GetValues())
            {
                yield return values;
            }
        }
    }
}
