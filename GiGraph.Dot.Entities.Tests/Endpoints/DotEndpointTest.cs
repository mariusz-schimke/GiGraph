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
            Assert.Equal(id1, id2);
            Assert.Equal(id1.GetHashCode(), id2.GetHashCode());
        }

        [Fact]
        public void endpoints_are_not_equal()
        {
            var id1 = new DotEndpoint("1");
            var id2 = new DotEndpoint("2");
            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1.GetHashCode(), id2.GetHashCode());
        }

        [Fact]
        public void endpoint_and_cluster_endpoint_are_not_equal()
        {
            var id1 = new DotEndpoint("1");
            var id2 = new DotClusterEndpoint("1");
            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1.GetHashCode(), id2.GetHashCode());
        }
    }
}