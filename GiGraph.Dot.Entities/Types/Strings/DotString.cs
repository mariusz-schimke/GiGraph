using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    public class DotString : IDotEncodableValue
    {
        protected readonly string _value;

        public DotString(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        protected internal virtual string GetDotEncodedValue(DotGenerationOptions options)
        {
            return _value;
        }

        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedValue(options);

        public static implicit operator DotString(string value)
        {
            return value is {} ? new DotString(value) : null;
        }

        public static implicit operator string(DotString value)
        {
            return value?._value;
        }
    }
}