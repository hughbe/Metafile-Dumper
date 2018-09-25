using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies positions and colors for the blend pattern of a gradient brush.
    /// [MS-EMFPLUS] 2.2.2.4
    /// </summary>
    public class EmfPlusBlendColors : ObjectBase
    {
        public EmfPlusBlendColors(MetafileReader reader)
        {
            PositionsCount = reader.ReadUInt32();
            Positions = Utilities.ReadFloats(reader, PositionsCount);
            Colors = Utilities.ReadUInt32s(reader, PositionsCount);
        }

        public override uint Size => 4 + 4 * PositionsCount + 4 * PositionsCount;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of positions in the
        /// BlendPositions field and colors in the BlendColors field.
        /// </summary>
        public uint PositionsCount { get; }

        /// <summary>
        /// An array of PositionCount 32-bit floating-point values that specify
        /// proportions of distance along the gradient line.
        /// Each element MUST be a number between 0.0 and 1.0 inclusive.
        /// For a linear gradient brush, 0.0 represents the starting point and 1.0
        /// represents the ending point.
        /// For a path gradient brush, 0.0 represents the midpoint and 1.0 represents
        /// an endpoint.
        /// </summary>
        public IEnumerable<float> Positions { get; }

        /// <summary>
        /// An array of PositionCount EmfPlusARGB objects that specify colors at the
        /// positions defined in the BlendPositions field.
        /// </summary>
        public IEnumerable<uint> Colors { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Blend Count",     4);
            yield return new RecordValues("Blend Positions", 4 * PositionsCount);
            yield return new RecordValues("Blend Colors",    4 * PositionsCount);
        }
    }
}
