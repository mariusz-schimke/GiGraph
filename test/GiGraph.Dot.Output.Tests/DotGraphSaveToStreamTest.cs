using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Tests.EncodingHelpers;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotGraphSaveToStreamTest
{
    [Fact]
    public void graph_is_saved_to_stream_complete()
    {
        var graph = new DotGraph();
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
        var graph = new DotGraph();

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        using var stream = new MemoryStream();
        graph.Save(stream, encoding: Encoding.UTF8);

        stream.Position = 0;
        var hasBom = EncodingHelper.HasBom(stream);
        Assert.True(hasBom);
    }

    [Fact]
    public void graph_is_saved_to_stream_without_bom()
    {
        var graph = new DotGraph();

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        using var stream = new MemoryStream();
        graph.Save(stream);

        stream.Position = 0;
        var hasBom = EncodingHelper.HasBom(stream);
        Assert.False(hasBom);
    }
}