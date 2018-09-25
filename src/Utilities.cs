using MetafileDumper.EmfPlus.Objects;
using MetafileDumper.Wmf.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetafileDumper
{
    internal static class Utilities
    {
        public static IEnumerable<EmfPlusPointBase> GetPoints(MetafileReader reader, bool relative, bool compressed, uint count)
        {
            var points = new EmfPlusPointBase[count];
            for (uint i = 0; i < count; i++)
            {
                EmfPlusPointBase point;
                if (relative)
                {
                    throw new InvalidOperationException("Don't know how to handle relative points.");
                }
                else
                {
                    if (compressed)
                    {
                        point = new EmfPlusPoint(reader);
                    }
                    else
                    {
                        point = new EmfPlusPointF(reader);
                    }
                }
                points[i] = point;
            }
            return points;
        }

        public static IEnumerable<PointS> GetPointSs(MetafileReader reader, uint count)
        {
            var points = new PointS[count];
            for (uint i = 0; i < count; i++)
            {
                points[i] = new PointS(reader);
            }
            return points;
        }

        public static IEnumerable<EmfPlusRectBase> GetRects(MetafileReader reader, bool compressed, uint count)
        {
            var rectangles = new EmfPlusRectBase[count];
            for (int i = 0; i < count; i++)
            {
                rectangles[i] = GetRect(reader, compressed);
            }
            return rectangles;
        }

        public static EmfPlusRectBase GetRect(MetafileReader reader, bool compressed)
        {
            if (compressed)
            {
                return new EmfPlusRect(reader);
            }

            return new EmfPlusRectF(reader);
        }

        public static IEnumerable<float> ReadFloats(MetafileReader reader, uint count)
        {
            var floats = new float[count];
            for (uint i = 0; i < count; i++)
            {
                floats[i] = reader.ReadSingle();
            }
            return floats;
        }

        public static IEnumerable<uint> ReadUInt32s(MetafileReader reader, uint count)
        {
            var uints = new uint[count];
            for (uint i = 0; i < count; i++)
            {
                uints[i] = reader.ReadUInt32();
            }
            return uints;
        }

        public static IEnumerable<ushort> ReadUInt16s(MetafileReader reader, uint count)
        {
            var ushorts = new ushort[count];
            for (uint i = 0; i < count; i++)
            {
                ushorts[i] = reader.ReadUInt16();
            }
            return ushorts;
        }

        public static IEnumerable<byte> ReadBytes(MetafileReader reader, uint count)
        {
            var bytes = new byte[count];
            for (uint i = 0; i < count; i++)
            {
                bytes[i] = reader.ReadByte();
            }
            return bytes;
        }

        public static string GetString(MetafileReader reader, uint length)
        {
            if (length > int.MaxValue)
            {
                throw new InvalidOperationException("Can't read string...");
            }

            return string.Create((int)length, reader, (chars, readerBuff) =>
            {
                for (int i = 0; i < length; i++)
                {
                    chars[i] = (char)readerBuff.ReadUInt16();
                }
            });
        }

        public static string GetAnsiString(MetafileReader reader, uint length)
        {
            if (length > int.MaxValue)
            {
                throw new InvalidOperationException("Can't read string...");
            }

            return string.Create((int)length, reader, (chars, readerBuff) =>
            {
                for (int i = 0; i < length; i++)
                {
                    chars[i] = (char)readerBuff.ReadByte();
                }
            });
        }

        public static void JoinByteArray(StringBuilder builder, byte[] buffer, uint index, uint length)
        {
            for (uint i = 0; i < length; i++)
            {
                builder.Append("0x" + buffer[i + index].ToString("X2"));
                if (i + index != buffer.Length - 1)
                {
                    // Not the last in the whole array.
                    if (i == length - 1)
                    {
                        builder.AppendLine(",");
                    }
                    else
                    {
                        builder.Append(", ");
                    }
                }
            }
        }
    }
}
