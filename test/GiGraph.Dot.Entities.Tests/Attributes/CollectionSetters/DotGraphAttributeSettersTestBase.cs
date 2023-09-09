using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.CollectionSetters;

public class DotGraphAttributeSettersTestBase<TInterface, TImplementation>
    where TImplementation : TInterface
{
    protected static void CompareCollections(TImplementation sourceAttributes, TImplementation targetAttributes)
    {
        foreach (var property in typeof(TInterface).GetProperties())
        {
            var sourceValue = property.GetValue(sourceAttributes);
            var targetValue = property.GetValue(targetAttributes);

            // this should throw when a new property is added that is not covered by the test
            Assert.NotNull(sourceValue);

            // compare the instances
            Assert.Equal(sourceValue, targetValue);
        }
    }
}