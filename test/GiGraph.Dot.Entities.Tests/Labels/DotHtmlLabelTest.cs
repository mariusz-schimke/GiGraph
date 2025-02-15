using System;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Html;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Labels;

public class DotHtmlLabelTest
{
    [Fact]
    public void throws_exception_on_constructor_null_value()
    {
        Assert.Throws<ArgumentNullException>(() => new DotHtmlLabel((IDotHtmlEntity) null!));
        Assert.Throws<ArgumentNullException>(() => new DotHtmlLabel((DotHtmlString) null!));
    }

    [Fact]
    public void to_string_returns_original_value_for_string()
    {
        DotHtmlString value = "<table></table>";
        DotLabel label = value;
        Assert.Equal(value, label.ToString());
    }

    [Fact]
    public void to_string_returns_html_for_html_entity()
    {
        var value = "<table></table>";

        var entity = new DotHtml(value);
        DotLabel label = entity;

        Assert.Equal(value, label.ToString());
    }
}