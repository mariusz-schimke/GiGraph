using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Label justification attribute.
    /// </summary>
    public class DotHorizontalAlignmentAttribute : DotAttribute<DotHorizontalAlignment>
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
        public DotHorizontalAlignmentAttribute(string key, DotHorizontalAlignment value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotHorizontalAlignment.Left:
                    return "l";

                case DotHorizontalAlignment.Center:
                    return "c";

                case DotHorizontalAlignment.Right:
                    return "r";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified horizontal label alignment '{Value}' is not supported.");
            }
        }
    }
}