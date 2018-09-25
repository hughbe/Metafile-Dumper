using MetafileDumper.Emf.Enumerations;
using MetafileDumper.Emf.Records;
using System.Collections.Generic;

namespace MetafileDumper
{
    public abstract class EmfRecord : Record
    {
        public EmfRecord(MetafileReader reader) : base(reader)
        {
            Type = (RecordType)reader.ReadUInt32();
            Size = reader.ReadUInt32();
        }

        public RecordType Type { get; }

        protected override IEnumerable<RecordValues> GetHeaderValues()
        {
            yield return new RecordValues("Type", 4);
            yield return new RecordValues("Size", 4);
        }

        public static EmfRecord GetRecord(MetafileReader reader)
        {
            int type = reader.PeekInt32();

            EmfRecord record;
            switch (type)
            {
                case 0x00000001:
                    record = new EmrHeader(reader);
                    break;
                case 0x0000000E:
                    record = new EmrEOF(reader);
                    break;
                case 0x00000021:
                    record = new EmfSaveDC(reader);
                    break;
                case 0x00000022:
                    record = new EmrRestoreDC(reader);
                    break;
                case 0x00000046:
                    record = new EmrCommentEmfPlus(reader);
                    break;
                case 0x0000004C:
                    record = new EmrBitBlt(reader);
                    break;
                case 0x00000062:
                    record = new EmrSetICMMode(reader);
                    break;
                default:
                    record = new EmrUnknownRecord(reader);
                    break;
            }

            return record;
        }
    }
}
