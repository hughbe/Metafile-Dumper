namespace MetafileDumper.EmfPlus
{
    public class EmfPlusMultiFormatSection : EmfPlusRecord
    {
        public EmfPlusMultiFormatSection(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusMultiFormatSection";
    }
}
