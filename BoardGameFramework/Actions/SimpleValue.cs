using System;

namespace BoardGameFramework.Actions
{
    public class SimpleValue
    {
        public SimpleValue(string value)
        {
            Type = SimpleValueType.String;
            Value = value;
        }

        public SimpleValue(int value)
        {
            Type = SimpleValueType.Number;
            Value = value;
        }

        public SimpleValue(string[] value)
        {
            Type = SimpleValueType.StringArray;
            Value = value;
        }

        public SimpleValue(int[] value)
        {
            Type = SimpleValueType.NumberArray;
            Value = value;
        }

        public SimpleValueType Type { get; set; }

        private object _value;

        public object Value
        {
            get
            {
                switch(Type)
                {
                    case SimpleValueType.String:
                        return _value.ToString();

                    case SimpleValueType.Number:
                        return Convert.ToInt32(_value);

                    case SimpleValueType.StringArray:
                        return (string[])_value;

                    case SimpleValueType.NumberArray:
                        return (int[])_value;
                }

                throw new NotImplementedException("Type not implemented");
            }
            set
            {
                _value = value;
            }
        }
    }

    public enum SimpleValueType
    {
        String,
        Number,
        StringArray,
        NumberArray
    }
}