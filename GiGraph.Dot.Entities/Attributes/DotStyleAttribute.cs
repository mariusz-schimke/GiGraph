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
    public class DotStyleAttribute : DotAttribute<DotStyles>
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
        public DotStyleAttribute(string key, DotStyles value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var styles = Enum.GetValues(typeof(DotStyles))
               .Cast<DotStyles>()
               .Where(style => style != DotStyles.Default)
               .Where(style => Value.HasFlag(style))
               .Select(style => GetDotEncodedStyle(style, options, syntaxRules));

            return string.Join(", ", styles.OrderBy(style => style));
        }

        protected virtual string GetDotEncodedStyle(DotStyles style, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(style, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(style), $"The specified style '{style}' is invalid.");
        }
    }
}