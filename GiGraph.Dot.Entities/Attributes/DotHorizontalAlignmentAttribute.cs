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
            return Value switch
            {
                DotHorizontalAlignment.Left => "l",
                DotHorizontalAlignment.Center => "c",
                DotHorizontalAlignment.Right => "r",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified horizontal alignment option '{Value}' is invalid.")
            };
        }
    }
}