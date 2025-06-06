using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Graphs.Canvas.Viewport;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotGraphCanvasViewportAttributeTest
{
    [Fact]
    public void viewport_setter_sets_all_properties()
    {
        var canvas = new DotGraphCanvasAttributes(new DotAttributeCollection());
        canvas.SetViewport(1, 2, 3);
        Assert.Equal(1, canvas.Viewport!.Width);
        Assert.Equal(2, canvas.Viewport!.Height);
        Assert.Equal(3, canvas.Viewport!.Zoom);
    }

    [Fact]
    public void point_centered_viewport_setter_sets_all_properties()
    {
        var canvas = new DotGraphCanvasAttributes(new DotAttributeCollection());
        canvas.SetPointCenteredViewport(1, 2, 3, 4, 5);

        var viewPort = canvas.Viewport as DotPointCenteredViewport;
        Assert.NotNull(viewPort);

        Assert.Equal(1, viewPort.Width);
        Assert.Equal(2, viewPort.Height);
        Assert.Equal(3, viewPort.X);
        Assert.Equal(4, viewPort.Y);
        Assert.Equal(5, viewPort.Zoom);
    }

    [Fact]
    public void node_centered_viewport_setter_sets_all_properties()
    {
        var canvas = new DotGraphCanvasAttributes(new DotAttributeCollection());
        canvas.SetNodeCenteredViewport(1, 2, "node1", 4);

        var viewPort = canvas.Viewport as DotNodeCenteredViewport;
        Assert.NotNull(viewPort);

        Assert.Equal(1, viewPort.Width);
        Assert.Equal(2, viewPort.Height);
        Assert.Equal("node1", viewPort.NodeId);
        Assert.Equal(4, viewPort.Zoom);
    }
}