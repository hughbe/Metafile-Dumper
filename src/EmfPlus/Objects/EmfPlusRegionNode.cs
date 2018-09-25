using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a node of a graphics region.
    /// [MS-EMFPLUS] 2.2.2.40
    /// </summary>
    public class EmfPlusRegionNode : ObjectBase
    {
        public EmfPlusRegionNode(MetafileReader reader)
        {
            Type = (RegionNodeDataType)reader.ReadUInt32();
            Data = EmfPlusRegionNodeData.GetNodeData(reader, Type);
        }

        public override uint Size => 4 + Data.Size;

        /// <summary>
        /// A 32-bit unsigned integer that specifies the type of data in the RegionNodeData
        /// field.
        /// This value MUST be defined in the RegionNodeDataType enumeration.
        /// </summary>
        public RegionNodeDataType Type { get; }

        /// <summary>
        /// Optional, variable-length data that defines the region node data object
        /// specified in the Type field.The content and format of the data can be
        /// different for every region node type.
        /// This field MUST NOT be present if the node type is RegionNodeDataTypeEmpty
        /// or RegionNodeDataTypeInfinite.
        /// </summary>
        public EmfPlusRegionNodeData Data { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Type", 4);

            if (Data != null)
            {
                foreach (RecordValues values in Data.GetValues())
                {
                    yield return values;
                }
            }
        }
    }
}
