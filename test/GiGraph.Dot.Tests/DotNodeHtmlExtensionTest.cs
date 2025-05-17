using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Tests;

public class DotNodeHtmlExtensionTest
{
    [Fact]
    public void converts_node_to_plain_html_node_from_html_text()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetHtmlAsLabel("<b>label</b>");

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_plain_html_node_from_html_string"
        );
    }

    [Fact]
    public void converts_node_to_plain_html_node_from_html_entity()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetHtmlAsLabel(new DotHtmlTable());

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_plain_html_node_from_html_entity"
        );
    }

    [Fact]
    public void converts_node_to_plain_html_node_from_html_entity_builder()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetHtmlAsLabel(builder => builder.AppendTable(null));

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_plain_html_node_from_html_entity_builder"
        );
    }

    [Fact]
    public void converts_node_to_plain_html_node_from_table()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetHtmlTableAsLabel([]);

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_plain_html_node_from_table"
        );
    }

    [Fact]
    public void converts_node_to_plain_html_node_from_table_builder()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetHtmlTableAsLabel(buildTable: null);

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_plain_html_node_from_table_builder"
        );
    }
}