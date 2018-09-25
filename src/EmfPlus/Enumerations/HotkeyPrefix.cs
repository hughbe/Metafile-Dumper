namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines output options for hotkey prefixes in graphics text.
    /// [MS-EMFPLUS] section 2.1.1.14
    /// </summary>
    public enum HotkeyPrefix
    {
        /// <summary>
        /// Specifies that the hotkey prefix SHOULD NOT be displayed.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Specifies that no hotkey prefix is defined.
        /// </summary>
        Show = 0x00000001,

        /// <summary>
        /// Specifies that the hotkey prefix SHOULD be displayed.
        /// </summary>
        Hide = 0x00000002
    }
}
