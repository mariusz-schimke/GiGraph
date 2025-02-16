using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Colors;

/// <summary>
///     Represents a weighted color for use in color lists only (<see cref="DotMulticolor" />).
/// </summary>
public class DotWeightedColor : DotColor
{
    /// <summary>
    ///     Creates a new instance initialized with a named color.
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
    ///         <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default
    ///         <see cref="DotColorSchemes.X11" /> naming.
    ///     </para>
    /// </param>
    public DotWeightedColor(Color color, double weight, string? scheme = null)
        : base(color, scheme)
    {
        Weight = weight;
    }

    /// <summary>
    ///     Creates a new instance initialized with a named color.
    /// </summary>
    /// <param name="name">
    ///     The color name to initialize the instance with. The name will be evaluated in the context of the <paramref name="scheme" />
    ///     if specified, in the context of the scheme applied to the current element if any, or in the context of the default
    ///     <see cref="DotColorSchemes.X11" /> scheme otherwise.
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
    ///         <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default
    ///         <see cref="DotColorSchemes.X11" /> naming.
    ///     </para>
    /// </param>
    public DotWeightedColor(string name, double weight, string? scheme = null)
        : this(Color.FromName(name), weight, scheme)
    {
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
    public double Weight { get; }

    protected internal override double? GetWeight() => Weight;

    protected internal override string GetDotEncodedColor(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var color = base.GetDotEncodedColor(options, syntaxRules);
        return $"{color};{Weight.ToString(syntaxRules.Culture)}";
    }
}