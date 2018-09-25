using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusBrushDataBase : ObjectBase
    {
        public EmfPlusBrushDataBase(BrushType type)
        {
            BrushType = type;
        }

        public BrushType BrushType { get; }

        public static EmfPlusBrushDataBase GetBrushData(MetafileReader reader, BrushType type)
        {
            EmfPlusBrushDataBase data;

            switch (type)
            {
                case BrushType.SolidColor:
                    data = new EmfPlusSolidBrushData(reader);
                    break;
                case BrushType.HatchFill:
                    data = new EmfPlusHatchBrushData(reader);
                    break;
                case BrushType.PathGradient:
                    data = new EmfPlusPathGradientBrushData(reader);
                    break;
                case BrushType.LinearGradient:
                    data = new EmfPlusLinearGradientBrushData(reader);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown brush type {type}.");
            }

            return data;
        }
    }
}
