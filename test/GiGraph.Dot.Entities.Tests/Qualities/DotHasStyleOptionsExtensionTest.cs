using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasStyleOptionsExtensionTest
{
    [Fact]
    public void extension_methods_work_on_html_table()
    {
        var table = new DotHtmlTable();
        TestExtensionMethods<DotHtmlTableStyleAttributes, DotHtmlTableStyles>(table.Style);
    }

    [Fact]
    public void extension_methods_work_on_html_table_cell()
    {
        var cell = new DotHtmlTableCell();
        TestExtensionMethods<DotHtmlTableCellStyleAttributes, DotHtmlTableStyles>(cell.Style);
    }

    [Fact]
    public void extension_methods_work_on_graph()
    {
        var graph = new DotGraph();
        TestExtensionMethods<DotGraphStyleAttributes, DotStyles>(graph.Style);
        TestExtensionMethods<DotGraphClustersStyleAttributes, DotStyles>(graph.Clusters.Style);
    }

    [Fact]
    public void extension_methods_work_on_cluster()
    {
        var cluster = new DotCluster("");
        TestExtensionMethods<DotClusterStyleAttributes, DotStyles>(cluster.Style);
    }

    [Fact]
    public void extension_methods_work_on_node()
    {
        var node = new DotNode("");
        TestExtensionMethods<DotNodeStyleAttributes, DotStyles>(node.Style);
    }

    [Fact]
    public void extension_methods_work_on_edge()
    {
        var edge = new DotEdge("");
        TestExtensionMethods<DotEdgeStyleAttributes, DotStyles>(edge.Style);
    }

    private void TestExtensionMethods<TEntity, TStyles>(TEntity entity)
        where TEntity : IDotHasStyleOptions<TStyles>
        where TStyles : struct, Enum
    {
        entity.Style = null;
        Assert.False(entity.HasStyleOptions());

        entity.Style = default(TStyles);
        Assert.True(entity.HasStyleOptions());

        entity.NullifyStyle();
        Assert.False(entity.HasStyleOptions());
    }
}