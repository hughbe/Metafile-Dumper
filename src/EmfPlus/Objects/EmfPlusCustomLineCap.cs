using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies the shape to use at the ends of a line drawn by a graphics pen. 
    /// [MS-EMFPLUS] 2.2.1.2
    /// </summary>
    public class EmfPlusCustomLineCap : EmfPlusObjectData
    {
        public EmfPlusCustomLineCap(MetafileReader reader, uint size) : base(reader, size)
        {
            Type = (CustomLineCapDataType)reader.ReadInt32();
            Data = EmfPlusCustomLineCapDataBase.GetCustomLineCapData(reader, Type);
        }

        public override ObjectType ObjectType => ObjectType.CustomLineCap;

        /// <summary>
        /// A 32-bit signed integer that specifies the type of custom line cap object,
        /// which determines the contents of the CustomLineCapData field.This value
        /// MUST be defined in the CustomLineCapDataType enumeration.
        /// </summary>
        public CustomLineCapDataType Type { get; }

        /// <summary>
        /// Variable-length data that defines the custom line cap data object specified
        /// in the Type field.The content and format of the data can be different for
        /// every custom line cap type.
        /// </summary>
        public EmfPlusCustomLineCapDataBase Data { get; }

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
