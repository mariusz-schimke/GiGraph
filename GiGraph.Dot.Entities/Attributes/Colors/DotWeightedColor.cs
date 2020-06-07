using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Colors
{
    /// <summary>
    /// Represents a weighted color.
    /// </summary>
    public class DotWeightedColor
    {
        protected double? _weight;

        /// <summary>
        /// The color to use.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The weight of the color in the range 0 ≤ <see cref="Weight"/> ≤ 1. 
        /// </summary>
        public double? Weight
        {
            get => _weight;
            set => _weight = !value.HasValue || value >= 0 && value <= 1
                ? value
                : throw new ArgumentException($"The color weight has to be in the range 0 ≤ {nameof(Weight)} ≤ 1.", nameof(Weight));
        }

        /// <summary>
        /// Creates a new instance initialized with a color and an optional weight.
        /// </summary>
        /// <param name="color">The color to use.</param>
        /// <param name="weight">The optional weight of the color in the range 0 ≤ <see cref="Weight"/> ≤ 1.</param>
        public DotWeightedColor(Color color, double? weight = null)
        {
            Color = color;
            Weight = weight;
        }

        /// <summary>
        /// Creates a new weighted color array from the specified colors.
        /// </summary>
        /// <param name="colors">The colors to initialize the array with.</param>
        public static DotWeightedColor[] FromColors(params Color[] colors)
        {
            return FromColors((IEnumerable<Color>) colors);
        }

        /// <summary>
        /// Creates a new weighted color array from the specified colors.
        /// </summary>
        /// <param name="colors">The colors to initialize the array with.</param>
        public static DotWeightedColor[] FromColors(IEnumerable<Color> colors)
        {
            return colors.Select(c => new DotWeightedColor(c)).ToArray();
        }

        /// <summary>
        /// Creates a new weighted color array from the specified colors.
        /// </summary>
        /// <param name="color1">The first color to initialize the array with.</param>
        /// <param name="color2">The second color to initialize the array with.</param>
        /// <param name="weight1">The optional weight of the first color in the range 0 ≤ <paramref name="weight1"/> ≤ 1.</param>
        /// <param name="weight2">The optional weight of the second color in the range 0 ≤ <paramref name="weight2"/> ≤ 1.</param>
        public static DotWeightedColor[] FromColors(Color color1, Color color2, double? weight1 = null, double? weight2 = null)
        {
            return new[]
            {
                new DotWeightedColor(color1, weight1),
                new DotWeightedColor(color2, weight2)
            };
        }
    }
}