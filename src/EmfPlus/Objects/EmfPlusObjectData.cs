using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusObjectData : ObjectBase
    {
        public EmfPlusObjectData(MetafileReader reader, uint size)
        {
            Version = reader.ReadUInt32();
        }

        public override uint Size { get; }

        public abstract ObjectType ObjectType { get; }

        /// <summary>
        /// An EmfPlusGraphicsVersion object that specifies the version of operating system
        /// graphics that was used to create this object.
        /// </summary>
        public uint Version { get; }

        public static EmfPlusObjectData GetObject(MetafileReader reader, ObjectType type, uint size)
        {
            EmfPlusObjectData data;

            switch (type)
            {
                case ObjectType.Brush:
                    data = new EmfPlusBrush(reader, size);
                    break;
                case ObjectType.Pen:
                    data = new EmfPlusPen(reader, size);
                    break;
                case ObjectType.Path:
                    data = new EmfPlusPath(reader, size);
                    break;
                case ObjectType.Region:
                    data = new EmfPlusRegion(reader, size);
                    break;
                case ObjectType.Image:
                    data = new EmfPlusImage(reader, size);
                    break;
                case ObjectType.Font:
                    data = new EmfPlusFont(reader, size);
                    break;
                case ObjectType.StringFormat:
                    data = new EmfPlusStringFormat(reader, size);
                    break;
                case ObjectType.ImageAttributes:
                    data = new EmfPlusImageAttributes(reader, size);
                    break;
                case ObjectType.CustomLineCap:
                    data = new EmfPlusCustomLineCap(reader, size);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown object type {type}.");
            }

            return data;
        }
    }
}
