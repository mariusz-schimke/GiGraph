using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Types.Hyperlinks;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeHyperlinkTest
{
    [Fact]
    public void hyperlink_setter_with_record_sets_all_properties()
    {
        var edge = new DotEdge("node1", "node2");
        var hyperlink = CreateHyperlink();

        edge.Hyperlink.Set(hyperlink);

        Assert.Equal(hyperlink.Href, edge.Hyperlink.Href);
        Assert.Equal(hyperlink.Target, edge.Hyperlink.Target);
        Assert.Equal(hyperlink.Url, edge.Hyperlink.Url);
    }

    [Fact]
    public void edge_hyperlink_with_record_setter_sets_all_properties()
    {
        var edge = new DotEdge("node1", "node2");
        var hyperlink = CreateHyperlink();

        edge.EdgeHyperlink.Set(hyperlink);

        Assert.Equal(hyperlink.Href, edge.EdgeHyperlink.Href);
        Assert.Equal(hyperlink.Target, edge.EdgeHyperlink.Target);
        Assert.Equal(hyperlink.Url, edge.EdgeHyperlink.Url);
        Assert.Equal(hyperlink.Tooltip, edge.EdgeHyperlink.Tooltip);
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