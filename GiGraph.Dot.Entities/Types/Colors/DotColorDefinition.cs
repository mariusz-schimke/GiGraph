using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a color definition as a single color (<see cref="DotColor"/>), as a gradient (<see cref="DotColorList"/>)
    /// or as multiple colors (<see cref="DotColorList"/>).
    /// </summary>
    public abstract class DotColorDefinition
    {
        protected internal abstract string GetDotEncodedColor(DotGenerationOptions options);

        /// <summary>
        /// Creates a new color instance initialized with a color (<see cref="DotColor"/>) and a weight, if provided (<see cref="DotWeightedColor"/>).
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        /// <param name="weight">The optional weight of the color in the range 0 ≤ <paramref name="weight"/> ≤ 1.</param>
        public static DotColor Create(Color color, double? weight = null)
        {
            if (weight.HasValue)
            {
                return new DotWeightedColor(color, weight.Value);
            }

            return new DotColor(color);
        }

        public static implicit operator DotColorDefinition(Color? color)
        {
            return color.HasValue ? new DotColor(color.Value) : null;
        }

        public static implicit operator DotColorDefinition(Color[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }
    }
}