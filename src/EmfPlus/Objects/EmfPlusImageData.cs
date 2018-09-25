using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusImageData : ObjectBase
    {
        public EmfPlusImageData(uint size)
        {
            Size = size;
        }

        public override uint Size { get; }

        public abstract ImageDataType ImageType { get; }

        public static EmfPlusImageData GetImageData(MetafileReader reader, ImageDataType type, uint size)
        {
            EmfPlusImageData data;

            switch (type)
            {
                case ImageDataType.Bitmap:
                    data = new EmfPlusBitmap(reader, size);
                    break;
                case ImageDataType.Metafile:
                    data = new EmfPlusMetafile(reader, size);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown image type {type}.");
            }

            return data;
        }
    }
}
