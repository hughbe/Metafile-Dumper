namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines ways to substitute digits in a string according to a user's locale or
    /// language.
    /// [MS-EMFPLUS] section 2.1.1.30
    /// </summary>
    public enum StringDigitSubstitution
    {
        /// <summary>
        /// Specifies an implementation-defined substitution scheme
        /// </summary>
        User = 0x00000000,

        /// <summary>
        /// Specifies to disable substitutions.
        /// </summary>
        None = 0x00000001,

        /// <summary>
        /// Specifies substitution digits that correspond with the official
        /// national language of the user's locale.
        /// </summary>
        National = 0x00000002,

        /// <summary>
        /// Specifies substitution digits that correspond to the user's native script or
        /// language, which can be different from the official national language of the
        /// user's locale.
        /// </summary>
        Traditional = 0x00000003
    }
}
