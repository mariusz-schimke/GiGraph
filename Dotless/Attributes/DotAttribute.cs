namespace Dotless.Attributes
{
    public abstract class DotAttribute : IDotAttribute
    {
        protected readonly string _key;

        protected abstract bool HasValue { get; }

        string IDotAttribute.Key => _key;
        bool IDotAttribute.HasValue => HasValue;

        protected DotAttribute(string key)
        {
            _key = key;
        }
    }

    public abstract class DotAttribute<T> : DotAttribute, IDotAttribute<T>
    {
        protected readonly T _value;

        protected override bool HasValue => _value is { };

        T IDotAttribute<T>.Value => _value;

        protected DotAttribute(string key, T value)
            : base(key)
        {
            _value = value;
        }

        public override string? ToString()
        {
            return _value?.ToString();
        }

        public static implicit operator T(DotAttribute<T> value)
        {
            return value._value;
        }
    }
}
