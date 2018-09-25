using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies clipping areas in the graphics device context for a terminal
    /// server.
    /// [MS-EMFPLUS] 2.3.8.1
    /// </summary>
    public class EmfPlusSetTSClip : EmfPlusRecord
    {
        public EmfPlusSetTSClip(MetafileReader reader) : base(reader)
        {
            if (DataCompressed)
            {
                Rects = Utilities.ReadBytes(reader, NumberOfRects * 4);
            }
            else
            {
                Rects = Utilities.ReadBytes(reader, NumberOfRects * 8);
            }
        }

        public override string Name => "EmfPlusSetTSClip";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // C |                      Number of Rects                      |
        /// <summary>
        /// If set, each rectangle is defined in 4 bytes.
        /// If clear, each rectangle is defined in 8 bytes.
        /// </summary>
        public bool DataCompressed => (Flags & 0b1000000000000000) != 0;

        /// <summary>
        /// This field specifies the number of rectangles that are defined in the rect
        /// field.
        /// </summary>
        public uint NumberOfRects => Flags & 0b0111111111111111u;

        /// <summary>
        /// An array of NumRects rectangles that define clipping areas.
        /// The format of this data is determined by the C bit in the Flags field.
        /// </summary>
        public IEnumerable<byte> Rects { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Rects", Size - 12);
        }
    }
}
