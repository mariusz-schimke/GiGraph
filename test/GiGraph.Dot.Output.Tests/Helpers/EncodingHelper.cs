using System.Text;
using Xunit;

namespace GiGraph.Dot.Output.Tests.Helpers;

internal static class EncodingHelper
{
    public static bool HasBom(Stream stream)
    {
        var bom = Encoding.UTF8.GetPreamble();
        Assert.NotEmpty(bom);

        var buffer = new byte[bom.Length];
        stream.Position = 0;
        stream.ReadExactly(buffer, 0, buffer.Length);

        return buffer.SequenceEqual(bom);
    }
}