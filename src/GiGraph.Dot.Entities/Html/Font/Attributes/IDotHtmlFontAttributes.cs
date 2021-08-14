using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Html.Font.Attributes
{
    /// <summary>
    ///     The attributes of an HTML &lt;font&gt; element.
    /// </summary>
    public interface IDotHtmlFontAttributes
    {
        /// <summary>
        ///     Specifies the font to use within the scope of the current element. It can be overridden by a corresponding attribute in
        ///     descendents. By default, the font name is determined by the corresponding node, edge or graph.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Specifies the size of the font, in points, to use within the scope of the current element. It can be overridden by a
        ///     corresponding attribute in descendents. By default, the font size is determined by the corresponding node, edge or graph.
        /// </summary>
        double? Size { get; set; }

        /// <summary>
        ///     Sets the color of the font within the scope of the current element. It can be overridden by a corresponding attribute in
        ///     descendents. By default, the font color is determined by the corresponding node, edge or graph.
        /// </summary>
        DotColor Color { get; set; }
    }
}