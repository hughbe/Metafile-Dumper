namespace MetafileDumper.Wmf.Enumerations
{
    /// <summary>
    /// Defines values that specify support for device-independent bitmaps (DIBs)
    /// in metafiles.
    /// [MS-WMF] 2.1.1.19
    /// </summary>
    public enum MetafileType
    {
        /// <summary>
        /// DIBs are not supported.
        /// </summary>
        METAVERSION100 = 0x0100,

        /// <summary>
        /// DIBs are supported.
        /// </summary>
        METAVERSION300 = 0x0300
    }
}
