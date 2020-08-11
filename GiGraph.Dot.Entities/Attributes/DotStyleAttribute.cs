using System;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Style attribute. Individual styles are applicable to specific element types only.
    /// </summary>
    public class DotStyleAttribute : DotAttribute<DotStyle>
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
        public DotStyleAttribute(string key, DotStyle value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var styles = Enum.GetValues(typeof(DotStyle))
               .Cast<DotStyle>()
               .Where(style => style != DotStyle.Default)
               .Where(style => Value.HasFlag(style))
               .Select(style => GetDotEncodedStyleItemValue(style, options, syntaxRules));

            const string separator = ", ";
            return options.OrderElements
                ? string.Join(separator, styles.OrderBy(style => style))
                : string.Join(separator, styles);
        }

        protected virtual string GetDotEncodedStyleItemValue(DotStyle item, DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return item switch
            {
                DotStyle.Default => null,
                DotStyle.Solid => "solid",
                DotStyle.Dashed => "dashed",
                DotStyle.Dotted => "dotted",
                DotStyle.Bold => "bold",
                DotStyle.Rounded => "rounded",
                DotStyle.Diagonals => "diagonals",
                DotStyle.Filled => "filled",
                DotStyle.Striped => "striped",
                DotStyle.Wedged => "wedged",
                DotStyle.Radial => "radial",
                DotStyle.Tapered => "tapered",
                DotStyle.Invisible => "invis",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified element style '{Value}' is not supported.")
            };
        }
    }
}