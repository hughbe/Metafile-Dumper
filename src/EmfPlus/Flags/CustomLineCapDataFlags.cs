using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies data for custom line caps. 
    /// [MS-EMFPLUS] Section 2.1.2.2
    /// </summary>
    [Flags]
    public enum CustomLineCapDataFlags : uint
    {
        /// <summary>
        /// If set, an EmfPlusFillPath object MUST be specified in the OptionalData field of
        /// the EmfPlusCustomLineCapData object for filling the custom line cap.
        /// </summary>
        HasFillPath = 0x00000001,

        /// <summary>
        /// If set, an EmfPlusLinePath object MUST be specified in the OptionalData field of
        /// the EmfPlusCustomLineCapData object for outlining the custom line cap.
        /// </summary>
        HasStrokePath = 0x00000002
    }
}
