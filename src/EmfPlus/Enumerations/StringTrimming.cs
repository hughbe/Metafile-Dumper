namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines how to trim characters from a string that is too large for the text
    /// layout rectangle.
    /// [MS-EMFPLUS] section 2.1.1.31
    /// </summary>
    public enum StringTrimming
    {
        /// <summary>
        /// Specifies that no trimming is done.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Specifies that the string is broken at the boundary of the last character
        /// that is inside the layout rectangle. This is the default.
        /// </summary>
        Character = 0x00000001,

        /// <summary>
        /// Specifies that the string is broken at the boundary of the last word that
        /// is inside the layout rectangle.
        /// </summary>
        Word = 0x00000002,

        /// <summary>
        /// Specifies that the string is broken at the boundary of the last character
        /// that is inside the layout rectangle, and an ellipsis (...) is inserted
        /// after the character
        /// </summary>
        EllipsisCharacter = 0x00000003,

        /// <summary>
        /// Specifies that the string is broken at the boundary of the last word that
        /// is inside the layout rectangle, and an ellipsis (...) is inserted after
        /// the word.
        /// </summary>
        EllipsisWord = 0x00000004,

        /// <summary>
        /// Specifies that the center is removed from the string and replaced by an
        /// ellipsis. The algorithm keeps as much of the last portion of the string
        /// as possible.
        /// </summary>
        EllipsisPath = 0x00000005
    }
}
