using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies a world space to device space transform.
    /// [MS-EMFPLUS] 2.2.2.47
    /// </summary>
    public class EmfPlusTransformMatrix : ObjectBase
    {
        public EmfPlusTransformMatrix(MetafileReader reader)
        {
            M11 = reader.ReadSingle();
            M21 = reader.ReadSingle();
            M12 = reader.ReadSingle();
            M22 = reader.ReadSingle();
            Dx = reader.ReadSingle();
            Dy = reader.ReadSingle();
        }

        public override uint Size => 24;

        /// <summary>
        /// Corresponds to m11, which is the coordinate of the first row and first
        /// column of the 2x2 matrix.
        /// </summary>
        public float M11 { get; }

        /// <summary>
        /// Corresponds to m12, which is the coordinate of the first row and second
        /// column of the 2x2 matrix.
        /// </summary>
        public float M21 { get; }

        /// <summary>
        /// Corresponds to m21, which is the coordinate of the second row and first
        /// column of the 2x2 matrix.
        /// </summary>
        public float M12 { get; }

        /// <summary>
        /// Corresponds to m22, which is the coordinate of the second row and
        /// second column of the 2x2 matrix.
        /// </summary>
        public float M22 { get; }

        /// <summary>
        /// Corresponds to dx, which is the horizontal displacement in the 1x2
        /// matrix.
        /// </summary>
        public float Dx { get; }

        /// <summary>
        /// Corresponds to dy, which is the vertical displacement in the 1x2 matrix.
        /// </summary>
        public float Dy { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            yield return new RecordValues("m11", 4);
            yield return new RecordValues("m21", 4);
            yield return new RecordValues("m12", 4);
            yield return new RecordValues("m22", 4);
            yield return new RecordValues("dx", 4);
            yield return new RecordValues("dy", 4);
        }
    }
}
