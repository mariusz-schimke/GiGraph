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
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetStripedFill<T>(this T entity, DotMulticolor colors)
        where T : IDotFillable, IDotStripeFillable
    {
        entity.SetFillStyle(DotFillStyle.Striped);
        entity.SetFillColor(colors);
        return entity;
    }

    /// <summary>
    ///     Sets a striped fill. Applicable to clusters and rectangularly-shaped nodes (see <see cref="DotNodeDefinition.Shape"/>).
    /// </summary>
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="colors">
    ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
    ///     <see cref="DotWeightedColor"/> for them.
    /// </param>
    public static T SetStripedFill<T>(this T entity, params DotColor[] colors)
        where T : IDotFillable, IDotStripeFillable =>
        entity.SetStripedFill(new DotMulticolor(colors));
}