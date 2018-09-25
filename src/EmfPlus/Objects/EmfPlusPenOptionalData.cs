using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies optional data for a graphics pen.
    /// [MS-EMFPLUS] 2.2.2.34
    /// </summary>
    public class EmfPlusPenOptionalData : ObjectBase
    {
        public EmfPlusPenOptionalData(MetafileReader reader, PenDataFlags flags)
        {
            if ((flags & PenDataFlags.HasTransform) != 0)
            {
                Transform = new EmfPlusTransformMatrix(reader);
            }
            if ((flags & PenDataFlags.HasStartCap) != 0)
            {
                StartCap = (LineCapType)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasEndCap) != 0)
            {
                EndCap = (LineCapType)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasJoin) != 0)
            {
                Join = (LineJoinType)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasMiterLimit) != 0)
            {
                MiterLimit = reader.ReadSingle();
            }
            if ((flags & PenDataFlags.HasLineStyle) != 0)
            {
                LineStyle = (LineStyle)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasDashedLineCap) != 0)
            {
                DashedLineCap = (DashedLineCapType)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasDashedLineOffset) != 0)
            {
                DashOffset = reader.ReadSingle();
            }
            if ((flags & PenDataFlags.HasDashedLine) != 0)
            {
                DashLineData = new EmfPlusDashedLineData(reader);
            }
            if ((flags & PenDataFlags.HasNonCenter) != 0)
            {
                Alignment = (PenAlignment)reader.ReadInt32();
            }
            if ((flags & PenDataFlags.HasCompoundLine) != 0)
            {
                CompoundLineData = new EmfPlusCompoundLineData(reader);
            }
            if ((flags & PenDataFlags.HasCustomStartCap) != 0)
            {
                CustomStartCapData = new EmfPlusCustomStartCapData(reader);
            }
            if ((flags & PenDataFlags.HasCustomEndCap) != 0)
            {
                CustomEndCapData = new EmfPlusCustomEndCapData(reader);
            }
        }

        public override uint Size
        {
            get
            {
                uint size = 0;
                if (Transform != null)
                {
                    size += Transform.Size;
                }
                if (StartCap != null)
                {
                    size += 4;
                }
                if (EndCap != null)
                {
                    size += 4;
                }
                if (Join != null)
                {
                    size += 4;
                }
                if (MiterLimit != null)
                {
                    size += 4;
                }
                if (LineStyle != null)
                {
                    size += 4;
                }
                if (DashedLineCap != null)
                {
                    size += 4;
                }
                if (DashOffset != null)
                {
                    size += 4;
                }
                if (DashLineData != null)
                {
                    size += DashLineData.Size;
                }
                if (Alignment != null)
                {
                    size += 4;
                }
                if (CompoundLineData != null)
                {
                    size += CompoundLineData.Size;
                }
                if (CustomStartCapData != null)
                {
                    size += CustomStartCapData.Size;
                }
                if (CustomEndCapData != null)
                {
                    size += CustomEndCapData.Size;
                }

                return size;
            }
        }

        /// <summary>
        /// An optional EmfPlusTransformMatrix object that specifies a world space to
        /// device space transform for the pen.
        /// This field MUST be present if the PenDataTransform flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public EmfPlusTransformMatrix Transform { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies the shape for the start of a line
        /// in the CustomStartCapData field.
        /// This field MUST be present if the PenDataStartCap flag is set in the PenDataFlags
        /// field of the EmfPlusPenData object, and the value MUST be defined in the
        /// LineCapType enumeration.
        /// </summary>
        public LineCapType? StartCap { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies the shape for the end of a line
        /// in the CustomEndCapData field.
        /// This field MUST be present if the PenDataEndCap flag is set in the PenDataFlags
        /// field of the EmfPlusPenData object, and the value MUST be defined in the
        /// LineCapType enumeration.
        /// </summary>
        public LineCapType? EndCap { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies how to join two lines that are
        /// drawn by the same pen and whose ends meet.
        /// This field MUST be present if the PenDataJoin flag is set in the PenDataFlags
        /// field of the EmfPlusPenData object, and the value MUST be defined in the
        /// LineJoinType enumeration.
        /// </summary>
        public LineJoinType? Join { get; }

        /// <summary>
        /// An optional 32-bit floating-point value that specifies the miter limit, which is
        /// the maximum allowed ratio of miter length to line width.
        /// The miter length is the distance from the intersection of the line walls on the
        /// inside the join to the intersection of the line walls outside the join.
        /// The miter length can be large when the angle between two lines is small.
        /// This field MUST be present if the PenDataMiterLimit flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public float? MiterLimit { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies the style used for lines drawn
        /// with this pen object.
        /// This field MUST be present if the PenDataLineStyle flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object, and the value MUST be defined
        /// in the LineStyle enumeration.
        /// </summary>
        public LineStyle? LineStyle { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies the shape for both ends of
        /// each dash in a dashed line.
        /// This field MUST be present if the PenDataDashedLineCap flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object, and the value MUST be
        /// defined in the DashedLineCapType enumeration
        /// </summary>
        public DashedLineCapType? DashedLineCap { get; }

        /// <summary>
        /// An optional 32-bit floating-point value that specifies the distance from the
        /// start of a line to the start of the first space in a dashed line pattern.
        /// This field MUST be present if the PenDataDashedLineOffset flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public float? DashOffset { get; }

        /// <summary>
        /// An optional EmfPlusDashedLineData object that specifies the lengths of
        /// dashes and spaces in a custom dashed line.
        /// This field MUST be present if the PenDataDashedLine flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public EmfPlusDashedLineData DashLineData { get; }

        /// <summary>
        /// An optional 32-bit signed integer that specifies the distribution of the pen
        /// width with respect to the coordinates of the line being drawn.
        /// This field MUST be present if the PenDataNonCenter flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object, and the value MUST be defined
        /// in the PenAlignment enumeration.
        /// </summary>
        public PenAlignment? Alignment { get; }

        /// <summary>
        /// An optional EmfPlusCompoundLineData object that specifies an array of
        /// floating-point values that define the compound line of a pen, which is made up
        /// of parallel lines and spaces.
        /// This field MUST be present if the PenDataCompoundLine flag is set in the 
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public EmfPlusCompoundLineData CompoundLineData { get; }

        /// <summary>
        /// An optional EmfPlusCustomStartCapData object that defines the custom start-cap
        /// shape, which is the shape to use at the start of a line drawn with this pen.
        /// It can be any of various shapes, such as a square, circle, or diamond.
        /// This field MUST be present if the PenDataCustomStartCap flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public EmfPlusCustomStartCapData CustomStartCapData { get; }

        /// <summary>
        /// An optional EmfPlusCustomEndCapData object that defines the custom end-cap shape,
        /// which is the shape to use at the end of a line drawn with this pen.
        /// It can be any of various shapes, such as a square, circle, or diamond.
        /// This field MUST be present if the PenDataCustomEndCap flag is set in the
        /// PenDataFlags field of the EmfPlusPenData object.
        /// </summary>
        public EmfPlusCustomEndCapData CustomEndCapData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            if (Transform != null)
            {
                foreach (RecordValues values in Transform.GetValues())
                {
                    yield return values;
                }
            }
            if (StartCap != null)
            {
                yield return new RecordValues("Start Cap", 4);
            }
            if (EndCap != null)
            {
                yield return new RecordValues("End Cap", 4);
            }
            if (Join != null)
            {
                yield return new RecordValues("Join", 4);
            }
            if (Join != null)
            {
                yield return new RecordValues("Miter Limit", 4);
            }
            if (LineStyle != null)
            {
                yield return new RecordValues("Line Style", 4);
            }
            if (DashedLineCap != null)
            {
                yield return new RecordValues("Dashed Line Cap", 4);
            }
            if (DashOffset != null)
            {
                yield return new RecordValues("Dash Offset", 4);
            }
            if (DashLineData != null)
            {
                foreach (RecordValues values in DashLineData.GetValues())
                {
                    yield return new RecordValues("Dash " + values, values.Length);
                }
            }
            if (Alignment != null)
            {
                yield return new RecordValues("Alignment", 4);
            }
            if (CompoundLineData != null)
            {
                foreach (RecordValues values in CompoundLineData.GetValues())
                {
                    yield return new RecordValues("Compound " + values, values.Length);
                }
            }
            if (CustomStartCapData != null)
            {
                foreach (RecordValues values in CustomStartCapData.GetValues())
                {
                    yield return new RecordValues("Start Cap " + values, values.Length);
                }
            }
            if (CustomEndCapData != null)
            {
                foreach (RecordValues values in CustomEndCapData.GetValues())
                {
                    yield return new RecordValues("End Cap " + values, values.Length);
                }
            }
        }
    }
}
