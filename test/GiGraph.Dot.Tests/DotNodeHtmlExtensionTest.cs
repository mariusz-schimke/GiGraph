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
        graph.Nodes.Add("node1").SetAsHtml("<b>label</b>");

        Snapshot.Match(
            graph.ToDotString(),
            "graph_with_plain_html_node_from_html_string"
        );
    }

    [Fact]
    public void converts_node_to_plain_html_node_from_html_entity()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetAsHtml(new DotHtmlTable());

        Snapshot.Match(
            graph.ToDotString(),
            "graph_with_plain_html_node_from_html_entity"
        );
    }
}