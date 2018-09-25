using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies adjustable arrow data for a custom line cap.
    /// [MS-EMFPLUS] 2.2.2.12
    /// </summary>
    public class EmfPlusCustomLineCapArrowData : EmfPlusCustomLineCapDataBase
    {
        public EmfPlusCustomLineCapArrowData(MetafileReader reader) : base(CustomLineCapDataType.AdjustableArrow)
        {
            Width = reader.ReadSingle();
            Height = reader.ReadSingle();
            MiddleInset = reader.ReadSingle();
            FillState = reader.ReadBoolean();
            StartCap = (LineCapType)reader.ReadUInt32();
            EndCap = (LineCapType)reader.ReadUInt32();
            Join = (LineJoinType)reader.ReadUInt32();
            MiterLimit = reader.ReadSingle();
            WidthScale = reader.ReadSingle();
            FillHotSpot = new EmfPlusPointF(reader);
            LineHotSpot = new EmfPlusPointF(reader);
        }

        public override uint Size => 28;

        /// <summary>
        /// A 32-bit floating-point value that specifies the width of the arrow cap.
        /// The width of the arrow cap is scaled by the width of the EmfPlusPen object
        /// that is used to draw the line being capped. For example, when drawing a capped
        /// line with a pen that has a width of 5 pixels, and the adjustable arrow cap
        /// object has a width of 3, the actual arrow cap is drawn 15 pixels wide.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the height of the arrow cap.
        /// The height of the arrow cap is scaled by the width of the EmfPlusPen object
        /// that is used to draw the line being capped.For example, when drawing a capped
        /// line with a pen that has a width of 5 pixels, and the adjustable arrow cap
        /// object has a height of 3, the actual arrow cap is drawn 15 pixels high.
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the number of pixels between the
        /// outline of the arrow cap and the fill of the arrow cap.
        /// </summary>
        public float MiddleInset { get; }

        /// <summary>
        /// A 32-bit Boolean value that specifies whether the arrow cap is filled.
        /// If the arrow cap is not filled, only the outline is drawn.
        /// </summary>
        public bool FillState { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineCap enumeration
        /// that indicates the line cap to be used at the start of the line to be drawn.
        /// </summary>
        public LineCapType StartCap { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineCap enumeration
        /// that indicates the line cap to be used at the end of the line to be drawn.
        /// </summary>
        public LineCapType EndCap { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineJoin enumeration
        /// that specifies how to join two lines that are drawn by the same pen and whose
        /// ends meet.
        /// At the intersection of the two line ends, a line join makes the connection
        /// look more continuous.
        /// </summary>
        public LineJoinType Join { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the limit of the thickness of the
        /// join on a mitered corner by setting the maximum allowed ratio of miter length
        /// to line width.
        /// </summary>
        public float MiterLimit { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the amount by which to scale an
        /// EmfPlusCustomLineCap object with respect to the width of the graphics pen
        /// that is used to draw the lines.
        /// </summary>
        public float WidthScale { get; }

        /// <summary>
        /// An EmfPlusPointF object that is not currently used.
        /// It MUST be set to {0.0, 0.0}.
        /// </summary>
        public EmfPlusPointF FillHotSpot { get; }

        /// <summary>
        /// An EmfPlusPointF object that is not currently used.
        /// It MUST be set to {0.0, 0.0}.
        /// </summary>
        public EmfPlusPointF LineHotSpot { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Width",        4);
            yield return new RecordValues("Height",       4);
            yield return new RecordValues("Middle Inset", 4);
            yield return new RecordValues("Fill State",   4);
            yield return new RecordValues("Start Cap",    4);
            yield return new RecordValues("End Cap",      4);
            yield return new RecordValues("Join",         4);
            yield return new RecordValues("Miter Limit",  4);
            yield return new RecordValues("Width Scale",  4);

            foreach (RecordValues values in FillHotSpot.GetValues())
            {
                yield return new RecordValues("Fill Hot Spot " + values.Name, values.Length);
            }
            foreach (RecordValues values in LineHotSpot.GetValues())
            {
                yield return new RecordValues("Line Hot Spot " + values.Name, values.Length);
            }
        }
    }
}
