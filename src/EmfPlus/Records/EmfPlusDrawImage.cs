using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies drawing a scaled image.
    /// [MS-EMFPLUS] 2.3.4.8
    /// </summary>
    public class EmfPlusDrawImage : EmfPlusRecord
    {
        public EmfPlusDrawImage(MetafileReader reader) : base(reader)
        {
            ImageAttributesId = reader.ReadUInt32();
            SrcUnit = (UnitType)reader.ReadInt32();
            SrcRect = new EmfPlusRectF(reader);
            DestRect = Utilities.GetRect(reader, DataCompressed);
        }

        public override string Name => "EmfPlusDrawImage";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | C | X | X | X | X | X | X |           Object Id           |
        /// <summary>
        /// If set, RectData contains an EmfPlusRect object.
        /// If clear, RectData contains an EmfPlusRectF object.
        /// </summary>
        public bool DataCompressed => (Flags & 0b0100000000000000) != 0;

        /// <summary>
        /// The index of an EmfPlusImage object in the EMF+ Object Table, which
        /// specifies the image to render.
        /// The value MUST be zero to 63, inclusive.
        /// </summary>
        public int ImageId => Flags & 0b11111111;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the index of an optional
        /// EmfPlusImageAttributes object in the EMF+ Object Table.
        /// </summary>
        public uint ImageAttributesId { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the units of the SrcRect field.
        /// It MUST be the UnitTypePixel member of the UnitType enumeration.
        /// </summary>
        public UnitType SrcUnit { get; }

        /// <summary>
        /// An EmfPlusRectF object that specifies a portion of the image to be rendered.
        /// The portion of the image specified by this rectangle is scaled to fit the
        /// destination rectangle specified by the RectData field.
        /// </summary>
        public EmfPlusRectF SrcRect { get; }

        /// <summary>
        /// Either an EmfPlusRect or EmfPlusRectF object that defines the bounding box of
        /// the image.
        /// The portion of the image specified by the SrcRect field is scaled to fit
        /// this rectangle.
        /// </summary>
        public EmfPlusRectBase DestRect { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Image Attributes Id", 4);
            yield return new RecordValues("Source Unit",         4);

            foreach (RecordValues values in SrcRect.GetValues())
            {
                yield return values;
            }

            foreach (RecordValues values in DestRect.GetValues())
            {
                yield return values;
            }
        }
    }
}
