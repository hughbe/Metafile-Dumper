namespace MetafileDumper.Emf.Records
{
    public class EmfSaveDC : EmfRecord
    {
        public EmfSaveDC(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EMR_SAVEDC";
    }
}
