namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Specifies that subsequent EMF records ([MS-EMF] section 2.3) encountered in the
    /// metafile SHOULD be processed.
    /// [MS-EMFPLUS] 2.3.3.2
    /// </summary>
    public class EmfPlusGetDC : EmfPlusRecord
    {
        public EmfPlusGetDC(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusGetDC";
    }
}
