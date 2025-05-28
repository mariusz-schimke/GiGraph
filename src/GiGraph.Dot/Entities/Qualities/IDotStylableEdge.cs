using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities;

public interface IDotStylableEdge
{
    /// <summary>
    ///     Sets the style of the edge.
    /// </summary>
    /// <param name="style">
    ///     The style to set.
    /// </param>
    void SetLineStyle(DotLineStyle style);

    /// <summary>
    ///     Sets the color of the edge.
    /// </summary>
    /// <param name="color">
    ///     The color to set.
    /// </param>
    void SetLineColor(DotColorDefinition color);

    /// <summary>
    ///     Sets the width of the edge.
    /// </summary>
    /// <param name="width">
    ///     The width to set.
    /// </param>
    void SetLineWidth(double? width);
}