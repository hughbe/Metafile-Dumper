namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines types of metafiles data that can be embedded in an EMF+ metafile.
    /// [MS-EMFPLUS] section 2.1.1.21
    /// </summary>
    public enum MetafileDataType
    {
        /// <summary>
        /// Specifies that the metafile is a WMF metafile [MS-WMF] that specifies
        /// graphics operations with WMF records.
        /// </summary>
        Wmf = 0x00000001,

        /// <summary>
        /// Specifies that the metafile is a WMF metafile that specifies graphics
        /// operations with WMF records, and which contains additional header
        /// information that makes the WMF metafile device-independent.
        /// </summary>
        WmfPlaceable = 0x00000001,

        /// <summary>
        /// Specifies that the metafile is an EMF metafile that specifies graphics
        /// operations with EMF records ([MS-EMF] section 2.3).
        /// </summary>
        Emf = 0x00000001,

        /// <summary>
        /// Specifies that the metafile is an EMF+ metafile that specifies graphics
        /// operations with EMF+ records only.
        /// </summary>
        EmfPlusOnly = 0x00000001,

        /// <summary>
        /// Specifies that the metafile is an EMF+ metafile that specifies graphics
        /// operations with both EMF and EMF+ records.
        /// </summary>
        EmfPlusDual = 0x00000001,
    }
}
