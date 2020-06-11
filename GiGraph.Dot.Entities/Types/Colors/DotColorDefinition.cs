using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a color definition as a single color (<see cref="DotColor"/>), as a gradient (<see cref="DotColorList"/>)
    /// or as multiple colors (<see cref="DotColorList"/>).
    /// </summary>
    public abstract class DotColorDefinition : IDotEncodableValue
    {
        protected internal abstract string GetDotEncodedColor(DotGenerationOptions options);
        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedColor(options);

        /// <summary>
        /// Creates a new color instance initialized with a color (<see cref="DotColor"/>) and a weight, if provided (<see cref="DotWeightedColor"/>).
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        /// <param name="weight">The optional weight of the color in the range 0 ≤ <paramref name="weight"/> ≤ 1.</param>
        public static DotColor From(Color color, double? weight = null)
        {
            if (weight.HasValue)
            {
                return new DotWeightedColor(color, weight.Value);
            }

            return new DotColor(color);
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> and <see cref="DotWeightedColor"/>. If only weighted colors are provided,
        /// the weights must sum to at most 1. If both colors with and without weights are provided,
        /// the sum of the weighted ones must be below 1.</param>
        public static DotColorList From(params DotColor[] colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> and <see cref="DotWeightedColor"/>. If only weighted colors are provided,
        /// the weights must sum to at most 1. If both colors with and without weights are provided,
        /// the sum of the weighted ones must be below 1.</param>
        public static DotColorList From(IEnumerable<DotColor> colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public static DotColorList From(params Color[] colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public static DotColorList From(IEnumerable<Color> colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// Creates a new color list instance.
        /// </summary>
        /// <param name="color1">The first color to initialize the instance with.</param>
        /// <param name="color2">The second color to initialize the instance with.</param>
        /// <param name="weight1">The optional weight of the first color in the range 0 ≤ <paramref name="weight1"/> ≤ 1.</param>
        /// <param name="weight2">The optional weight of the second color in the range 0 ≤ <paramref name="weight2"/> ≤ 1.</param>
        public static DotColorList From(Color color1, Color color2, double? weight1 = null, double? weight2 = null)
        {
            return new DotColorList(color1, color2, weight1, weight2);
        }

        public static implicit operator DotColorDefinition(Color? color)
        {
            return color.HasValue ? new DotColor(color.Value) : null;
        }

        public static implicit operator DotColorDefinition(Color[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }

        public static implicit operator DotColorDefinition(DotColor[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }
    }
}