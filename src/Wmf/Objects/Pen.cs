using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Specifies a graphics pen for the drawing of lines.
    /// [MS-WMF] 2.2.1.4
    /// </summary>
    public class Pen : ObjectBase
    {
        public Pen(MetafileReader reader)
        {
            Style = (PenStyle)reader.ReadUInt16();
            Width = new PointS(reader);
            Color = new ColorRef(reader);
        }

        public override uint Size => 10;

        /// <summary>
        /// A 16-bit unsigned integer that specifies the pen style.
        /// The value MUST be defined from the PenStyle Enumeration (section 2.1.1.23)
        /// table.
        /// </summary>
        public PenStyle Style { get; }

        /// <summary>
        /// A 32-bit PointS Object (section 2.2.2.16) that specifies a point for the object
        /// dimensions.
        /// The x-coordinate is the pen width. The y-coordinate is ignored.
        /// </summary>
        public PointS Width { get; }

        /// <summary>
        /// A 32-bit ColorRef Object (section 2.2.2.8) that specifies the pen color value.
        /// </summary>
        public ColorRef Color { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style", 2);
            yield return new RecordValues("Width", 4);
            yield return new RecordValues("Color", 4);
        }
    }
}
