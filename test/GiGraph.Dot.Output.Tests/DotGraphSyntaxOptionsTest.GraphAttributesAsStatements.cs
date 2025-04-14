using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public partial class DotGraphSyntaxOptionsTest
{
    [Fact]
    public void graph_attributes_are_rendered_as_statements()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = true }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_as_statements.gv");
    }

    [Fact]
    public void graph_attributes_are_rendered_as_list()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_as_list.gv");
    }

    [Fact]
    public void graph_attributes_in_cluster_are_rendered_as_statements()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Clusters = { AttributesAsStatements = true }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_in_cluster_as_statements.gv");
    }

    [Fact]
    public void graph_attributes_in_cluster_are_rendered_as_list()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Clusters = { AttributesAsStatements = false }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_in_cluster_as_list.gv");
    }

    [Fact]
    public void graph_attributes_in_subgraph_are_rendered_as_statements()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Subgraphs = { AttributesAsStatements = true }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_in_subgraph_as_statements.gv");
    }

    [Fact]
    public void graph_attributes_in_subgraph_are_rendered_as_list()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

        var options = new DotSyntaxOptions
        {
            Subgraphs = { AttributesAsStatements = false }
        };

        var dot = graph.ToDotString(syntaxOptions: options);
        Snapshot.Match(dot, "graph_attributes_in_subgraph_as_list.gv");
    }
}