using System;
using System.Drawing;
using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a weighted color for use in color lists only (<see cref="DotMultiColor" />).
    /// </summary>
    public class DotWeightedColor : DotColor
    {
        /// <summary>
        ///     Creates a new instance initialized with a color and a weight.
        /// </summary>
        /// <param name="color">
        ///     The color to initialize the instance with.
        /// </param>
        /// <param name="weight">
        ///     The weight of the color in the range 0 ≤ <paramref name="weight" /> ≤ 1. Represents the proportion of the area covered with
        ///     the specified color.
        /// </param>
        /// <param name="scheme">
        ///     <para>
        ///         The color scheme to evaluate the current color with if a named color is specified. See <see cref="DotColorSchemes" /> for
        ///         supported scheme names.
        ///     </para>
        ///     <para>
        ///         Pass null to use the color scheme set on the element, or to use the default scheme if none was set. Pass
        ///         <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default X11 naming.
        ///     </para>
        /// </param>
        public DotWeightedColor(Color color, double weight, string scheme = null)
            : base(color, scheme)
        {
            Weight = weight >= 0 && weight <= 1
                ? weight
                : throw new ArgumentException($"The color weight has to be in the range 0 ≤ {nameof(weight)} ≤ 1.", nameof(weight));
        }

        /// <summary>
        ///     Creates a new instance initialized with a color and a weight.
        /// </summary>
        /// <param name="color">
        ///     The color to initialize the instance with.
        /// </param>
        /// <param name="weight">
        ///     The weight of the color in the range 0 ≤ <paramref name="weight" /> ≤ 1. Represents the proportion of the area covered with
        ///     the specified color.
        /// </param>
        public DotWeightedColor(DotColor color, double weight)
            : this(color.Color, weight, color.Scheme)
        {
        }

        /// <summary>
        ///     The weight of the color in the range 0 ≤ <see cref="Weight" /> ≤ 1. Represents the proportion of the area covered with that
        ///     color.
        /// </summary>
        public virtual double Weight { get; }

        protected internal override double? GetWeight()
        {
            return Weight;
        }

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