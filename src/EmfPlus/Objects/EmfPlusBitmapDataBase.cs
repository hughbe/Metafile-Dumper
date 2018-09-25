using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusBitmapDataBase : ObjectBase
    {
        public EmfPlusBitmapDataBase(uint size)
        {
            Size = size;
        }

        public override uint Size { get; }

        public abstract BitmapDataType BitmapType { get; }

        public static EmfPlusBitmapDataBase GetBitmapData(MetafileReader reader, BitmapDataType type, uint size)
        {
            EmfPlusBitmapDataBase data;

            switch (type)
            {
                case BitmapDataType.Pixel:
                    data = new EmfPlusBitmapData(reader, size);
                    break;
                case BitmapDataType.Compressed:
                    data = new EmfPlusCompressedImage(reader, size);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown bitmap type 0x{type:X8}.");
            }

            return data;
        }
    }
}
