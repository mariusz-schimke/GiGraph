using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotGraphSaveToTextWriterTest
{
    [Fact]
    public void graph_is_saved_to_text_writer_without_flush()
    {
        var graph = new DotGraph();

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

    private static StreamWriter CreateStreamWriter(Stream stream, Encoding? encoding, int? bufferSize = null)
    {
        // this is for compatibility with .NET Standard where encoding has to be specified if you want to set leaveOpen
        encoding ??= new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        return new StreamWriter(stream, encoding, bufferSize: bufferSize ?? -1, leaveOpen: true);
    }
}