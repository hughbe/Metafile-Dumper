using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Defines an object for use in graphics operations. 
    /// [MS-EMFPLUS] 2.3.5
    /// </summary>
    public class EmfPlusObject : EmfPlusRecord
    {
        public EmfPlusObject(MetafileReader reader) : base(reader)
        {
            if (Continued)
            {
                TotalObjectSize = DataSize;
                DataSize = reader.ReadUInt32();
            }

            Data = EmfPlusObjectData.GetObject(reader, ObjectType, DataSize);
        }

        public override string Name => "EmfPlusObject";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // C |        Object Type        |           Object ID           |
        /// <summary>
        /// Indicates that the object definition continues on in the next EmfPlusObject record.
        /// This flag is never set in the final record that defines the object.
        /// </summary>
        public bool Continued => ((Flags >> 15) & 0b1) != 0;

        /// <summary>
        /// Specifies the type of object to be created by this record, from the
        /// ObjectType enumeration.
        /// </summary>
        public ObjectType ObjectType => (ObjectType)((Flags >> 8) & 0b1111111);

        /// <summary>
        /// The index in the EMF+ Object Table to associate with the object created by
        /// this record.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public uint ObjectId => Flags & 0b11111111u;

        /// <summary>
        /// If the record is continuable, when the continue bit is set, this field will be
        /// present. Continuing objects have multiple EMF+ records starting with
        /// EmfPlusContineudObjectRecord.
        /// Each EmfPlusContinuedObjectRecord will contain a TotalObjectSize.
        /// Once TotalObjectSize number of bytes has been read, the next EMF+ record
        /// will not be treated as part of the continuing object.
        /// </summary>
        public uint TotalObjectSize { get; }

        /// <summary>
        /// An array of bytes that contains data for the type of object specified in the
        /// Flags field.
        /// The content and format of the data can be different for each object type.
        /// See the individual object definitions in section 2.2.1 for additional information.
        /// </summary>
        public EmfPlusObjectData Data { get; }

        protected override IEnumerable<RecordValues> GetHeaderValues()
        {
            yield return new RecordValues("Type", 2);
            yield return new RecordValues("Flags", 2);
            yield return new RecordValues("Size", 4);
        }

        protected override IEnumerable<RecordValues> GetValues()
        {
            if (Continued)
            {
                yield return new RecordValues("TotalObjectSize", 4);
            }

            yield return new RecordValues("Data Size", 4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
