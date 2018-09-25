using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies default data for a custom line cap.
    /// [MS-EMFPLUS] 2.2.2.13
    /// </summary>
    public class EmfPlusCustomLineCapData : EmfPlusCustomLineCapDataBase
    {
        public EmfPlusCustomLineCapData(MetafileReader reader) : base(CustomLineCapDataType.Default)
        {
            Flags = (CustomLineCapDataFlags)reader.ReadUInt32();
            BaseCap = (LineCapType)reader.ReadUInt32();
            BaseInset = reader.ReadSingle();
            StrokeStartCap = (LineCapType)reader.ReadUInt32();
            StrokeEndCap = (LineCapType)reader.ReadUInt32();
            StrokeJoin = (LineJoinType)reader.ReadUInt32();
            StrokeMiterLimit = reader.ReadSingle();
            WidthScale = reader.ReadSingle();
            FillHotSpot = new EmfPlusPointF(reader);
            StrokeHotSpot = new EmfPlusPointF(reader);
            OptionalData = new EmfPlusCustomLineCapOptionalData(reader, Flags);
        }

        public override uint Size => 4 * 8 + 2 * 8 + OptionalData.Size;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the data in the OptionalData field.
        /// This value MUST be composed of CustomLineCapData flags.
        /// </summary>
        public CustomLineCapDataFlags Flags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value from the LineCap enumeration
        /// on which the custom line cap is based.
        /// </summary>
        public LineCapType BaseCap { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the distance between the beginning
        /// of the line cap and the end of the line.
        /// </summary>
        public float BaseInset { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineCap enumeration
        /// that indicates the line cap used at the start of the line to be drawn.
        /// </summary>
        public LineCapType StrokeStartCap { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineCap enumeration
        /// that indicates what line cap is to be used at the end of the line to be drawn.
        /// </summary>
        public LineCapType StrokeEndCap { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the value in the LineJoin enumeration,
        /// which specifies how to join two lines that are drawn by the same pen and whose
        /// ends meet.
        /// At the intersection of the two line ends, a line join makes the connection
        /// look more continuous.
        /// </summary>
        public LineJoinType StrokeJoin { get; }

        /// <summary>
        /// A 32-bit floating-point value that contains the limit of the thickness of the
        /// join on a mitered corner by setting the maximum allowed ratio of miter length
        /// to line width.
        /// </summary>
        public float StrokeMiterLimit { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the amount by which to scale the
        /// custom line cap with respect to the width of the EmfPlusPen object that is
        /// used to draw the lines.
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
        public EmfPlusPointF StrokeHotSpot { get; }

        /// <summary>
        /// An optional EmfPlusCustomLineCapOptionalData object that specifies additional
        /// data for the custom graphics line cap.
        /// The specific contents of this field are determined by the value of the
        /// CustomLineCapDataFlags field.
        /// </summary>
        public EmfPlusCustomLineCapOptionalData OptionalData { get; }

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
            foreach (RecordValues values in StrokeHotSpot.GetValues())
            {
                yield return new RecordValues("Line Hot Spot " + values.Name, values.Length);
            }

            foreach (RecordValues values in OptionalData.GetValues())
            {
                yield return values;
            }
        }
    }
}
