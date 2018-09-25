using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies properties of graphics pens.
    /// [MS-EMFPLUS] Section 2.1.2.7
    /// </summary>
    [Flags]
    public enum PenDataFlags : uint
    {
        /// <summary>
        /// If set, a 2x3 transform matrix MUST be specified in the OptionalData field of
        /// an EmfPlusPenData object.
        /// </summary>
        HasTransform = 0x00000001,

        /// <summary>
        /// If set, the style of a starting line cap MUST be specified in the OptionalData
        /// field of an EmfPlusPenData object.
        /// </summary>
        HasStartCap = 0x00000002,

        /// <summary>
        /// Indicates whether the style of an ending line cap MUST be specified in the
        /// OptionalData field of an EmfPlusPenData object.
        /// </summary>
        HasEndCap = 0x00000004,

        /// <summary>
        /// Indicates whether a line join type MUST be specified in the OptionalData field
        /// of an EmfPlusPenData object.
        /// </summary>
        HasJoin = 0x00000008,

        /// <summary>
        /// Indicates whether a miter limit MUST be specified in the OptionalData field
        /// of an EmfPlusPenData object.
        /// </summary>
        HasMiterLimit = 0x00000010,

        /// <summary>
        /// Indicates whether a line style MUST be specified in the OptionalData field
        /// of an EmfPlusPenData object.
        /// </summary>
        HasLineStyle = 0x00000020,

        /// <summary>
        /// Indicates whether a dashed line cap MUST be specified in the OptionalData
        /// field of an EmfPlusPenData object.
        /// </summary>
        HasDashedLineCap = 0x00000040,

        /// <summary>
        /// Indicates whether a dashed line offset MUST be specified in the OptionalData
        /// field of an EmfPlusPenData object.
        /// </summary>
        HasDashedLineOffset = 0x00000080,

        /// <summary>
        /// Indicates whether an EmfPlusDashedLineData object MUST be specified in the
        /// OptionalData field of an EmfPlusPenData object.
        /// </summary>
        HasDashedLine = 0x00000100,

        /// <summary>
        /// Indicates whether a pen alignment MUST be specified in the OptionalData field of
        /// an EmfPlusPenData object.
        /// </summary>
        HasNonCenter = 0x00000200,

        /// <summary>
        /// Indicates whether the length and content of a EmfPlusCompoundLineData object are
        /// present in the OptionalData field of an EmfPlusPenData object.
        /// </summary>
        HasCompoundLine = 0x00000400,

        /// <summary>
        /// Indicates whether an EmfPlusCustomStartCapData object MUST be specified in the
        /// OptionalData field of an EmfPlusPenData object.
        /// </summary>
        HasCustomStartCap = 0x00000800,

        /// <summary>
        /// Indicates whether an EmfPlusCustomEndCapData object MUST be specified in the
        /// OptionalData field of an EmfPlusPenData object.
        /// </summary>
        HasCustomEndCap = 0x00001000
    }
}
