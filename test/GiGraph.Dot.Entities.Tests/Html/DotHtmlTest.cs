using GiGraph.Dot.Entities.Html;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html;

public class DotHtmlTest
{
    [Fact]
    public void returns_original_input_as_html()
    {
        var value = "<table><tr><td>\"Quoted content\"</td></tr></table>";
        var entity = new DotHtml(value);
        Assert.Equal(value, entity.ToHtml());
    }
}