using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Tests
{
    public class DotNodeToHtmlExtensionTest
    {
        [Fact]
        public void converts_node_to_html_node_from_html_text()
        {
            var graph = new DotGraph();
            graph.Nodes.Add("node1")
               .ToHtmlNode("<b>label</b>");

            Snapshot.Match(
                graph.Build(),
                "graph_with_html_node_from_html_text"
            );
        }

        [Fact]
        public void does_not_throw_for_null_html_text()
        {
            var node = new DotGraph().Nodes.Add("node1");
            node.ToHtmlNode((string) null);

            Assert.Null(node.Attributes.Label);
        }

        [Fact]
        public void converts_node_to_html_node_from_html_entity()
        {
            var graph = new DotGraph();
            graph.Nodes.Add("node1")
               .ToHtmlNode(new DotHtmlTable());

            Snapshot.Match(
                graph.Build(),
                "graph_with_html_node_from_html_entity"
            );
        }
    }
}