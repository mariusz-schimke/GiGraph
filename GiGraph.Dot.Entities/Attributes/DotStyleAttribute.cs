using System;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
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
               .Select(style => GetDotEncodedStyle(style, options, syntaxRules));

            const string separator = ", ";
            return options.OrderElements
                ? string.Join(separator, styles.OrderBy(style => style))
                : string.Join(separator, styles);
        }

        protected virtual string GetDotEncodedStyle(DotStyle style, DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(style, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(style), $"The specified style '{style}' is invalid.");
        }
    }
}