using System.Collections.Generic;
using MetafileDumper.EmfPlus.Enumerations;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a bitmap image.
    /// [MS-EMFPLUS] 2.2.2.2
    /// </summary>
    public class EmfPlusBitmap : EmfPlusImageData
    {
        public EmfPlusBitmap(MetafileReader reader, uint size) : base(size)
        {
            Width = reader.ReadInt32();
            Height = reader.ReadInt32();
            Stride = reader.ReadInt32();
            PixelFormat = (PixelFormat)reader.ReadUInt32();
            DataType = (BitmapDataType)reader.ReadUInt32();
            Data = EmfPlusBitmapDataBase.GetBitmapData(reader, DataType, size - 20);
        }

        public override ImageDataType ImageType => ImageDataType.Bitmap;

        /// <summary>
        /// A 32-bit signed integer that specifies the width in pixels of the area occupied
        /// by the bitmap.
        /// If the image is compressed, according to the Type field, this value is undefined
        /// and MUST be ignored.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the height in pixels of the area occupied
        /// by the bitmap.
        /// If the image is compressed, according to the Type field, this value is undefined
        /// and MUST be ignored.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// A 32-bit signed integer that specifies the byte offset between the beginning of one
        /// scan-line and the next.This value is the number of bytes per pixel, which is
        /// specified in the PixelFormat field, multiplied by the width in pixels, which
        /// is specified in the Width field.
        /// The value of this field MUST be a multiple of four.
        /// If the image is compressed, according to the Type field, this value is undefined
        /// and MUST be ignored.
        /// </summary>
        public int Stride { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the format of the pixels that make
        /// up the bitmap image.
        /// The supported pixel formats are specified in the PixelFormat enumeration.
        /// If the image is compressed, according to the Type field, this value is undefined
        /// and MUST be ignored.
        /// </summary>
        public PixelFormat PixelFormat { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the type of data in the BitmapData field.
        /// This value MUST be defined in the BitmapDataType enumeration.
        /// </summary>
        public BitmapDataType DataType { get; }

        /// <summary>
        /// Variable-length data that defines the bitmap data object specified in the
        /// Type field.
        /// The content and format of the data can be different for every bitmap type.
        /// </summary>
        public EmfPlusBitmapDataBase Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Width",        4);
            yield return new RecordValues("Height",       4);
            yield return new RecordValues("Stride",       4);
            yield return new RecordValues("Pixel Format", 4);
            yield return new RecordValues("Data Type",    4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
        }
    }
}
