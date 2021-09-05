using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding
{
    public class DotEdgeWithSubgraphEndpointsPaddingTest
    {
        [Fact]
        public void edge_has_no_padding_when_no_subgraph_endpoints()
        {
            var graph = new DotGraph();

            graph.Edges.AddSequence(
                new DotEndpointGroup(
                    new DotEndpoint("node1"),
                    new DotClusterEndpoint("cluster1"),
                    new DotClusterEndpoint(null)
                ),
                new DotEndpointGroup(
                    new DotEndpoint("node2"),
                    new DotClusterEndpoint("cluster2"),
                    new DotClusterEndpoint(null)
                ),
                new DotEndpoint("node3", "port1")
            );

            var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
            Snapshot.Match(graph.Build(formatting), "edge_without_padding.gv");

            formatting.SingleLine = true;
            Snapshot.Match(graph.Build(formatting), "edge_without_padding_single_line.gv");
        }

        [Fact]
        public void edge_has_padding_when_it_contains_subgraph_endpoints()
        {
            var graph = new DotGraph();

            for (int i = 0; i < 3; i++)
            {
                graph.Edges.AddSequence(
                    new DotEndpointGroup(
                        new DotEndpoint("node1"),
                        new DotClusterEndpoint("cluster1"),
                        new DotClusterEndpoint(null)
                    ),
                    new DotSubgraphEndpoint("node2", "node3")
                );
            }

            var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
            Snapshot.Match(graph.Build(formatting), "edge_with_padding.gv");

            formatting.SingleLine = true;
            Snapshot.Match(graph.Build(formatting), "edge_with_padding_single_line.gv");
        }
    }
}