using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents graph scaling definition.
    /// </summary>
    public class DotGraphScalingDefinitionAttribute : DotAttribute<DotGraphScalingDefinition>
    {
        /// <summary>
        ///     Creates a new graph scaling definition attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotGraphScalingDefinitionAttribute(string key, DotGraphScalingDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}