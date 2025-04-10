using Bogus;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Output;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.CollectionSetters;

public class DotGraphLayoutAttributesTests : DotGraphAttributeSettersTestBase<IDotGraphLayoutAttributes, DotGraphLayoutAttributes>
{
    private readonly Faker _faker = new();

    [Fact]
    public void TestSetMethodUsingReflection()
    {
        var sourceAttributes = new DotGraphLayoutAttributes(new DotAttributeCollection())
        {
            ConcentrateEdges = _faker.Random.Bool(),
            Direction = _faker.Random.Enum<DotLayoutDirection>(),
            EdgeCrossingMinimizationScaleFactor = _faker.Random.Double(),
            EdgeOrderingMode = _faker.Random.Enum<DotEdgeOrderingMode>(),
            EnableGlobalRanking = _faker.Random.Bool(),
            Engine = _faker.Random.AlphaNumeric(10),
            FloatingNodeRank = _faker.Random.Enum<DotRank>(),
            ForceCircularLayout = _faker.Random.Bool(),
            ForceExternalLabels = _faker.Random.Bool(),
            NodeRank = _faker.Random.Enum<DotRank>(),
            NodeSeparation = _faker.Random.Double(),
            OutputOrder = _faker.Random.Enum<DotOutputOrder>(),
            Packing = new DotPackingMargin(_faker.Random.Int()),
            PackingMode = new DotArrayPackingMode(_faker.Random.Int()),
            RankSeparation = new DotRankSeparation(_faker.Random.Double(), _faker.Random.Bool()),
            RepeatEdgeCrossingMinimization = _faker.Random.Bool(),
            Rotation = _faker.Random.Double(0, 360),
            SortIndex = _faker.Random.Int()
        };

        var targetAttributes = new DotGraphLayoutAttributes(new DotAttributeCollection());
        targetAttributes.Set(sourceAttributes);

        AssertAttributesNonNullAndEqual(sourceAttributes, targetAttributes);
    }
}