using System;

namespace BoardGameFramework.Actions
{
    public class SimpleValue
    {
        public SimpleValue(string value)
        {
            Type = SimpleValueType.String;
            _value = value;
        }

        public SimpleValue(int value)
        {
            Type = SimpleValueType.Number;
            _value = value;
        }

        public SimpleValue(string[] value)
        {
            Type = SimpleValueType.StringArray;
            _value = value;
        }

        public SimpleValue(int[] value)
        {
            Type = SimpleValueType.NumberArray;
            _value = value;
        }

        public SimpleValueType Type { get; set; }

        private object _value;

        public string ValueAsString() => (string)_value;

        public int ValueAsNumber() => (int)_value;

        public string[] ValueAsStringArray() => (string[])_value;

        public int[] ValueAsNumberArray() => (int[])_value;
    }

    public enum SimpleValueType
    {
        String,
        Number,
        StringArray,
        NumberArray
    }
}