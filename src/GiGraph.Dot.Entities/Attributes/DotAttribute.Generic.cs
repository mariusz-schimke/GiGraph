using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute<T> : DotAttribute
    {
        protected DotAttribute(string key, T value)
            : base(key)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the value of the attribute.
        /// </summary>
        public virtual T Value { get; }

        /// <inheritdoc />
        public override object GetValue()
        {
            return Value;
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.ToString();
        }
    }
}