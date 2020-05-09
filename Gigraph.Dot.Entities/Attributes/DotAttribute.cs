namespace Gigraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotAttribute
    {
        protected readonly string _key;
        protected abstract bool HasValue { get; }

        protected abstract string GetValueAsString();

        string IDotAttribute.Key => _key;
        string IDotAttribute.Value => GetValueAsString();
        bool IDotAttribute.HasValue => HasValue;

        protected DotAttribute(string key)
        {
            _key = key;
        }
    }

    public abstract class DotAttribute<T> : DotAttribute, IDotAttribute
    {
        protected readonly T _value;
        protected override bool HasValue => _value is { };

        protected DotAttribute(string key, T value)
            : base(key)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value?.ToString();
        }

        protected override string GetValueAsString()
        {
            return _value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotAttribute<T> value)
        {
            return value is { } ? value._value : default;
        }
    }
}
