using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes.Colors
{
    /// <summary>
    /// Color list attribute.
    /// If the value specifies multiple colors, with no weights, and a filled style is specified,
    /// a linear gradient fill is done using the first two colors. If weights are present, a degenerate linear gradient fill is done.
    /// This essentially does a fill using two colors, with the weights specifying how much of region is filled with each color.
    /// If the style attribute of the element contains the value <see cref="DotStyle.Radial"/>, then a radial gradient fill is done.
    /// These fills work with any shape.
    /// </summary>
    public class DotColorListAttribute : DotCommonAttribute<DotWeightedColor[]>
    {
        /// <summary>
        /// Creates a new color list attribute.
        /// </summary>
        /// <param name="key">The key of the attribute, for example "color" or "bgcolor".</param>
        /// <param name="colors">The value of the attribute as list of colors.
        /// If <see cref="DotWeightedColor.Weight"/> is specified for multiple elements, it must sum to at most 1.</param>
        public DotColorListAttribute(string key, params DotWeightedColor[] colors)
            : base(key, colors)
        {
            if (!colors.Any())
            {
                throw new ArgumentException("At least one color has to be specified for a color list.", nameof(colors));
            }

            if (colors.Sum(c => c.Weight.GetValueOrDefault(0)) > 1)
            {
                throw new ArgumentException("The weights of the color list items must sum to at most 1.", nameof(colors));
            }
        }

        /// <summary>
        /// Creates a new color list attribute.
        /// </summary>
        /// <param name="key">The key of the attribute, for example "color" or "bgcolor".</param>
        /// <param name="colors">The value of the attribute as list of colors.
        /// If <see cref="DotWeightedColor.Weight"/> is specified for multiple elements, it must sum to at most 1.</param>
        public DotColorListAttribute(string key, IEnumerable<DotWeightedColor> colors)
            : this(key, colors.ToArray())
        {
        }

        /// <summary>
        /// Creates a new color list attribute.
        /// </summary>
        /// <param name="key">The key of the attribute, for example "color" or "bgcolor".</param>
        /// <param name="colors">The value of the attribute as list of colors.</param>
        public DotColorListAttribute(string key, params Color[] colors)
            : this(key, (IEnumerable<Color>) colors)
        {
        }

        /// <summary>
        /// Creates a new color list attribute.
        /// </summary>
        /// <param name="key">The key of the attribute, for example "color" or "bgcolor".</param>
        /// <param name="colors">The value of the attribute as list of colors.</param>
        public DotColorListAttribute(string key, IEnumerable<Color> colors)
            : this(key, colors.Select(c => new DotWeightedColor(c)))
        {
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            var weightedColors = Value.Select(wc =>
            {
                var color = DotColorConverter.Convert(wc.Color, options);

                return wc.Weight.HasValue
                    ? $"{color};{wc.Weight.Value.ToString(CultureInfo.InvariantCulture)}"
                    : color;
            });

            if (Value.Length == 1)
            {
                // if the second color is missing, add a blank value at the end so that it is interpreted as a default color
                weightedColors = weightedColors.Concat(new[] {" "});
            }

            return string.Join(":", weightedColors);
        }
    }
}