using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies positions and factors for the blend pattern of a gradient brush.
    /// [MS-EMFPLUS] 2.2.2.5
    /// </summary>
    public class EmfPlusBlendFactors : ObjectBase
    {
        public EmfPlusBlendFactors(MetafileReader reader)
        {
            PositionsCount = reader.ReadUInt32();
            Positions = Utilities.ReadFloats(reader, PositionsCount);
            Factors = Utilities.ReadFloats(reader, PositionsCount);
        }

        public override uint Size => 4 + 4 * PositionsCount + 4 * PositionsCount;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of positions in the
        /// BlendPositions field and colors in the BlendColors field.
        /// </summary>
        public uint PositionsCount { get; }

        /// <summary>
        /// An array of PositionCount 32-bit floating-point values that specify proportions
        /// of distance along the gradient line.
        /// Each value MUST be a number between 0.0 and 1.0 inclusive. There MUST be at least
        /// two positions specified: the first position, which is always 0.0f, and the last
        /// position, which is always 1.0f.
        /// Each position in BlendPositions is generally greater than the preceding position.
        /// For a linear gradient brush, 0.0 represents the starting point and 1.0 represents
        /// the ending point.
        /// For a path gradient brush, 0.0 represents the midpoint and 1.0 represents an
        /// endpoint.
        /// </summary>
        public IEnumerable<float> Positions { get; }

        /// <summary>
        /// An array of PositionCount 32-bit floating point values that specify proportions
        /// of colors at the positions defined in the BlendPositions field.
        /// Each value MUST be a number between 0.0 and 1.0 inclusive.
        /// </summary>
        public IEnumerable<float> Factors { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Blend Count",     4);
            yield return new RecordValues("Blend Positions", 4 * PositionsCount);
            yield return new RecordValues("Blend Factors",   4 * PositionsCount);
        }
    }
}
