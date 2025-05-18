using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

public static class DotStripeFillableExtension
{
    /// <summary>
    ///     Sets a striped fill. Applicable to clusters and rectangularly-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetStripedFill<T>(this T @this, DotMulticolor colors)
        where T : IDotFillable, IDotStripeFillable
    {
        @this.SetFillStyle(DotFillStyle.Striped);
        @this.SetFillColor(colors);
        return @this;
    }

    /// <summary>
    ///     Sets a striped fill. Applicable to clusters and rectangularly-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetStripedFill<T>(this T @this, params DotColor[] colors)
        where T : IDotFillable, IDotStripeFillable =>
        @this.SetStripedFill(new DotMulticolor(colors));
}