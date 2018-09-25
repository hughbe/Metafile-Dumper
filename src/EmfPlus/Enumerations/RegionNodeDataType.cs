namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of region node data.
    /// [MS-EMFPLUS] section 2.1.1.27
    /// </summary>
    public enum RegionNodeDataType
    {
        /// <summary>
        /// Specifies a region node with child nodes. A Boolean AND operation SHOULD be
        /// applied to the left and right child nodes specified by an
        /// EmfPlusRegionNodeChildNodes object.
        /// </summary>
        And = 0x00000001,

        /// <summary>
        /// Specifies a region node with child nodes. A Boolean OR operation SHOULD be
        /// applied to the left and right child nodes specified by an
        /// EmfPlusRegionNodeChildNodes object.
        Or = 0x00000002,

        /// <summary>
        /// Specifies a region node with child nodes. A Boolean XOR operation SHOULD be
        /// applied to the left and right child nodes specified by an
        /// EmfPlusRegionNodeChildNodes object.
        Xor = 0x00000003,

        /// <summary>
        /// Specifies a region node with child nodes. A Boolean operation, defined as "the"
        /// part of region 1 that is excluded from region 2", SHOULD be applied to the left
        /// and right child nodes specified by an EmfPlusRegionNodeChildNodes object.
        /// </summary>
        Exclude = 0x00000004,

        /// <summary>
        /// Specifies a region node with child nodes. A Boolean operation, defined as "the
        /// part of region 2 that is excluded from region 1", SHOULD be applied to the left
        /// and right child nodes specified by an EmfPlusRegionNodeChildNodes object.
        /// </summary>
        Complement = 0x00000005,

        /// <summary>
        /// Specifies a region node with no child nodes. The RegionNodeData field
        /// SHOULD specify a boundary with an EmfPlusRectF object.
        /// </summary>
        Rect = 0x10000000,

        /// <summary>
        /// Specifies a region node with no child nodes. The RegionNodeData field
        /// SHOULD specify a boundary with an EmfPlusRegionNodePath object.
        /// </summary>
        Path = 0x10000001,

        /// <summary>
        /// Specifies a region node with no child nodes. The RegionNodeData field
        /// SHOULD NOT be present.
        /// </summary>
        Empty = 0x10000002,

        /// <summary>
        /// Specifies a region node with no child nodes, and its bounds are not defined.
        /// </summary>
        Infinite = 0x10000003
    }
}
