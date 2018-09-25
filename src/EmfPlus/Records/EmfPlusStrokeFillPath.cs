using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    public class EmfPlusStrokeFillPath : EmfPlusRecord
    {
        public EmfPlusStrokeFillPath(MetafileReader reader) : base(reader)
        {
            PenId = reader.ReadUInt32();
            BrushId = reader.ReadUInt32();
            EffectId = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusStrokeFillPath";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        // X | X | X | X | X | X | X | X |           Object Id           |
        public int PathId => Flags & 0b11111111;

        public uint PenId { get; }
        public uint BrushId { get; }
        public uint EffectId { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("Pen Id",    4);
            yield return new RecordValues("Brush Id",  4);
            yield return new RecordValues("Effect Id", 4);
        }
    }
}
