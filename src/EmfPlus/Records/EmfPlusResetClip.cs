namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Resets the current clipping region for the world space to infinity.
    /// [MS-EMFPLUS] 2.3.1.2
    /// </summary>
    public class EmfPlusResetClip : EmfPlusRecord
    {
        public EmfPlusResetClip(MetafileReader reader) : base(reader)
        {
        }

        public override string Name => "EmfPlusResetClip";
    }
}
