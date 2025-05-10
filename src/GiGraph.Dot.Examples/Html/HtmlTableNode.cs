using System.Diagnostics.Contracts;
using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Examples.Html;

public static class HtmlTableNode
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        var table = new DotHtmlTable
        {
            Style =
            {
                BorderWidth = 0,
                CellBorderWidth = 1,
            },
            CellSpacing = 0,
            CellPadding = 4
        };

        table.AddRow(row =>
        {
            row.AddCell($"Foo{Environment.NewLine}Bar", cell => cell.RowSpan = 3);

            row.AddCell(
                "Baz",
                cell =>
                {
                    cell.ColumnSpan = 3;
                    cell.HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Left;
                }
            );

            row.AddCell("Qux", cell => cell.RowSpan = 3);
            row.AddCell("Quux", cell => cell.RowSpan = 3);
        });

        table.AddRow(row =>
        {
            row.AddCell("Garply");
            row.AddCell("Waldo");
            row.AddCell(
                "Fred",
                new DotStyledFont(DotFontStyles.Bold | DotFontStyles.Italic, Color.RoyalBlue),
                cell => cell.PortName = "port1"
            );
        });

        table.AddRow(row =>
            row.AddCell(
                "Plugh",
                cell =>
                {
                    cell.ColumnSpan = 3;
                    cell.HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Right;
                }
            )
        );

        // sets a borderless (plain) shape of the node so that the HTML table fully determines the shape
        graph.Nodes.Add("Bar").SetHtmlTableAsLabel(table);

        // sets an attribute of the edge (can be set globally)
        graph.Edges.Add("Foo", "Bar").Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

        // an equivalent method of defining a port (directly on the endpoint; cannot be set globally)
        graph.Edges.Add("Foo", "Bar").Head.Endpoint.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

        return graph;
    }
}