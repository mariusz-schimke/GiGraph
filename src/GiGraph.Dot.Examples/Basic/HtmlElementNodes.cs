using System;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Examples.Basic
{
    public static class HtmlElementNodes
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            var table = new DotHtmlTable
            {
                BorderWidth = 0,
                CellBorderWidth = 1,
                CellSpacing = 0,
                CellPadding = 4
            };

            table.AddRow(row =>
            {
                row.AddCell(
                    $"Foo{Environment.NewLine}Bar",
                    cell => cell.RowSpan = 3
                );

                row.AddCell(
                    "Baz",
                    cell =>
                    {
                        cell.ColumnSpan = 3;
                        cell.HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Left;
                    }
                );

                row.AddCell(
                    "Qux",
                    cell => cell.RowSpan = 3
                );

                row.AddCell(
                    "Quux",
                    cell => cell.RowSpan = 3
                );
            });

            table.AddRow(row =>
            {
                row.AddCell("Garply");
                row.AddCell("Waldo");
                row.AddCell(
                    "Fred",
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

            graph.Nodes.Add("Bar").ToHtmlNode(table);

            // the following line is equivalent to the next one as far as visualization is concerned
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

            // an equivalent method of defining a port
            graph.Edges.Add("Foo", "Bar").Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

            return graph;
        }
    }
}