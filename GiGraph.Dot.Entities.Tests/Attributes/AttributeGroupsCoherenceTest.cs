using System;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class AttributeGroupsCoherenceTest : AttributesTestBase
    {
        [Theory]
        [InlineData(typeof(IDotEdgeHeadAttributes), typeof(IDotEdgeTailAttributes))]
        public void interfaces_contain_equivalent_members(Type interface1, Type interface2)
        {
            var interface1PropMethodPairs = GetInterfacePropertyAndAccessorPairs(interface1);
            var interface2PropMethodPairs = GetInterfacePropertyAndAccessorPairs(interface2);

            Assert.Equal(interface1PropMethodPairs.Length, interface2PropMethodPairs.Length);

            foreach (var interface1PropMethodPair in interface1PropMethodPairs)
            {
                Assert.NotNull(interface1PropMethodPair.Accessor);
                Assert.Contains(interface2PropMethodPairs, x =>
                    interface1PropMethodPair.Property.Name.Equals(x.Property.Name)&&
                    interface1PropMethodPair.Property.PropertyType == x.Property.PropertyType);
            }
        }
    }
}