using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Graphs.Style;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterStyleAttributes : IDotGraphClusterCommonStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the background color of the cluster (default: none). Used as the initial background for the cluster. If the
    ///         <see cref="DotGraphFillStyle.Filled"/> fill style is used for the cluster, its
    ///         <see cref="IDotGraphClusterCommonStyleAttributes.FillColor"/> will overlay the background color.
    ///     </para>
    ///     <para>
    ///         When <see cref="DotGradientColor"/> is used, a gradient fill is generated. By default, this is a linear fill; applying
    ///         the <see cref="DotGraphFillStyle.Radial"/> fill style to the cluster will cause a radial fill. If the second color is
    ///         <see cref="System.Drawing.Color.Empty"/>, the default color is used for it. See also the <see cref="GradientFillAngle"/>
    ///         attribute for setting a gradient angle.
    ///     </para>
    /// </summary>
    DotColorDefinition? BackgroundColor { get; set; }

    /// <summary>
    ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
    ///     is set, the standard <see cref="DotColorSchemes.X11"/> naming is used. For example, if
    ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9"/> Brewer color scheme is used, then a color named "7", e.g.
    ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes"/> for
    ///     supported scheme names.
    /// </summary>
    string? ColorScheme { get; set; }

    /// <summary>
    ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
    ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
    ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
    ///     the value. If unset, the default angle is 0.
    /// </summary>
    int? GradientFillAngle { get; set; }

    /// <summary>
    ///     Sets the number of peripheries used in cluster boundaries (default: 1, minimum: 0, maximum: 1). Setting peripheries to 0 will
    ///     remove the boundaries.
    /// </summary>
    int? Peripheries { get; set; }
}