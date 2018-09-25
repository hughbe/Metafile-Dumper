namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Specifies that the hotkey prefix SHOULD be displayed.
    /// [MS-EMFPLUS] section 2.1.1.15
    /// </summary>
    public enum ImageDataType
    {
        /// <summary>
        /// The type of image is not known.
        /// </summary>
        Unknown = 0x00000000,

        /// <summary>
        /// Specifies a bitmap image.
        /// </summary>
        Bitmap = 0x00000001,

        /// <summary>
        /// Specifies a metafile image.
        /// </summary>
        Metafile = 0x00000002
    }
}
