using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Tests.EncodingHelpers;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotGraphSaveToStreamTest
{
    [Theory]
    [InlineData(false)] // sync
    [InlineData(true)] // async
    public async Task graph_is_saved_to_stream_complete(bool useAsync)
    {
        var graph = new DotGraph();
        using var stream = new MemoryStream();

        if (useAsync)
        {
            await graph.SaveAsync(stream);
        }
        else
        {
            graph.Save(stream);
        }

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);
        Assert.Equal(dotString.Length, stream.Length);
    }

    [Theory]
    [InlineData(null, false, false)] // sync without BOM
    [InlineData(null, false, true)] // async without BOM
    [InlineData("utf-8", true, false)] // sync with BOM
    [InlineData("utf-8", true, true)] // async with BOM
    public async Task graph_is_saved_to_stream_bom_check(string? encodingName, bool expectBom, bool useAsync)
    {
        var graph = new DotGraph();
        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        var encoding = encodingName is null
            ? null
            : Encoding.GetEncoding(encodingName);

        using var stream = new MemoryStream();

        if (useAsync)
        {
            await graph.SaveAsync(stream, encoding: encoding);
        }
        else
        {
            graph.Save(stream, encoding: encoding);
        }

        var hasBom = EncodingHelper.HasBom(stream);
        Assert.Equal(expectBom, hasBom);
    }
}