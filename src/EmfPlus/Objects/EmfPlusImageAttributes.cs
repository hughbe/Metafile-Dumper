using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies how bitmap and metafile image colors are manipulated during
    /// rendering.
    /// [MS-EMFPLUS] 2.2.1.5
    public class EmfPlusImageAttributes : EmfPlusObjectData
    {
        public EmfPlusImageAttributes(MetafileReader reader, uint size) : base(reader, size)
        {
            Reserved1 = reader.ReadInt32();
            WrapMode = (WrapMode)reader.ReadUInt32();
            ClampColor = reader.ReadUInt32();
            ClampToBitmap = reader.ReadBoolean();
            Reserved2 = reader.ReadInt32();
        }

        public override ObjectType ObjectType => ObjectType.ImageAttributes;

        /// <summary>
        /// A 32-bit field that is not used and MUST be ignored.
        /// </summary>
        public int Reserved1 { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies how to handle edge conditions with a
        /// value from the WrapMode enumeration.
        /// </summary>
        public WrapMode WrapMode { get; }

        /// <summary>
        /// An EmfPlusARGB object that specifies the edge color to use when the WrapMode
        /// value is WrapModeClamp.This color is visible when the source rectangle
        /// processed by an EmfPlusDrawImage record is larger than the image itself.
        /// </summary>
        public uint ClampColor { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the object clamping behavior. It is not
        /// used until this object is applied to an image being drawn.
        /// </summary>
        public bool ClampToBitmap { get; }

        /// <summary>
        /// A value that SHOULD be set to zero and MUST be ignored upon receipt.
        /// </summary>
        public int Reserved2 { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",      4);
            yield return new RecordValues("Reserved1",    4);
            yield return new RecordValues("Wrap Mode",    4);
            yield return new RecordValues("Clamp Color",  4);
            yield return new RecordValues("Object Clamp", 4);
            yield return new RecordValues("Reserved2",    4);
        }
    }
}
