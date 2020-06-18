using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A boolean value attribute.
    /// </summary>
    public class DotBoolAttribute : DotAttribute<bool>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotBoolAttribute(string key, bool value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value ? "true" : "false";
        }
    }
}