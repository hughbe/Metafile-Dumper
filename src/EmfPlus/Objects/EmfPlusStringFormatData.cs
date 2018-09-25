using System.Collections.Generic;

namespace MetafileDumper.EmfPlus.Objects
{
    /// <summary>
    /// Specifies tab stops and character positions for a graphics string.
    /// </summary>
    public class EmfPlusStringFormatData : ObjectBase
    {
        public EmfPlusStringFormatData(MetafileReader reader, int tabStopsCount, int measurableCharacterRangesCount)
        {
            TabStopsCount = tabStopsCount;
            MeasurableCharacterRangesCount = measurableCharacterRangesCount;

            if (tabStopsCount > 0)
            {
                TabStops = Utilities.ReadFloats(reader, (uint)TabStopsCount);
            }

            if (measurableCharacterRangesCount > 0)
            {
                var measurableCharacterRanges = new List<EmfPlusCharacterRange>(measurableCharacterRangesCount);
                for (int i = 0; i < measurableCharacterRangesCount; i++)
                {
                    var measurableCharacterRange = new EmfPlusCharacterRange(reader);
                    measurableCharacterRanges.Add(measurableCharacterRange);
                }
                MeasurableCharacterRanges = measurableCharacterRanges;
            }
        }

        public int TabStopsCount { get; }

        public int MeasurableCharacterRangesCount { get; }

        /// <summary>
        /// An optional array of floating-point values that specify the optional tab stop
        /// locations for this object.
        /// Each tab stop value represents the number of spaces between tab stops or, for
        /// the first tab stop, the number of spaces between the beginning of a line of
        /// text and the first tab stop.
        /// This field MUST be present if the value of the TabStopCount field in the
        /// EmfPlusStringFormat object is greater than 0.
        /// </summary>
        public IEnumerable<float> TabStops { get; }

        /// <summary>
        /// An optional array of RangeCount EmfPlusCharacterRange objects that specify the
        /// range of character positions within a string of text.
        /// The bounding region is defined by the area of the display that is occupied by
        /// a group of characters specified by the character range.
        /// This field MUST be present if the value of the RangeCount field in the
        /// EmfPlusStringFormat object is greater than 0.
        /// </summary>
        public IEnumerable<EmfPlusCharacterRange> MeasurableCharacterRanges { get; }

        public override uint Size
        {
            get
            {
                uint size = 0;
                if (TabStopsCount > 0)
                {
                    size += (uint)TabStopsCount * 4;
                }
                if (MeasurableCharacterRangesCount > 0)
                {
                    size += (uint)MeasurableCharacterRangesCount * 8;
                }
                return size;
            }
        }

        public override IEnumerable<RecordValues> GetValues()
        {
            if (TabStops != null)
            {
                for (int i = 0; i < TabStopsCount; i++)
                {
                    yield return new RecordValues("Tab Stop " + (i + 1), 4);
                }
            }

            if (MeasurableCharacterRanges != null)
            {
                int measurableCharacterRangeCounter = 0;
                foreach (EmfPlusCharacterRange measurableCharacterRange in MeasurableCharacterRanges)
                {
                    foreach (RecordValues values in measurableCharacterRange.GetValues())
                    {
                        yield return new RecordValues(values.Name + (measurableCharacterRangeCounter + 1), values.Length);
                    }

                    measurableCharacterRangeCounter++;
                }
            }
        }
    }
}
