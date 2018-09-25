using MetafileDumper.EmfPlus.Enumerations;
using System;

namespace MetafileDumper.EmfPlus.Objects
{
    public abstract class EmfPlusCustomLineCapDataBase : ObjectBase
    {
        public EmfPlusCustomLineCapDataBase(CustomLineCapDataType type)
        {
            CustomLineCapType = type;
        }

        public CustomLineCapDataType CustomLineCapType { get; }

        public static EmfPlusCustomLineCapDataBase GetCustomLineCapData(MetafileReader reader, CustomLineCapDataType type)
        {
            EmfPlusCustomLineCapDataBase data;

            switch (type)
            {
                case CustomLineCapDataType.Default:
                    data = new EmfPlusCustomLineCapData(reader);
                    break;
                case CustomLineCapDataType.AdjustableArrow:
                    data = new EmfPlusCustomLineCapArrowData(reader);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown custom line cap type {type}.");
            }

            return data;
        }
    }
}
