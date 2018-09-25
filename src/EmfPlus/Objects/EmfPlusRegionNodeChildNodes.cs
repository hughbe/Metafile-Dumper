using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies the child nodes of a graphics region.
    /// [MS-EMFPLUS] 2.2.2.41
    /// </summary>
    public class EmfPlusRegionNodeChildNodes : EmfPlusRegionNodeData
    {
        public EmfPlusRegionNodeChildNodes(MetafileReader reader, RegionNodeDataType type) : base(type)
        {
            LeftNode = new EmfPlusRegionNode(reader);
            RightNode = new EmfPlusRegionNode(reader);
        }

        public override uint Size => LeftNode.Size + RightNode.Size;

        /// <summary>
        /// An EmfPlusRegionNode object that specifies the left child node of this region node.
        /// </summary>
        public EmfPlusRegionNode LeftNode { get; }

        /// <summary>
        /// An EmfPlusRegionNode object that defines the right child node of this region node.
        /// </summary>
        public EmfPlusRegionNode RightNode { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in LeftNode.GetValues())
            {
                yield return values;
            }

            foreach (RecordValues values in RightNode.GetValues())
            {
                yield return values;
            }
        }
    }
}
