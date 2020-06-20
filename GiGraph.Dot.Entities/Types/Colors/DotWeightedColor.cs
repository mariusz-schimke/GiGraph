using System;
using System.Drawing;
using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a weighted color for use in color lists only (<see cref="DotColorList"/>).
    /// </summary>
    public class DotWeightedColor : DotColor
    {
        /// <summary>
        /// The weight of the color in the range 0 ≤ <see cref="Weight"/> ≤ 1.
        /// Represents the proportion of the area covered with that color.
        /// </summary>
        public virtual double Weight { get; }

        /// <summary>
        /// Creates a new instance initialized with a color and a weight.
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        /// <param name="weight">The weight of the color in the range 0 ≤ <paramref name="weight"/> ≤ 1.
        /// Represents the proportion of the area covered with the specified color.</param>
        public DotWeightedColor(Color color, double weight)
            : base(color)
        {
            Weight = weight >= 0 && weight <= 1
                ? weight
                : throw new ArgumentException($"The color weight has to be in the range 0 ≤ {nameof(weight)} ≤ 1.", nameof(weight));
        }

        protected internal override double? GetWeight() => Weight;

        public override string ToString()
        {
            return $"{base.ToString()}/{Weight.ToString(CultureInfo.InvariantCulture)}";
        }

        protected internal override string GetDotEncodedColor(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var color = base.GetDotEncodedColor(options, syntaxRules);
            return $"{color};{Weight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}