using MetafileDumper.EMFRecords.Data;
using MetafileDumper.EMFRecords.Enumerations;
using MetafileDumper.Wmf.Data;
using MetafileDumper.Wmf.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.Emf.Records
{
    public class EmrBitBlt : EmfRecord
    {
        public EmrBitBlt(MetafileReader reader) : base(reader)
        {
            Bounds = new RectL(reader);
            DestX = reader.ReadInt32();
            DestY = reader.ReadInt32();
            DestWidth = reader.ReadInt32();
            DestHeight = reader.ReadInt32();
            RasterOperation = (TernaryRasterOperation)reader.ReadUInt32();
            SrcX = reader.ReadInt32();
            SrcY = reader.ReadInt32();
            WorldToPageTransform = new XForm(reader);
            SrcBackgroundColor = reader.ReadUInt32();
            SrcUsage = (DIBColors)reader.ReadUInt32();
            BitmapHeaderOffset = reader.ReadUInt32();
            BitmapHeaderSize = reader.ReadUInt32();
            BitmapBitsOffset = reader.ReadUInt32();
            BitmapBitsSize = reader.ReadUInt32();
        }

        public override string Name => "EMR_BITBLT";

        public RectL Bounds { get; }

        public int DestX { get; }
        public int DestY { get; }
        public int DestWidth { get; }
        public int DestHeight { get; }

        public TernaryRasterOperation RasterOperation { get; }

        public int SrcX { get; }
        public int SrcY { get; }

        public XForm WorldToPageTransform { get; }

        public uint SrcBackgroundColor { get; }
        public DIBColors SrcUsage { get; }

        public uint BitmapHeaderOffset { get; }
        public uint BitmapHeaderSize { get; }

        public uint BitmapBitsOffset { get; }
        public uint BitmapBitsSize { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Bounds.GetValues())
            {
                yield return new RecordValues("Bounds " + values.Name, values.Length);
            }

            yield return new RecordValues("Dest X",                4);
            yield return new RecordValues("Dest Y",               4);
            yield return new RecordValues("Dest Width",           4);
            yield return new RecordValues("Dest Height",          4);
            yield return new RecordValues("Raster Operation",     4);
            yield return new RecordValues("Src X",                4);
            yield return new RecordValues("Src Y",                4);

            foreach (RecordValues values in WorldToPageTransform.GetValues())
            {
                yield return values;
            }

            yield return new RecordValues("Src Background Color", 4);
            yield return new RecordValues("Src Usage",            4);
            yield return new RecordValues("Bitmap Header Offset", 4);
            yield return new RecordValues("Bitmap Header Size",   4);
            yield return new RecordValues("Bitmap Bits Offset",   4);
            yield return new RecordValues("Bitmap Bits Size",     4);

            if (Size - 100 > 0)
            {
                yield return new RecordValues("Bitmap Buffer", Size - 100);
            }
        }
    }
}
