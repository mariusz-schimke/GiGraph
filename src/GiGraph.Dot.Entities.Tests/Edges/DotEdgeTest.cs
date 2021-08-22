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
        public void has_properties_for_head_and_tail_attributes_exposed()
        {
            var graph = new DotGraph();

            graph.Edges.Head.Arrowhead = DotArrowheadShape.Box;
            graph.Edges.Tail.Arrowhead = DotArrowheadShape.Crow;

            // this test just makes sure that the head and tail attributes are exposed by the descendant class
            // (not to lose them as a result of some future refactoring)
            var edgeSequence = graph.Edges.AddSequence("a", "b", "c");
            edgeSequence.Heads.Port = "port";
            edgeSequence.Tails.Port = "port";

            Snapshot.Match(graph.Build(), "edge_head_and_tail_attributes");
        }
    }
}