using GiGraph.Dot.Entities.Edges.Endpoints;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Endpoints
{
    public class DotEndpointTest
    {
        [Fact]
        public void endpoints_are_equal()
        {
            var id1 = new DotEndpoint("1");
            var id2 = new DotEndpoint("1");
            Assert.True(id1.IsSameEndpoint(id2));
        }

        [Fact]
        public void endpoints_are_not_equal()
        {
            var id1 = new DotEndpoint("1");
            var id2 = new DotEndpoint("2");
            Assert.False(id1.IsSameEndpoint(id2));
        }

        [Fact]
        public void endpoint_and_cluster_endpoint_are_not_equal()
        {
            var id1 = new DotEndpoint("1");
            var id2 = new DotClusterEndpoint("1");
            Assert.False(id1.IsSameEndpoint(id2));
        }
    }
}