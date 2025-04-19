using System.Text;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public partial class DotGraphSaveTest : IDisposable
{
    private readonly string _tempFilePath = "test.gv";

    void IDisposable.Dispose()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }

    private static bool HasBom(Stream stream)
    {
        var bom = Encoding.UTF8.GetPreamble();
        Assert.NotEmpty(bom);

        var buffer = new byte[bom.Length];
        stream.ReadExactly(buffer, 0, buffer.Length);

        return buffer.SequenceEqual(bom);
    }

    private static StreamWriter CreateStreamWriter(Stream stream, Encoding? encoding, int? bufferSize = null)
    {
        // this is for compatibility with .NET Standard where encoding has to be specified if you want to set leaveOpen
        encoding ??= new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        return new StreamWriter(stream, encoding, bufferSize: bufferSize ?? -1, leaveOpen: true);
    }
}