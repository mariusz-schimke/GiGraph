using GiGraph.Dot.Entities.Edges;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges
{
    public class DotEdgeTest
    {
        [Fact]
        public void is_loop_edge()
        {
            var edge = new DotEdge("a", "a");
            Assert.True(edge.IsLoop);
            Assert.True(edge.Loops("a"));
            Assert.True(DotEdge.IsLoopEdge(edge));
        }

        [Fact]
        public void is_loop_sequence_edge()
        {
            var edge = new DotEdgeSequence("a", "b", "a");
            Assert.True(DotEdge.IsLoopEdge(edge));

            edge = new DotEdgeSequence("a", "a");
            Assert.True(DotEdge.IsLoopEdge(edge));
        }

        [Fact]
        public void is_not_loop_sequence_edge()
        {
            var edge = new DotEdgeSequence("a", "b", "c");
            Assert.False(DotEdge.IsLoopEdge(edge));
        }

        [Fact]
        public void is_not_loop_edge()
        {
            var edge = new DotEdge("a", "b");
            Assert.False(edge.IsLoop);
            Assert.False(edge.Loops("a"));
            Assert.False(DotEdge.IsLoopEdge(edge));
        }
    }
}