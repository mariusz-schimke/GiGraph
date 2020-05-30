using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Style attribute. Individual styles are applicable to specific element types only.
    /// </summary>
    public class DotStyleAttribute : DotCommonAttribute<DotStyle>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotStyleAttribute(string key, DotStyle value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue()
        {
            var styles = Enum.GetValues(typeof(DotStyle))
                .Cast<DotStyle>()
                .Where(style => style != DotStyle.Default)
                .Where(style => Value.HasFlag(style))
                .Select(style => GetDotEncodedStyleItemValue(style))
                .OrderBy(style => style);

            return string.Join(", ", styles);
        }

        protected virtual string GetDotEncodedStyleItemValue(DotStyle item)
        {
            switch (item)
            {
                case DotStyle.Default:
                    return null;

                case DotStyle.Solid:
                    return "solid";

                case DotStyle.Dashed:
                    return "dashed";

                case DotStyle.Dotted:
                    return "dotted";

                case DotStyle.Bold:
                    return "bold";

                case DotStyle.Rounded:
                    return "rounded";

                case DotStyle.Diagonals:
                    return "diagonals";

                case DotStyle.Filled:
                    return "filled";

                case DotStyle.Striped:
                    return "striped";

                case DotStyle.Wedged:
                    return "wedged";

                case DotStyle.Radial:
                    return "radial";

                case DotStyle.Tapered:
                    return "tapered";

                case DotStyle.Invisible:
                    return "invis";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified element style '{Value}' is not supported.");
            }
        }
    }
}
