using System.Collections.Generic;

namespace MetafileDumper
{
    public class MetafileEnumerator
    {
        public static IEnumerable<EmfRecord> Enumerate(byte[] buffer)
        {
            var reader = new MetafileReader(buffer, 0);
            uint currentIndex = 0;
            while (reader.CurrentIndex < buffer.Length)
            {
                var record = EmfRecord.GetRecord(reader);
                currentIndex += record.Size;
                yield return record;

                if (reader.CurrentIndex != (int)currentIndex)
                {
                    reader.CurrentIndex = (int)currentIndex;
                    // throw new System.InvalidOperationException("Reader is out of sync with the size.");
                }
            }
        }
    }
}
