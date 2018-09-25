using MetafileDumper.EmfPlus.Objects;
using System;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Defines an object that has been serialized into a data buffer.
    /// [MS-EMFPLUS] 2.3.5.2
    /// </summary>
    public class EmfPlusSerializableObject : EmfPlusRecord
    {
        public EmfPlusSerializableObject(MetafileReader reader) : base(reader)
        {
            ObjectGuid = reader.ReadGuid();
            BufferSize = reader.ReadUInt32();
            Effect = EmfPlusImageEffectBase.GetImageEffect(reader, ObjectGuid);
        }

        public override string Name => "EmfPlusSerializableObject";

        /// <summary>
        /// The GUID packet representation value ([MS-DTYP] section 2.3.4.2) for the
        /// image effect.
        /// This MUST correspond to one of the ImageEffects identifiers.
        /// </summary>
        public Guid ObjectGuid { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the size in bytes of the 32-bit-aligned
        /// Buffer field.
        /// </summary>
        public uint BufferSize { get; }

        /// <summary>
        /// An array of BufferSize bytes that contain the serialized image effects parameter
        /// block that corresponds to the GUID in the ObjectGUID field.
        /// This MUST be one of the Image Effects objects.
        /// </summary>
        public EmfPlusImageEffectBase Effect { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Object Guid", 16);
            yield return new RecordValues("Buffer Size", 4);

            foreach (RecordValues value in Effect.GetValues())
            {
                yield return value;
            }
        }
    }
}
