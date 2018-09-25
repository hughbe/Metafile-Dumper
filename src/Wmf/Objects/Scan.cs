using System.Collections.Generic;

namespace MetafileDumper.Wmf.Data
{
    /// <summary>
    /// Defines the x- and y-extents of a rectangle.
    /// [MS-WMF] 2.2.2.21
    /// </summary>
    public class Scan : ObjectBase
    {
        public Scan(MetafileReader reader)
        {
            Count = reader.ReadUInt16();
            Top = reader.ReadUInt16();
            Bottom = reader.ReadUInt16();

            var scanLines = new (ushort, ushort)[Count];
            for (int i = 0; i < Count; i++)
            {
                scanLines[i] = (reader.ReadUInt16(), reader.ReadUInt16());
            }
            ScanLines = scanLines;

            Count2 = reader.ReadUInt16();
        }

        public override uint Size => 8 + (uint)Count * 2;

        /// <summary>
        /// A 16-bit unsigned integer that specifies the number of horizontal (x-axis)
        /// coordinates in the ScanLines array.
        /// This value MUST be a multiple of 2, since left and right endpoints are
        /// required to specify each scanline.
        /// </summary>
        public ushort Count { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the vertical (y-axis) coordinate, in
        /// logical units, of the top scanline.
        /// </summary>
        public ushort Top { get; }

        /// <summary>
        /// A 16-bit unsigned integer that defines the vertical (y-axis) coordinate, in
        /// logical units, of the bottom scanline.
        /// </summary>
        public ushort Bottom { get; }

        /// <summary>
        /// An array of scanlines, each specified by left and right horizontal (x-axis)
        /// coordinates of its endpoints.
        /// </summary>
        public IEnumerable<(ushort, ushort)> ScanLines { get; }

        /// <summary>
        /// A 16-bit unsigned integer that MUST be the same as the value of the Count field;
        /// it is present to allow upward travel in the structure.
        /// </summary>
        public ushort Count2 { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Count",      2);
            yield return new RecordValues("Top",        2);
            yield return new RecordValues("Bottom",     2);
            yield return new RecordValues("Scan Lines", 2);
            yield return new RecordValues("Count2",     2 * (uint)Count);
        }
    }
}
