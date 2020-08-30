using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     The fixedsize attribute of node.
    /// </summary>
    public class DotNodeSizingModeAttribute : DotAttribute<DotNodeSizingMode>
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
        public DotNodeSizingModeAttribute(string key, DotNodeSizingMode value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified node sizing mode '{Value}' is invalid.");
        }
    }
}