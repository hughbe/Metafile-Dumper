using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a graphics pen for the drawing of lines.
    /// [MS-EMFPLUS] 2.2.1.7
    /// </summary>
    public class EmfPlusPen : EmfPlusObjectData
    {
        public EmfPlusPen(MetafileReader reader, uint size) : base(reader, size)
        {
            Type = reader.ReadInt32();
            Data = new EmfPlusPenData(reader);
            Brush = new EmfPlusBrush(reader, size - 12 - Data.Size);
        }

        public override ObjectType ObjectType => ObjectType.Pen;

        /// <summary>
        /// This field MUST be set to zero.
        /// </summary>
        public int Type { get; }

        /// <summary>
        /// An EmfPlusPenData object that specifies properties of the graphics pen.
        /// </summary>
        public EmfPlusPenData Data { get; }

        /// <summary>
        /// An EmfPlusBrush object that specifies a graphics brush associated with the
        /// pen.
        /// </summary>
        public EmfPlusBrush Brush { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",    4);
            yield return new RecordValues("Type",       4);

            foreach (RecordValues values in Data.GetValues())
            {
                yield return values;
            }
            foreach (RecordValues values in Brush.GetValues())
            {
                yield return values;
            }
        }
    }
}
