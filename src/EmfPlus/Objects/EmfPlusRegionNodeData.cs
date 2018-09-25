using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusRegionNodeData : ObjectBase
    {
        public EmfPlusRegionNodeData(RegionNodeDataType type)
        {
            Type = type;
        }

        public RegionNodeDataType Type { get; }

        public static EmfPlusRegionNodeData GetNodeData(MetafileReader reader, RegionNodeDataType type)
        {
            EmfPlusRegionNodeData data;

            switch (type)
            {
                case RegionNodeDataType.Rect:
                    data = new EmfPlusRegionNodeRect(reader);
                    break;
                case RegionNodeDataType.Path:
                    data = new EmfPlusRegionNodePath(reader);
                    break;
                case RegionNodeDataType.Empty:
                    data = null;
                    break;
                case RegionNodeDataType.Infinite:
                    data = null;
                    break;
                case RegionNodeDataType.And:
                case RegionNodeDataType.Or:
                case RegionNodeDataType.Xor:
                case RegionNodeDataType.Exclude:
                case RegionNodeDataType.Complement:
                    data = new EmfPlusRegionNodeChildNodes(reader, type);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown region node type 0x{type:X8}");
            }

            return data;
        }
    }
}
