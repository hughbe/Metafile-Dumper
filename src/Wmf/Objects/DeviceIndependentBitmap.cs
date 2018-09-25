using MetafileDumper.Wmf.Data;
using System.Collections.Generic;

namespace MetafileDumper.Wmf.Objects
{
    /// <summary>
    /// Defines an image in device-independent bitmap (DIB) format.
    /// [MS-WMF] 2.2.2.2
    /// </summary>
    public class DeviceIndependentBitmap : ObjectBase
    {
        public DeviceIndependentBitmap(MetafileReader reader)
        {
            int headerSize = reader.PeekInt32();
            if (headerSize == 0x0000000C)
            {
                Header = new BitmapCoreHeader(reader);
            }
            else
            {
                Header = new BitmapInfoHeader(reader);
            }
        }

        public override uint Size => Header.Size;

        public ObjectBase Header { get; }

        public IEnumerable<RGBQuad> Colors { get; }

        public override IEnumerable<RecordValues> GetValues()
        {
            foreach (RecordValues values in Header.GetValues())
            {
                yield return values;
            }
        }
    }
}
