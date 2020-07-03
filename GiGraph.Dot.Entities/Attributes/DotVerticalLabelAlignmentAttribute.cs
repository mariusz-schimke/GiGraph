using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Vertical Label alignment attribute.
    /// </summary>
    public class DotVerticalLabelAlignmentAttribute : DotAttribute<DotVerticalLabelAlignment>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotVerticalLabelAlignmentAttribute(string key, DotVerticalLabelAlignment value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotVerticalLabelAlignment.Top:
                    return "t";

                case DotVerticalLabelAlignment.Center:
                    return "c";

                case DotVerticalLabelAlignment.Bottom:
                    return "b";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified vertical label alignment '{Value}' is not supported.");
            }
        }
    }
}