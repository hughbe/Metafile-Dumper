using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics brush for the filling of figures.
    /// [MS-EMFPLUS 2.2.1.1]
    /// </summary>
    public class EmfPlusBrush : EmfPlusObjectData
    {
        public EmfPlusBrush(MetafileReader reader, uint size) : base(reader, size)
        {
            Type = (BrushType)reader.ReadInt32();
            Data = EmfPlusBrushDataBase.GetBrushData(reader, Type);
        }

        public override ObjectType ObjectType => ObjectType.Brush;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the type of brush, which determines the
        /// contents of the BrushData field.This value MUST be defined in the BrushType
        /// enumeration.
        /// </summary>
        public BrushType Type { get; }

        /// <summary>
        /// Variable-length data that defines the brush object specified in the Type field.
        /// The content and format of the data can be different for every brush type.
        /// </summary>
        public EmfPlusBrushDataBase Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version", 4);
            yield return new RecordValues("Type",    4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
