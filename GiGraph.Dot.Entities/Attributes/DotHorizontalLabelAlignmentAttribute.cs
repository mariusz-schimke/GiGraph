using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Label justification attribute.
    /// </summary>
    public class DotHorizontalLabelAlignmentAttribute : DotAttribute<DotHorizontalLabelAlignment>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotHorizontalLabelAlignmentAttribute(string key, DotHorizontalLabelAlignment value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotHorizontalLabelAlignment.Left:
                    return "l";

                case DotHorizontalLabelAlignment.Center:
                    return "c";

                case DotHorizontalLabelAlignment.Right:
                    return "r";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified horizontal label alignment '{Value}' is not supported.");
            }
        }
    }
}