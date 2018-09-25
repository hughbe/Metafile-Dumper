namespace MetafileDumper.EmfPlus.Enumerations
{
    /// <summary>
    /// Defines modes for combining two graphics regions.
    /// [MS-EMFPLUS] section 2.1.1.4
    /// </summary>
    public enum CombineMode
    {
        /// <summary>
        /// Replaces the existing region with the new region.
        /// </summary>
        Replace = 0x00000000,

        /// <summary>
        /// Replaces the existing region with the intersection of the existing region
        /// and the new region
        /// </summary>
        Intersect = 0x00000001,

        /// <summary>
        /// Replaces the existing region with the union of the existing and new regions.
        /// </summary>
        Union = 0x00000002,

        /// <summary>
        /// Replaces the existing region with the XOR of the existing and new regions.
        /// </summary>
        XOR = 0x00000003,

        /// <summary>
        /// Replaces the existing region with the part of itself that is not in the new
        /// region.
        /// </summary>
        Exclude = 0x00000004,

        /// <summary>
        /// Replaces the existing region with the part of the new region that is not in
        /// the existing region.
        /// </summary>
        Complement = 0x00000005
    }
}
