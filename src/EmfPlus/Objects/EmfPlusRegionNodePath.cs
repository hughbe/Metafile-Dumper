using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics path for drawing the boundary of a region node.
    /// [MS-EMFPLUS] 2.2.2.42
    /// </summary>
    public class EmfPlusRegionNodePath : EmfPlusRegionNodeData
    {
        public EmfPlusRegionNodePath(MetafileReader reader) : base(RegionNodeDataType.Path)
        {
            PathLength = reader.ReadInt32();
            Path = new EmfPlusPath(reader, (uint)PathLength);
        }

        public override uint Size => 4 + (uint)PathLength;

        /// <summary>
        /// A 32-bit signed integer that specifies the length in bytes of the
        /// RegionNodePath field.
        /// </summary>
        public int PathLength { get; set; }

        /// <summary>
        /// An EmfPlusPath object that specifies the boundary of the region node.
        /// </summary>
        public EmfPlusPath Path { get; set; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Path Length", 4);

            foreach (RecordValues values in Path.GetValues())
            {
                yield return values;
            }
        }
    }
}
