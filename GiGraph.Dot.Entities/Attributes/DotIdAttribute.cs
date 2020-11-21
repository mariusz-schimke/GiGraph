using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents the identifier of an element.
    /// </summary>
    public abstract class DotIdAttribute : DotAttribute<string>
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="id">
        ///     The identifier of the element.
        /// </param>
        protected DotIdAttribute(string key, string id)
            : base(key, id)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // use the same identifier escaping pipeline as the one used by entity generators
            return syntaxRules.IdentifierEscaper.Escape(GetId(options, syntaxRules));
        }

        protected virtual string GetId(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value;
        }
    }
}