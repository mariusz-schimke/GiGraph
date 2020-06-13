using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a list of colors that may be used to generate a gradient fill, multicolor stripes or wedges, or multicolor edges.
    /// </summary>
    public class DotColorList : DotColorDefinition
    {
        /// <summary>
        /// Gets the colors of the color list (<see cref="DotColor"/>, <see cref="DotWeightedColor"/>).
        /// </summary>
        public virtual DotColor[] Colors { get; }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> and <see cref="DotWeightedColor"/>. If only weighted colors are provided,
        /// the weights must sum to at most 1. If both colors with and without weights are provided,
        /// the sum of the weighted ones must be below 1.</param>
        public DotColorList(params DotColor[] colors)
        {
            if (true != colors?.Any())
            {
                throw new ArgumentException("At least one color has to be specified for a color list.", nameof(colors));
            }

            var totalWeight = colors.Sum(c => c.GetWeight().GetValueOrDefault(0));

            if (totalWeight > 1)
            {
                throw new ArgumentException("The weights of the colors must sum to at most 1 for a color list.", nameof(colors));
            }

            if (totalWeight == 1 && colors.Any(color => !color.GetWeight().HasValue))
            {
                throw new ArgumentException("The weights of the colors sum to 1, but some colors have no weights assigned. Remove them or decrease the total weight below 1.", nameof(colors));
            }

            Colors = colors;
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> and <see cref="DotWeightedColor"/>. If only weighted colors are provided,
        /// the weights must sum to at most 1. If both colors with and without weights are provided,
        /// the sum of the weighted ones must be below 1.</param>
        public DotColorList(IEnumerable<DotColor> colors)
            : this(colors.ToArray())
        {
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public DotColorList(params Color[] colors)
            : this((IEnumerable<Color>) colors)
        {
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public DotColorList(IEnumerable<Color> colors)
            : this(colors.Select(c => new DotColor(c)))
        {
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="color1">The first color to initialize the instance with.</param>
        /// <param name="color2">The second color to initialize the instance with.</param>
        /// <param name="weight1">The optional weight of the first color in the range 0 ≤ <paramref name="weight1"/> ≤ 1.</param>
        /// <param name="weight2">The optional weight of the second color in the range 0 ≤ <paramref name="weight2"/> ≤ 1.</param>
        public DotColorList(Color color1, Color color2, double? weight1 = null, double? weight2 = null)
            : this(new[]
            {
                Mono(color1, weight1),
                Mono(color2, weight2)
            })
        {
        }

        public override string ToString()
        {
            return string.Join(", ", Colors.Select(color => color.ToString()));
        }

        protected internal override string GetDotEncodedColor(DotGenerationOptions options)
        {
            var colors = Colors.Select(color => color.GetDotEncodedColor(options));
            return string.Join(":", colors);
        }
    }
}