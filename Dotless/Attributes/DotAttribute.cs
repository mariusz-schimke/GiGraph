namespace Dotless.Attributes
{
    public abstract class DotAttribute<T>
    {
        protected readonly string _key;
        protected readonly T _value;

        public DotAttribute(string key, T value)
        {
            _key = key;
            _value = value;
        }

        protected abstract string? Render(bool minified);
    }
}
