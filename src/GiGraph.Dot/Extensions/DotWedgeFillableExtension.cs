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
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetWedgedFill<T>(this T entity, DotMulticolor colors)
        where T : IDotFillable, IDotWedgeFillable
    {
        entity.SetFillStyle(DotFillStyle.Wedged);
        entity.SetFillColor(colors);
        return entity;
    }

    /// <summary>
    ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetWedgedFill<T>(this T entity, params DotColor[] colors)
        where T : IDotFillable, IDotWedgeFillable
    {
        entity.SetWedgedFill(new DotMulticolor(colors));
        return entity;
    }
}