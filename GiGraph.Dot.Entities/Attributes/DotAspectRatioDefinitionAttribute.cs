using GiGraph.Dot.Entities.Types.AspectRatio;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents graph aspect ratio.
    /// </summary>
    public class DotAspectRatioDefinitionAttribute : DotAttribute<DotAspectRatioDefinition>
    {
        /// <summary>
        ///     Creates a new aspect ratio attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotAspectRatioDefinitionAttribute(string key, DotAspectRatioDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}