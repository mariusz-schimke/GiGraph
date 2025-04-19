using GiGraph.Dot.Extensions;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public partial class DotGraphSaveTest
{
    [Fact]
    public void graph_is_saved_to_text_writer_without_flush()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var dotString = graph.ToDot();
        Assert.NotEmpty(dotString);

        using var stream = new MemoryStream();
        using var writer = CreateStreamWriter(stream, null, dotString.Length);
        graph.Save(writer);

        // this indicates no flush operation was called
        Assert.Equal(0, stream.Length);

        writer.Flush();
        Assert.Equal(dotString.Length, stream.Length);
    }
}