using System;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Text;
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

            table.Children
               .AddRow(row =>
                {
                    row.Children.AddCell(
                        cell =>
                        {
                            cell.RowSpan = 3;
                            cell.Children.Add(new DotHtmlText($"Foo{Environment.NewLine}Bar"));
                        }
                    );

                    row.Children.AddCell(
                        cell =>
                        {
                            cell.ColumnSpan = 3;
                            cell.HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Left;
                            cell.Children.Add(new DotHtmlText("Baz"));
                        }
                    );

                    row.Children.AddCell(
                        cell =>
                        {
                            cell.RowSpan = 3;
                            cell.Children.Add(new DotHtmlText("Qux"));
                        }
                    );

                    row.Children.AddCell(
                        cell =>
                        {
                            cell.RowSpan = 3;
                            cell.Children.Add(new DotHtmlText("Quux"));
                        }
                    );
                });

            table.Children.AddRow(
                row =>
                {
                    row.Children.AddCell(
                        cell => cell.Children.Add(new DotHtmlText("Garply"))
                    );

                    row.Children.AddCell(
                        cell => cell.Children.Add(new DotHtmlText("Waldo"))
                    );

                    row.Children.AddCell(
                        cell =>
                        {
                            cell.PortName = "port1";
                            cell.Children.Add(new DotHtmlText("Fred"));
                        }
                    );
                }
            );

            table.Children.AddRow(
                row => row.Children.AddCell(
                    cell =>
                    {
                        cell.ColumnSpan = 3;
                        cell.HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Right;
                        cell.Children.Add(new DotHtmlText("Plugh"));
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