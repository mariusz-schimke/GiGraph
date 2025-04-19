using System.Text;
using GiGraph.Dot.Extensions;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public partial class DotGraphSaveTest
{
    [Fact]
    public void graph_is_saved_to_stream_complete()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);
        using var stream = new MemoryStream();
        graph.Save(stream);
        stream.Position = 0;

        var dotString = graph.ToDot();

        Assert.NotEmpty(dotString);
        Assert.Equal(dotString.Length, stream.Length);
    }

    [Fact]
    public void graph_is_saved_to_stream_with_bom()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        using var stream = new MemoryStream();
        graph.Save(stream, encoding: Encoding.UTF8);

        stream.Position = 0;
        var hasBom = HasBom(stream);
        Assert.True(hasBom);
    }

    [Fact]
    public void graph_is_saved_to_stream_without_bom()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        using var stream = new MemoryStream();
        graph.Save(stream);

        stream.Position = 0;
        var hasBom = HasBom(stream);
        Assert.False(hasBom);
    }
}