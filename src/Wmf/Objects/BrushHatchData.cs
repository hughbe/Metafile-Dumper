using MetafileDumper.Wmf.Enumerations;

namespace MetafileDumper.Wmf.Objects
{
    public abstract class BrushHatchData : ObjectBase
    {
        public static BrushHatchData GetBrushHatchData(MetafileReader reader, BrushStyle style)
        {
            switch (style)
            {
                case BrushStyle.BS_PATTERN:
                    return new PatternBrushData(reader);
                case BrushStyle.BS_DIBPATTERNPT:
                    return new DIBPatternBrushData(reader);
                case BrushStyle.BS_HATCHED:
                    return new HatchBrushData(reader);
                default:
                    return null;
            }
        }
    }
}
