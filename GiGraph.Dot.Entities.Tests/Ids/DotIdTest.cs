using GiGraph.Dot.Entities.Types.Identifiers;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Ids
{
    public class DotIdTest
    {
        [Fact]
        public void ids_are_equal()
        {
            var id1 = new DotId("1");
            var id2 = new DotId("1");
            Assert.Equal(id1, id2);
            Assert.Equal(id1.GetHashCode(), id2.GetHashCode());
        }

        [Fact]
        public void ids_are_not_equal()
        {
            var id1 = new DotId("1");
            var id2 = new DotId("2");
            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1.GetHashCode(), id2.GetHashCode());
        }

        [Fact]
        public void id_and_cluster_id_are_not_equal()
        {
            var id1 = new DotId("1");
            var id2 = new DotClusterId("1");
            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1.GetHashCode(), id2.GetHashCode());
        }
    }
}