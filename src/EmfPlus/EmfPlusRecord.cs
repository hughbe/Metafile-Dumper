using MetafileDumper.EmfPlus.Enumerations;
using MetafileDumper.EmfPlus;
using System;
using System.Collections.Generic;

namespace MetafileDumper
{
    public abstract class EmfPlusRecord : Record
    {
        public EmfPlusRecord(MetafileReader reader) : base(reader)
        {
            Type = (RecordType)reader.ReadUInt16();
            Flags = reader.ReadUInt16();
            Size = reader.ReadUInt32();
            DataSize = reader.ReadUInt32();
        }

        public RecordType Type { get; }
        public ushort Flags { get; }
        public uint DataSize { get; protected set; }

        protected override IEnumerable<RecordValues> GetHeaderValues()
        {
            yield return new RecordValues("Type",      2);
            yield return new RecordValues("Flags",     2);
            yield return new RecordValues("Size",      4);
            yield return new RecordValues("Data Size", 4);
        }

        public static EmfPlusRecord GetRecord(MetafileReader reader)
        {
            int type = reader.PeekInt16();

            EmfPlusRecord record;
            switch (type)
            {
                case 0x4001:
                    record = new EmfPlusHeader(reader);
                    break;
                case 0x4002:
                    record = new EmfPlusEndOfFile(reader);
                    break;
                case 0x4003:
                    record = new EmfPlusComment(reader);
                    break;
                case 0x4004:
                    record = new EmfPlusGetDC(reader);
                    break;
                case 0x4005:
                    record = new EmfPlusMultiFormatStart(reader);
                    break;
                case 0x4006:
                    record = new EmfPlusMultiFormatSection(reader);
                    break;
                case 0x4007:
                    record = new EmfPlusMultiFormatEnd(reader);
                    break;
                case 0x4008:
                    record = new EmfPlusObject(reader);
                    break;
                case 0x4009:
                    record = new EmfPlusClear(reader);
                    break;
                case 0x400A:
                    record = new EmfPlusFillRects(reader);
                    break;
                case 0x400B:
                    record = new EmfPlusDrawRects(reader);
                    break;
                case 0x400C:
                    record = new EmfPlusFillPolygon(reader);
                    break;
                case 0x400D:
                    record = new EmfPlusDrawLines(reader);
                    break;
                case 0x400E:
                    record = new EmfPlusFillEllipse(reader);
                    break;
                case 0x400F:
                    record = new EmfPlusDrawEllipse(reader);
                    break;
                case 0x4010:
                    record = new EmfPlusFillPie(reader);
                    break;
                case 0x4011:
                    record = new EmfPlusDrawPie(reader);
                    break;
                case 0x4012:
                    record = new EmfPlusDrawArc(reader);
                    break;
                case 0x4013:
                    record = new EmfPlusFillRegion(reader);
                    break;
                case 0x4014:
                    record = new EmfPlusFillPath(reader);
                    break;
                case 0x4015:
                    record = new EmfPlusDrawPath(reader);
                    break;
                case 0x4016:
                    record = new EmfPlusFillClosedCurve(reader);
                    break;
                case 0x4017:
                    record = new EmfPlusDrawClosedCurve(reader);
                    break;
                case 0x4018:
                    record = new EmfPlusDrawCurve(reader);
                    break;
                case 0x4019:
                    record = new EmfPlusDrawBeziers(reader);
                    break;
                case 0x401A:
                    record = new EmfPlusDrawImage(reader);
                    break;
                case 0x401C:
                    record = new EmfPlusDrawString(reader);
                    break;
                case 0x401D:
                    record = new EmfPlusSetRenderingOrigin(reader);
                    break;
                case 0x401E:
                    record = new EmfPlusSetAntiAliasMode(reader);
                    break;
                case 0x401F:
                    record = new EmfPlusSetTextRenderingHint(reader);
                    break;
                case 0x4020:
                    record = new EmfPlusSetTextContrast(reader);
                    break;
                case 0x4021:
                    record = new EmfPlusSetInterpolationMode(reader);
                    break;
                case 0x4022:
                    record = new EmfPlusSetPixelOffsetMode(reader);
                    break;
                case 0x4023:
                    record = new EmfPlusSetCompositingMode(reader);
                    break;
                case 0x4024:
                    record = new EmfPlusSetCompositingQuality(reader);
                    break;
                case 0x4025:
                    record = new EmfPlusSave(reader);
                    break;
                case 0x4026:
                    record = new EmfPlusRestore(reader);
                    break;
                case 0x4027:
                    record = new EmfPlusBeginContainer(reader);
                    break;
                case 0x4028:
                    record = new EmfPlusBeginContainerNoParams(reader);
                    break;
                case 0x4029:
                    record = new EmfPlusEndContainer(reader);
                    break;
                case 0x402A:
                    record = new EmfPlusSetWorldTransform(reader);
                    break;
                case 0x402B:
                    record = new EmfPlusResetWorldTransform(reader);
                    break;
                case 0x402C:
                    record = new EmfPlusMultiplyWorldTransform(reader);
                    break;
                case 0x402D:
                    record = new EmfPlusTranslateWorldTransform(reader);
                    break;
                case 0x402E:
                    record = new EmfPlusScaleWorldTransform(reader);
                    break;
                case 0x402F:
                    record = new EmfPlusRotateWorldTransform(reader);
                    break;
                case 0x4030:
                    record = new EmfPlusSetPageTransform(reader);
                    break;
                case 0x4031:
                    record = new EmfPlusResetClip(reader);
                    break;
                case 0x4032:
                    record = new EmfPlusSetClipRect(reader);
                    break;
                case 0x4033:
                    record = new EmfPlusSetClipPath(reader);
                    break;
                case 0x4034:
                    record = new EmfPlusSetClipRegion(reader);
                    break;
                case 0x4035:
                    record = new EmfPlusOffsetClip(reader);
                    break;
                case 0x4036:
                    record = new EmfPlusDrawDriverString(reader);
                    break;
                case 0x4037:
                    record = new EmfPlusStrokeFillPath(reader);
                    break;
                case 0x4038:
                    record = new EmfPlusSerializableObject(reader);
                    break;
                case 0x4039:
                    record = new EmfPlusSetTSGraphics(reader);
                    break;
                case 0x403A:
                    record = new EmfPlusSetTSClip(reader);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown EMF+ record type 0x{type:X4}");
            }

            return record;
        }
    }
}
