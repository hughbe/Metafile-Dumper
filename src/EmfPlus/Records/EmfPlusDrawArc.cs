using MetafileDumper.EmfPlus.Objects;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing the arc of an ellipse.
    /// [MS-EMFPLUS] 2.3.4.2
    /// </summary>
    public class EmfPlusDrawArc : EmfPlusRecord
    {
        public EmfPlusDrawArc(MetafileReader reader) : base(reader)
        {
            StartAngle = reader.ReadSingle();
            SweepAngle = reader.ReadSingle();
            Rectangle = Utilities.GetRect(reader, DataCompressed);
        }

        public override string Name => "EmfPlusDrawArc";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, RectData contains an EmfPlusRect object.
        /// If clear, RectData contains an EmfPlusRectF object.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusPen object in the EMF+ Object Table to draw the arc.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint PenId => Flags & 0b11111111u;

        /// <summary>
        /// A 32-bit non-negative floating-point value that specifies the angle between
        /// the x-axis and the starting point of the arc.
        /// Any value is acceptable, but it MUST be interpreted modulo 360, with the
        /// result that is used being in the range 0.0 inclusive to 360.0 exclusive.
        /// </summary>
        public float StartAngle { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the extent of the arc to draw, as
        /// an angle in degrees measured from the starting point defined by the StartAngle
        /// value.
        /// Any value is acceptable, but it MUST be clamped to -360.0 to 360.0 inclusive.
        /// A positive value indicates that the sweep is defined in a clockwise direction,
        /// and a negative value indicates that the sweep is defined in a counter-clockwise
        /// direction.
        /// </summary>
        public float SweepAngle { get; }

        /// <summary>
        /// Either an EmfPlusRect or EmfPlusRectF object that defines the bounding box of
        /// the ellipse that is collinear with the arc.
        /// This rectangle defines the position, size, and shape of the arc.
        /// The type of object in this field is specified by the value of the Flags field.
        /// </summary>
        public EmfPlusRectBase Rectangle { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Start Angle", 4);
            yield return new RecordValues("Sweep Angle", 4);

            foreach (RecordValues values in Rectangle.GetValues())
            {
                yield return values;
            }
        }
    }
}
