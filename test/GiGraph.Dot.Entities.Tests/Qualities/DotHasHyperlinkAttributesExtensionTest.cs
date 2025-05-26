using Bogus;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Hyperlinks;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasHyperlinkAttributesExtensionTest
{
    [Fact]
    public void table_hyperlink_setter_with_params_sets_all_properties()
    {
        var table = new DotHtmlTable();
        TestExtensionMethodsOfHasHyperlink(table.Hyperlink);
        TestExtensionMethodsOfHasHyperlinkWithTooltip(table.Hyperlink);
    }

    [Fact]
    public void table_cell_hyperlink_setter_with_params_sets_all_properties()
    {
        var cell = new DotHtmlTableCell();
        TestExtensionMethodsOfHasHyperlink(cell.Hyperlink);
        TestExtensionMethodsOfHasHyperlinkWithTooltip(cell.Hyperlink);
    }

    [Fact]
    public void edge_hyperlink_setter_with_params_sets_all_properties()
    {
        var edge = new DotEdge("node1", "node2");
        TestExtensionMethodsOfHasHyperlink(edge.Hyperlink);
    }

    [Fact]
    public void edge_edge_hyperlink_with_params_setter_sets_all_properties()
    {
        var edge = new DotEdge("node1", "node2");
        TestExtensionMethodsOfHasHyperlink(edge.EdgeHyperlink);
        TestExtensionMethodsOfHasHyperlinkWithTooltip(edge.EdgeHyperlink);
    }

    private void TestExtensionMethodsOfHasHyperlink<T>(T entity)
        where T : IDotHasHyperlinkAttributes
    {
        var hyperlink = CreateRandomHyperlink();
        entity.Set(hyperlink.Href, hyperlink.Target);
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(hyperlink.Target, entity.Target);

        hyperlink = CreateRandomHyperlink();
        entity.SetWithNewWindowTarget(hyperlink.Href);
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(DotHyperlinkTargets.Blank, entity.Target);

        entity.Target = null;
        Assert.Null(entity.Target);
        entity.SetNewWindowTarget();
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(DotHyperlinkTargets.Blank, entity.Target);
    }

    private void TestExtensionMethodsOfHasHyperlinkWithTooltip<T>(T entity)
        where T : IDotHasHyperlinkAttributesWithTooltip
    {
        var hyperlink = CreateRandomHyperlink();
        entity.Set(hyperlink.Href, hyperlink.Target, hyperlink.Tooltip);
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(hyperlink.Target, entity.Target);
        Assert.Equal(hyperlink.Tooltip, entity.Tooltip);

        hyperlink = CreateRandomHyperlink();
        entity.Target = hyperlink.Target;
        entity.SetWithTooltip(hyperlink.Href, hyperlink.Tooltip);
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(hyperlink.Target, entity.Target);
        Assert.Equal(hyperlink.Tooltip, entity.Tooltip);

        hyperlink = CreateRandomHyperlink();
        entity.SetWithNewWindowTarget(hyperlink.Href, hyperlink.Tooltip);
        Assert.Equal(hyperlink.Href, entity.Href);
        Assert.Equal(DotHyperlinkTargets.Blank, entity.Target);
        Assert.Equal(hyperlink.Tooltip, entity.Tooltip);
    }

    private static DotHyperlink CreateRandomHyperlink()
    {
        var faker = new Faker();
        return new DotHyperlink
        {
            Href = faker.Random.Hash(),
            Url = faker.Random.Hash(),
            Target = faker.Random.Hash(),
            Tooltip = faker.Random.Hash(),
            Title = faker.Random.Hash()
        };
    }
}