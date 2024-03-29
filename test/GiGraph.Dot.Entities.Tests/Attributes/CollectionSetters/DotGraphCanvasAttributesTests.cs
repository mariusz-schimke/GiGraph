using System.Drawing;
using Bogus;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Orientation;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.CollectionSetters;

public class DotGraphCanvasAttributesTests : DotGraphAttributeSettersTestBase<IDotGraphCanvasAttributes, DotGraphCanvasAttributes>
{
    private readonly Faker _faker = new();

    [Fact]
    public void TestSetMethodUsingReflection()
    {
        var sourceAttributes = new DotGraphCanvasAttributes(new())
        {
            BackgroundColor = Color.FromArgb(_faker.Random.Int()),
            CenterDrawing = _faker.Random.Bool(),
            Dpi = _faker.Random.Double(),
            GradientFillAngle = _faker.Random.Int(),
            LandscapeOrientation = _faker.Random.Bool(),
            Margin = new(_faker.Random.Double(), _faker.Random.Double()),
            Orientation = _faker.PickRandom<DotOrientation>(),
            OrientationAngle = _faker.Random.Int(),
            Padding = new(_faker.Random.Double(), _faker.Random.Double()),
            Resolution = _faker.Random.Double(),
            Scaling = new DotGraphScalingAspectRatio(_faker.Random.Double()),
            Size = new(_faker.Random.Double(), _faker.Random.Double()),
            Viewport = new(_faker.Random.Int(), _faker.Random.Int())
        };

        var targetAttributes = new DotGraphCanvasAttributes(new());
        targetAttributes.Set(sourceAttributes);

        AssertAttributesNonNullAndEqual(sourceAttributes, targetAttributes);
    }
}