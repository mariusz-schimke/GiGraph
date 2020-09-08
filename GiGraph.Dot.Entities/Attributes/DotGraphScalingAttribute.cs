using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents graph scaling options.
    /// </summary>
    public class DotGraphScalingAttribute : DotAttribute<DotGraphScaling>
    {
        /// <summary>
        ///     Creates a new graph scaling option attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotGraphScalingAttribute(string key, DotGraphScaling value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return new DotGraphScalingOption(Value).GetDotEncodedValue(options, syntaxRules);
        }
    }
}