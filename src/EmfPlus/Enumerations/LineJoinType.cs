namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines ways to join two lines that are drawn by the same graphics pen
    /// and whose ends meet.
    /// [MS-EMFPLUS] section 2.1.1.19
    /// </summary>
    public enum LineJoinType
    {
        /// <summary>
        /// Specifies a mitered line join.
        /// </summary>
        Miter = 0x00000000,

        /// <summary>
        /// Specifies a beveled line join
        /// </summary>
        Bevel = 0x00000001,

        /// <summary>
        /// Specifies a rounded line join.
        /// </summary>
        Round = 0x00000002,

        /// <summary>
        /// Specifies a clipped mitered line join.
        /// </summary>
        Clipped = 0x00000003
    }
}
