using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Arrowheads;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges
{
    public class DotEdgeTest
    {
        [Fact]
        public void is_loop_edge()
        {
            var edge = new DotEdge("a");
            Assert.True(edge.IsLoop);
            Assert.True(edge.Loops("a"));

            edge = new DotEdge(new DotClusterEndpoint("a"));
            Assert.True(edge.IsLoop);
            Assert.True(edge.Loops(new DotClusterEndpoint("a")));
            Assert.True(edge.Loops("a"));
        }

        [Fact]
        public void is_not_loop_edge()
        {
            var edge = new DotEdge("a", "b");
            Assert.False(edge.IsLoop);
            Assert.False(edge.Loops("a"));

            edge = new DotEdge("a", new DotClusterEndpoint("a"));
            Assert.False(edge.IsLoop);
            Assert.False(edge.Loops("a"));

            edge = new DotEdge(new DotClusterEndpoint("a"));
            Assert.False(edge.Loops(new DotEndpoint("a")));
        }

        [Fact]
        public void edge_sequence_has_properties_for_head_and_tail_attributes_exposed_and_not_mistaken()
        {
            // this test makes sure that the head attributes are not replaced with tail attributes implementation or the other way round
            // (because the Head(s) and Tail(s) properties are the same classes, accepting any endpoint attributes implementation as a constructor parameter)

            var graph = new DotGraph();

            // edge collection
            graph.Edges.Head.Arrowhead = DotArrowheadShape.Box;
            graph.Edges.Tail.Arrowhead = DotArrowheadShape.Crow;

            graph.Edges.Head.Hyperlink.Href = "https://www.google.com/search?q=head";
            graph.Edges.Tail.Hyperlink.Href = "https://www.google.com/search?q=tail";

            // ordinary edges
            graph.Edges.AddLoop("edge1", edge =>
            {
                edge.Head.Arrowhead = DotArrowheadShape.Box;
                edge.Tail.Arrowhead = DotArrowheadShape.Crow;
                edge.Head.Hyperlink.Href = "https://www.google.com/search?q=head";
                edge.Tail.Hyperlink.Href = "https://www.google.com/search?q=tail";
            });

            // edge sequence
            // this test just makes sure that the head and tail attributes are exposed by the descendant class
            // (not to lose them as a result of some future refactoring)
            graph.Edges.AddSequence(edge =>
                {
                    edge.Heads.Port = "head_port";
                    edge.Tails.Port = "tail_port";
                    edge.Heads.Hyperlink.Href = "https://www.google.com/search?q=head";
                    edge.Tails.Hyperlink.Href = "https://www.google.com/search?q=tail";
                },
                "a", "b", "c");

            Snapshot.Match(graph.Build(), "edge_head_and_tail_attributes");
        }
    }
}