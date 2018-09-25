namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines versions of operating system graphics that are used to create
    /// EMF+ metafiles.
    /// [MS-EMFPLUS] section 2.1.1.12
    /// </summary>
    public enum GraphicsVersion
    {
        /// <summary>
        /// Specifies GDI+ version 1.0.
        /// </summary>
        Version1 = 0x0001,

        /// <summary>
        /// Specifies GDI+ version 1.1.
        /// </summary>
        Version1_1 = 0x0002
    }
}
