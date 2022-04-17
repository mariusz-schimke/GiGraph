using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Records;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Labels;

public class DotLabelTest
{
    [Fact]
    public void converts_string_to_text_label()
    {
        DotLabel label = "text";
        Assert.IsType<DotTextLabel>(label);

        label = (string) null;
        Assert.Null(label);
    }

    [Fact]
    public void converts_escape_string_to_text_label()
    {
        DotLabel label = (DotEscapeString) "text";
        Assert.IsType<DotTextLabel>(label);

        label = (DotEscapeString) null;
        Assert.Null(label);
    }

    [Fact]
    public void converts_record_to_record_label()
    {
        DotLabel label = new DotRecord("text");
        Assert.IsType<DotRecordLabel>(label);

        label = (DotRecord) null;
        Assert.Null(label);
    }

    [Fact]
    public void converts_html_string_to_html_label()
    {
        DotLabel label = (DotHtmlString) "<table></table>";
        Assert.IsType<DotHtmlLabel>(label);

        label = (DotHtmlString) null;
        Assert.Null(label);
    }

    [Fact]
    public void converts_html_entity_to_html_label()
    {
        var entity = new DotHtml("<table></table>");
        DotLabel label = entity;
        Assert.IsType<DotHtmlLabel>(label);

        label = (DotHtml) null;
        Assert.Null(label);
    }

    [Fact]
    public void converts_html_entities_to_html_label()
    {
        DotLabel label = new DotHtmlEntityCollection();
        Assert.IsType<DotHtmlLabel>(label);

        label = (DotHtmlEntityCollection) null;
        Assert.Null(label);
    }
}