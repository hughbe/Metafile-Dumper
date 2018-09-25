namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Resets the current world space transform to the identify matrix.
    /// [MS-EMFPLUS] 2.3.9.2
    /// </summary>
    public class EmfPlusResetWorldTransform : EmfPlusRecord
    {
        public EmfPlusResetWorldTransform(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusResetWorldTransform";
    }
}
