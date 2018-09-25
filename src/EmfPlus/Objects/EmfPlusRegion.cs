using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies line and curve segments that define a nonrectilinear shape
    /// [MS-EMFPLUS] Section 2.2.1.8
    /// </summary>
    public class EmfPlusRegion : EmfPlusObjectData
    {
        public EmfPlusRegion(MetafileReader reader, uint size) : base(reader, size)
        {
            NodeCount = reader.ReadUInt32();
            RootNode = new EmfPlusRegionNode(reader);
        }

        public override ObjectType ObjectType => ObjectType.Region;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the number of child nodes in
        /// the RegionNode field.
        /// </summary>
        public uint NodeCount { get; }

        /// <summary>
        /// An array of RegionNodeCount+1 EmfPlusRegionNode objects. Regions are specified
        /// as a binary tree of region nodes, and each node MUST either be a terminal node
        /// or specify one or two child nodes.RegionNode MUST contain at least one element.
        /// </summary>
        public EmfPlusRegionNode RootNode { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",    4);
            yield return new RecordValues("Node Count", 4);

            foreach (RecordValues values in RootNode.GetValues())
            {
                yield return values;
            }
        }
    }
}
