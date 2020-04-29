namespace Dotless.Attributes
{
    public abstract class DotAttribute<T> : IDotAttribute
    {
        protected readonly string _key;
        protected readonly T _value;

        internal string Key => _key;
        internal T Value => _value;

        string IDotAttribute.Key => _key;

        public DotAttribute(string key, T value)
        {
            _key = key;
            _value = value;
        }

        public override string? ToString()
        {
            return _value?.ToString();
        }
    }
}
