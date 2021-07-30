using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Html.Font.Attributes
{
    /// <summary>
    ///     The attributes of an HTML font element.
    /// </summary>
    public interface IDotHtmlFontAttributes
    {
        /// <summary>
        ///     Sets the color of the font within the scope of the current element. By default, the font color is determined by the
        ///     corresponding node, edge or graph.
        /// </summary>
        DotColor Color { get; set; }
    }
}