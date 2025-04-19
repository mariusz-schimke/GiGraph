using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Tests.Helpers;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotGraphSaveToFileTest : IDisposable
{
    private readonly string _tempFilePath = "test.gv";

    void IDisposable.Dispose()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task graph_is_saved_to_file_complete(bool useAsync)
    {
        var graph = new DotGraph();
        var dotString = graph.ToDot();

        if (useAsync)
        {
            await graph.SaveAsync(_tempFilePath);
        }
        else
        {
            graph.Save(_tempFilePath);
        }

        var dotStringFromFile = await File.ReadAllTextAsync(_tempFilePath);
        Assert.NotEmpty(dotString);
        Assert.Equal(dotString, dotStringFromFile);
    }


    [Theory]
    [InlineData(null, false, false)] // sync without BOM
    [InlineData(null, false, true)] // async without BOM
    [InlineData("utf-8", true, false)] // sync with BOM
    [InlineData("utf-8", true, true)] // async with BOM
    public async Task graph_is_saved_to_file_bom_check(string? encodingName, bool expectBom, bool useAsync)
    {
        var graph = new DotGraph();
        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        var encoding = encodingName is null
            ? null
            : Encoding.GetEncoding(encodingName);

        if (useAsync)
        {
            await graph.SaveAsync(_tempFilePath, encoding: encoding);
        }
        else
        {
            graph.Save(_tempFilePath, encoding: encoding);
        }

        await using var stream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read);
        var hasBom = EncodingHelper.HasBom(stream);
        Assert.Equal(expectBom, hasBom);
    }
}