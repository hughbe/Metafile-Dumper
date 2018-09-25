using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines the style, color, and pattern of a brush. This object is used only in the
    /// META_CREATEBRUSHINDIRECT Record(section 2.3.4.1) to create a Brush
    /// Object (section 2.2.1.1).
    /// [MS-WMF] 2.2.2.10
    /// </summary>
    public class LogBrush : ObjectBase
    {
        public LogBrush(MetafileReader reader)
        {
            Style = (BrushStyle)reader.ReadUInt16();
            Color = new ColorRef(reader);
            Hatch = (HatchStyle)reader.ReadUInt16();
        }

        public override uint Size => 8;

        /// <summary>
        /// A 16-bit unsigned integer that defines the brush style.
        /// This MUST be a value from the BrushStyle Enumeration(section 2.1.1.4).
        /// For the meanings of different values, see the following table.
        /// The BS_NULL style specifies a brush that has no effect.
        /// </summary>
        public BrushStyle Style { get; }

        /// <summary>
        /// A 32-bit ColorRef Object section 2.2.2.8) that specifies a color.
        /// Its interpretation depends on the value of BrushStyle.
        /// </summary>
        public ColorRef Color { get; }

        /// <summary>
        /// A 16-bit field that specifies the brush hatch type.
        /// Its interpretation depends on the value of BrushStyle.
        /// </summary>
        public HatchStyle Hatch { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style", 2);
            yield return new RecordValues("Color", 4);
            yield return new RecordValues("Hatch", 2);
        }
    }
}
