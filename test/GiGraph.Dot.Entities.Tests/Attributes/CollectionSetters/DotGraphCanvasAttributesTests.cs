using Bogus;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Viewport;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.CollectionSetters;

public class DotGraphCanvasAttributesTests : DotGraphAttributeSettersTestBase<IDotGraphCanvasAttributes, DotGraphCanvasAttributes>
{
    private readonly Faker _faker = new();

    [Fact]
    public void TestSetMethodUsingReflection()
    {
        var sourceAttributes = new DotGraphCanvasAttributes(new DotAttributeCollection())
        {
            CenterDrawing = _faker.Random.Bool(),
            Dpi = _faker.Random.Double(),
            LandscapeOrientation = _faker.Random.Bool(),
            Margin = new DotPoint(_faker.Random.Double(), _faker.Random.Double()),
            Orientation = _faker.PickRandom<DotOrientation>(),
            OrientationAngle = _faker.Random.Int(),
            Padding = new DotPoint(_faker.Random.Double(), _faker.Random.Double()),
            Resolution = _faker.Random.Double(),
            Scaling = new DotGraphScalingAspectRatio(_faker.Random.Double()),
            Size = new DotPoint(_faker.Random.Double(), _faker.Random.Double()),
            Viewport = new DotViewport(_faker.Random.Int(), _faker.Random.Int())
        };

        var targetAttributes = new DotGraphCanvasAttributes(new DotAttributeCollection());
        targetAttributes.Set(sourceAttributes);

        AssertAttributesNonNullAndEqual(sourceAttributes, targetAttributes);
    }
}