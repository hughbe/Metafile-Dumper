namespace MetafileDumper.Emf.Records
{
    public class EmrComment : EmfRecord
    {
        public EmrComment(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EMR_COMMENT";
    }
}
