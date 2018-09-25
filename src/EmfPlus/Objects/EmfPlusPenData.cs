using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus.Flags;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies properties of a graphics pen.
    /// [MS-EMFPLUS] 2.2.2.33
    /// </summary>
    public class EmfPlusPenData : ObjectBase
    {
        public EmfPlusPenData(MetafileReader reader)
        {
            Flags = (PenDataFlags)reader.ReadUInt32();
            Unit = (UnitType)reader.ReadUInt32();
            Width = reader.ReadSingle();
            OptionalData = new EmfPlusPenOptionalData(reader, Flags);
        }

        public override uint Size => 4 + 4 + 4 + OptionalData.Size;


        /// <summary>
        /// A 32-bit unsigned integer that specifies the data in the OptionalData field.
        /// This value MUST be composed of PenData flags.
        /// </summary>
        public PenDataFlags Flags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the measuring units for the pen.
        /// The value MUST be from the UnitType enumeration.
        /// </summary>
        public UnitType Unit { get; }

        /// <summary>
        /// A 32-bit floating-point value that specifies the width of the line drawn by the
        /// pen in the units specified by the PenUnit field.
        /// If a zero width is specified, a minimum value is used, which is determined by
        /// the units.
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// An optional EmfPlusPenOptionalData object that specifies additional data for
        /// the pen object.
        /// The specific contents of this field are determined by the value of the
        /// PenDataFlags field.
        /// </summary>
        public EmfPlusPenOptionalData OptionalData { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Flags", 4);
            yield return new RecordValues("Unit" , 4);
            yield return new RecordValues("Width", 4);

            foreach (RecordValues values in OptionalData.GetValues())
            {
                yield return values;
            }
        }
    }
}
