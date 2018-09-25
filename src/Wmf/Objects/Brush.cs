using System.Collections.Generic;
using MetafileDumper.Wmf.Enumerations;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Specifies a graphics brush for the filling of figures.
    /// [MS-WMF] 2.2.1
    /// </summary>
    public class Brush : ObjectBase
    {
        public Brush(MetafileReader reader)
        {
            Style = (BrushStyle)reader.ReadUInt16();
            Color = reader.ReadUInt32();
            HatchData = BrushHatchData.GetBrushHatchData(reader, Style);
        }

        public override uint Size => 8 + HatchData.Size;

        /// <summary>
        /// A 16-bit unsigned integer that defines the brush style.
        /// The value MUST be an enumeration from the BrushStyle Enumeration table (section
        /// 2.1.1.4).
        /// </summary>
        public BrushStyle Style { get; }

        /// <summary>
        /// A 32-bit field that specifies how to interpret color values in the object
        /// defined in the BrushHatch field.Its interpretation depends on the value
        /// of BrushStyle.
        /// </summary>
        public uint Color { get; }

        /// <summary>
        /// A variable-size field that contains the brush hatch or pattern data.
        /// The content depends on the value of BrushStyle.
        /// </summary>
        public BrushHatchData HatchData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Style", 2);
            yield return new RecordValues("Color", 4);

            if (HatchData != null)
            {
                foreach (RecordValues values in HatchData.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
