using System;

namespace MetafileDumper.EmfPlus.Flags
{
    /// <summary>
    /// Specifies type properties of points on graphics paths.
    /// [MS-EMFPLUS] Section 2.1.2.7
    /// </summary>
    [Flags]
    public enum PathPointTypeFlags : uint
    {
        /// <summary>
        /// Specifies that a line segment that passes through the point is dashed.
        /// </summary>
        DashMode = 0x01,

        /// <summary>
        /// Specifies that the point is a position marker.
        /// </summary>
        PathMarker = 0x02,

        /// <summary>
        /// Specifies that the point is the endpoint of a subpath.
        /// </summary>
        CloseSubpath = 0x08
    }
}
