using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Orientation;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Graph;

public class DotGraphCanvasAttributesTests
{
    [Fact]
    public void TestSetMethodUsingReflection()
    {
        var sourceAttributes = new DotGraphCanvasAttributes(new())
        {
            BackgroundColor = Color.Red,
            CenterDrawing = true,
            Dpi = 72.0,
            GradientFillAngle = 45,
            LandscapeOrientation = true,
            Margin = new(10, 10),
            Orientation = DotOrientation.Landscape,
            OrientationAngle = 90,
            Padding = new(5, 5),
            Resolution = 300,
            Scaling = new DotGraphScalingAspectRatio(1),
            Size = new(1920, 1080),
            Viewport = new(10, 23)
        };

        var targetAttributes = new DotGraphCanvasAttributes(new());

        targetAttributes.Set(sourceAttributes);

        var properties = typeof(IDotGraphCanvasAttributes).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var sourceValue = property.GetValue(sourceAttributes);
            var targetValue = property.GetValue(targetAttributes);

            Assert.Equal(sourceValue, targetValue);
        }
    }
}