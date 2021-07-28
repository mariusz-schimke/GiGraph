using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A DOT-encodable value attribute.
    /// </summary>
    /// <typeparam name="TComplexType">
    ///     A complex type that implements the <see cref="IDotEncodable" /> interface.
    /// </typeparam>
    public class DotComplexAttribute<TComplexType> : DotAttribute<TComplexType>
        where TComplexType : IDotEncodable
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotComplexAttribute(string key, TComplexType value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}