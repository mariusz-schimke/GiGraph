using Bogus;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
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
        var sourceAttributes = new DotGraphLayoutAttributes(new())
        {
            ConcentrateEdges = _faker.Random.Bool(),
            Direction = _faker.Random.Enum<DotLayoutDirection>(),
            EdgeOrderingMode = _faker.Random.Enum<DotEdgeOrderingMode>(),
            Engine = _faker.Random.AlphaNumeric(10),
            ForceExternalLabels = _faker.Random.Bool(),
            ForceCircularLayout = _faker.Random.Bool(),
            NodeRank = _faker.Random.Enum<DotRank>(),
            FloatingNodeRank = _faker.Random.Enum<DotRank>(),
            NodeSeparation = _faker.Random.Double(),
            Packing = new DotPackingMargin(_faker.Random.Int()),
            PackingMode = new DotArrayPackingMode(_faker.Random.Int()),
            RankSeparation = new DotRankSeparation(_faker.Random.Double(), _faker.Random.Bool()),
            RepeatEdgeCrossingMinimization = _faker.Random.Bool(),
            EdgeCrossingMinimizationScaleFactor = _faker.Random.Double(),
            Rotation = _faker.Random.Double(0, 360),
            SortIndex = _faker.Random.Int(),
            UseGlobalRanking = _faker.Random.Bool()
        };

        var targetAttributes = new DotGraphLayoutAttributes(new());
        targetAttributes.Set(sourceAttributes);

        CompareCollections(sourceAttributes, targetAttributes);
    }
}