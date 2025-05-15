using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Hyperlinks;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableHyperlinkTest
{
    [Fact]
    public void hyperlink_setter_with_params_sets_all_properties()
    {
        var table = new DotHtmlTable();
        var hyperlink = CreateHyperlink();

        table.Hyperlink.Set(hyperlink.Href, hyperlink.Target, hyperlink.Tooltip, hyperlink.Title);

        Assert.Equal(hyperlink.Href, table.Hyperlink.Href);
        Assert.Equal(hyperlink.Target, table.Hyperlink.Target);
        Assert.Equal(hyperlink.Tooltip, table.Hyperlink.Tooltip);
        Assert.Equal(hyperlink.Title, table.Hyperlink.Title);
    }

    [Fact]
    public void hyperlink_setter_with_record_sets_all_properties()
    {
        var table = new DotHtmlTable();
        var hyperlink = CreateHyperlink();

        table.Hyperlink.Set(hyperlink);

        Assert.Equal(hyperlink.Href, table.Hyperlink.Href);
        Assert.Equal(hyperlink.Target, table.Hyperlink.Target);
        Assert.Equal(hyperlink.Tooltip, table.Hyperlink.Tooltip);
        Assert.Equal(hyperlink.Title, table.Hyperlink.Title);
    }

    private static DotHyperlink CreateHyperlink() =>
        new()
        {
            Href = "https://examplehref.com",
            Url = "https://exampleurl.com",
            Target = "_blank",
            Tooltip = "my tooltip",
            Title = "my title"
        };
}