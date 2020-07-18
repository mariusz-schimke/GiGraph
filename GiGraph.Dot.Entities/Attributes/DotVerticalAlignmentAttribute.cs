using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Vertical Label alignment attribute.
    /// </summary>
    public class DotVerticalAlignmentAttribute : DotAttribute<DotVerticalAlignment>
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
        public DotVerticalAlignmentAttribute(string key, DotVerticalAlignment value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotVerticalAlignment.Top:
                    return "t";

                case DotVerticalAlignment.Center:
                    return "c";

                case DotVerticalAlignment.Bottom:
                    return "b";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified vertical label alignment '{Value}' is not supported.");
            }
        }
    }
}