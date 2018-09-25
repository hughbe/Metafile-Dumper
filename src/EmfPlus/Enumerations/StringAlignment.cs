namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines ways to align strings with respect to a text layout rectangle.
    /// [MS-EMFPLUS] section 2.1.1.29
    /// </summary>
    public enum StringAlignment
    {
        /// <summary>
        /// Specifies that string alignment is toward the origin of the layout rectangle.
        /// This can be used to align characters along a line or to align text within
        /// a rectangle. For a right-toleft layout rectangle, the origin SHOULD be at
        /// the upper right.
        /// </summary>
        Near = 0x00000000,

        /// <summary>
        /// Specifies that alignment is centered between the origin and extent of the
        /// layout rectangle.
        /// </summary>
        Center = 0x00000001,

        /// <summary>
        /// Specifies that alignment is to the right side of the layout rectangle.
        /// </summary>
        Far = 0x00000002
    }
}
