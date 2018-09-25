namespace MetafileDumper.EmfPlus
{
    public class EmfPlusMultiFormatEnd : EmfPlusRecord
    {
        public EmfPlusMultiFormatEnd(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusMultiFormatEnd";
    }
}
