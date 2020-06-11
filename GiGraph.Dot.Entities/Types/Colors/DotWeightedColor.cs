using System;
using System.Drawing;
using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a weighted color for use in a color list (<see cref="DotColorList"/>).
    /// </summary>
    public class DotWeightedColor : DotColor
    {
        /// <summary>
        /// The weight of the color in the range 0 ≤ <see cref="Weight"/> ≤ 1. 
        /// </summary>
        public virtual double Weight { get; }

        /// <summary>
        /// Creates a new instance initialized with a color and an optional weight.
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        /// <param name="weight">The weight of the color in the range 0 ≤ <paramref name="weight"/> ≤ 1.</param>
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

        protected internal override string GetDotEncodedColor(DotGenerationOptions options)
        {
            var color = base.GetDotEncodedColor(options);
            return $"{color};{Weight.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}