using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions;

/// <summary>
///     Provides extension methods for <see cref="DotNodeDefinition" />.
/// </summary>
public static class DotNodeToHtmlExtension
{
    /// <summary>
    ///     Converts the current node to an HTML node by assigning HTML text to its label attribute, and setting its shape to
    ///     <see cref="DotNodeShape.Plain" />. See the
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     to learn what HTML grammar is supported. Useful when the HTML entity represents a table, and you don't want the node to have
    ///     any shape.
    /// </summary>
    /// <param name="node">
    ///     The node to convert.
    /// </param>
    /// <param name="html">
    ///     The HTML text to assign to node label.
    /// </param>
    public static void ToPlainHtmlNode(this DotNodeDefinition node, string html)
    {
        node.ToPlainHtmlNode((DotHtmlLabel) (DotHtmlString) html);
    }

    /// <summary>
    ///     Converts the current node to an HTML node by assigning HTML to its label attribute, and setting its shape to
    ///     <see cref="DotNodeShape.Plain" />. Useful when the HTML entity represents a table, and you don't want the node to have any
    ///     shape.
    /// </summary>
    /// <param name="node">
    ///     The node to convert.
    /// </param>
    /// <param name="html">
    ///     The HTML entity to assign to node label.
    /// </param>
    public static void ToPlainHtmlNode(this DotNodeDefinition node, IDotHtmlEntity html)
    {
        node.ToPlainHtmlNode(new DotHtmlLabel(html));
    }

    /// <summary>
    ///     Converts the current node to an HTML node by assigning custom-built HTML to its label attribute, and setting its shape to
    ///     <see cref="DotNodeShape.Plain" />. Useful when the custom-built HTML represents a table, and you don't want the node to have
    ///     any shape.
    /// </summary>
    /// <param name="node">
    ///     The node to convert.
    /// </param>
    /// <param name="buildHtml">
    ///     A method delegate that provides an HTML builder to compose the node's content.
    /// </param>
    public static void ToPlainHtmlNode(this DotNodeDefinition node, Action<DotHtmlBuilder> buildHtml)
    {
        var builder = new DotHtmlBuilder();
        buildHtml(builder);

        ToPlainHtmlNode(node, builder.Build());
    }

    /// <summary>
    ///     Converts the current node to an HTML node by assigning a custom-built HTML table to its label attribute, and setting its
    ///     shape to <see cref="DotNodeShape.Plain" />. The content and shape of the node will be fully determined by the composed table.
    /// </summary>
    /// <param name="node">
    ///     The node to convert.
    /// </param>
    /// <param name="buildTable">
    ///     A method delegate that provides an HTML table to compose the node's content.
    /// </param>
    public static void ToHtmlTableNode(this DotNodeDefinition node, Action<DotHtmlTable> buildTable)
    {
        var table = new DotHtmlTable();
        buildTable(table);

        ToPlainHtmlNode(node, table);
    }

    /// <summary>
    ///     Converts the current node to an HTML node by assigning the specified HTML table to its label attribute, and setting its shape
    ///     to <see cref="DotNodeShape.Plain" />. The content and shape of the node will be fully determined by the table.
    /// </summary>
    /// <param name="node">
    ///     The node to convert.
    /// </param>
    /// <param name="table">
    ///     The HTML table to assign to node label.
    /// </param>
    public static void ToHtmlTableNode(this DotNodeDefinition node, DotHtmlTable table)
    {
        ToPlainHtmlNode(node, table);
    }

    private static void ToPlainHtmlNode(this DotNodeDefinition node, DotHtmlLabel label)
    {
        node.Shape = DotNodeShape.Plain;
        node.Label = label;
    }
}