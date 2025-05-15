using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

public static class DotWedgeFillableExtension
{
    /// <summary>
    ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static void SetWedgedFill<T>(this T @this, DotMulticolor colors)
        where T : IDotFillable, IDotWedgeFillable
    {
        @this.SetFillStyle(DotFillStyle.Wedged);
        @this.SetFillColor(colors);
    }

    /// <summary>
    ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static void SetWedgedFill<T>(this T @this, params DotColor[] colors)
        where T : IDotFillable, IDotWedgeFillable
    {
        @this.SetWedgedFill(new DotMulticolor(colors));
    }
}