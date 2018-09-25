using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies the start of EMF+ data in the metafile.
    /// [MS-EMFPLUS] 2.3.3.3
    /// </summary>
    public class EmfPlusHeader : EmfPlusRecord
    {
        public EmfPlusHeader(MetafileReader reader) : base(reader)
        {
            Version = reader.ReadUInt32();
            EmfPlusFlags = reader.ReadUInt32();
            LogicalDpiX = reader.ReadUInt32();
            LogicalDpiY = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusHeader";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X | X | X | X | X | X | X | X | D |
        /// <summary>
        /// If set, this flag indicates that this metafile is EMF+ Dual, which means that
        /// it contains two sets of records, each of which completely specifies the
        /// graphics content.
        /// If clear, the graphics content is specified by EMF+ records, and possibly EMF
        /// records([MS-EMF] section 2.3) that are preceded by an EmfPlusGetDC record.
        /// If this flag is set, EMF records alone SHOULD suffice to define the graphics
        /// content.
        /// Note that whether the EMF+ Dual flag is set or not, some EMF records are
        /// always present, namely EMF control records and the EMF records that contain
        /// EMF+ records.
        /// </summary>
        public bool IsEmfPlusDual => (Flags & 0b1) != 0;

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X | X | X | X | X | X | X | X | V |
        /// <summary>
        /// If set, this flag indicates that the metafile was recorded with a reference device
        /// context for a video display.
        /// If clear, the metafile was recorded with a reference device context for a printer.
        /// </summary>
        public bool RecordedWithPrinterDeviceContext => (EmfPlusFlags & 0b1) == 0;

        /// <summary>
        /// An EmfPlusGraphicsVersion object that specifies the version of operating system
        /// graphics that was used to create this metafile.
        /// </summary>
        public uint Version { get; }

        /// <summary>
        /// A 32-bit unsigned integer that contains information about how this metafile
        /// was recorded.
        /// </summary>
        public uint EmfPlusFlags { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the horizontal resolution for which
        /// the metafile was recorded, in units of pixels per inch.
        /// </summary>
        public uint LogicalDpiX { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies the vertical resolution for which the
        /// metafile was recorded, in units of lines per inch.
        /// </summary>
        public uint LogicalDpiY { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Version",      4);
            yield return new RecordValues("EmfPlusFlags", 4);
            yield return new RecordValues("Logical DpiX", 4);
            yield return new RecordValues("Logical DpiY", 4);
        }
    }
}
