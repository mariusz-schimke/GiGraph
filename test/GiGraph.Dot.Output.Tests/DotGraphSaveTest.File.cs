using System.Text;
using GiGraph.Dot.Extensions;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public partial class DotGraphSaveTest
{
    [Fact]
    public void graph_is_saved_to_file_complete()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        graph.Save(_tempFilePath);

        var dotString = graph.ToDot();
        using var stream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read);

        Assert.NotEmpty(dotString);
        Assert.Equal(dotString.Length, stream.Length);
    }

    [Fact]
    public void graph_is_saved_to_file_without_bom()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        graph.Save(_tempFilePath);

        using var stream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read);
        var hasBom = HasBom(stream);
        Assert.False(hasBom);
    }

    [Fact]
    public void graph_is_saved_to_file_with_bom()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        graph.Save(_tempFilePath, encoding: Encoding.UTF8);

        using var stream = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read);
        var hasBom = HasBom(stream);
        Assert.True(hasBom);
    }
}