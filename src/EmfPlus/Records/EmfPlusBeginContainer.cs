using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.EmfPlus.Enumerations;
using System.Collections.Generic;

namespace MetafileDumper.EmfPlus
{
    /// <summary>
    /// Starts a new graphics state container with a transformation.
    /// [MS-EMFPLUS] 2.3.7.1
    /// </summary>
    public class EmfPlusBeginContainer : EmfPlusRecord
    {
        public EmfPlusBeginContainer(MetafileReader reader) : base(reader)
        {
            DestRect = new EmfPlusRectF(reader);
            SourceRect = new EmfPlusRectF(reader);
            StackIndex = reader.ReadUInt32();
        }

        public override string Name => "EmfPlusBeginContainer";

        // 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
        // ---------------------------------------------------------------
        //           Unit Type           | X | X | X | X | X | X | X | X |
        /// <summary>
        /// The unit of measure for page space coordinates, from the UnitType
        /// enumeration.
        /// This value SHOULD NOT be UnitTypeDisplay or UnitTypeWorld.
        /// </summary>
        public UnitType PageUnit => (UnitType)((Flags >> 8) & 0b11111111);

        /// <summary>
        /// An EmfPlusRectF object that, with SrcRect, specifies a transform for the
        /// container. This transformation results in SrcRect when applied to DestRect.
        /// </summary>
        public EmfPlusRectF DestRect { get; }

        /// <summary>
        /// An EmfPlusRectF rectangle that, with DestRect, specifies a transform for the
        /// container.This transformation results in SrcRect when applied to DestRect.
        /// </summary>
        public EmfPlusRectF SourceRect { get; }

        /// <summary>
        /// A 32-bit unsigned integer that specifies an index to associate with the
        /// graphics state container.
        /// The index MUST be referenced by a subsequent EmfPlusEndContainer to
        /// close the graphics state container.
        /// </summary>
        public uint StackIndex { get; }

        protected override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues value in DestRect.GetValues())
            {
                yield return new RecordValues("Dest" + value.Name, value.Length);
            }

            foreach (RecordValues value in SourceRect.GetValues())
            {
                yield return new RecordValues("Src" + value.Name, value.Length);
            }

            yield return new RecordValues("Stack Index", 4);
        }
    }
}
