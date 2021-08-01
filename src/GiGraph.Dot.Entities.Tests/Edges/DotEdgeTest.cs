using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
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
    }
}