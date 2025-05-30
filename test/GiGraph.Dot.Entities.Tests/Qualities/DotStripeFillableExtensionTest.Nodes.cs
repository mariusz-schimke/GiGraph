using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotStripeFillableExtensionTest
{
    [Fact]
    public void sets_striped_fill_on_individual_nodes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1").Style.SetStripedFill(Color.Red, Color.Blue);
        graph.Nodes.Add("node2").Style.SetStripedFill(new DotMulticolor(Color.Red, Color.Blue));

        Snapshot.Match(graph.ToDot(), "striped_fill_on_individual_nodes");
    }

    [Fact]
    public void sets_striped_fill_on_individual_node_groups()
    {
        var graph = new DotGraph();

        graph.Nodes.AddGroup(["node1", "node2"]).Style.SetStripedFill(Color.Red, Color.Blue);
        graph.Nodes.AddGroup(["node3", "node4"]).Style.SetStripedFill(new DotMulticolor(Color.Red, Color.Blue));

        Snapshot.Match(graph.ToDot(), "striped_fill_on_individual_node_groups");
    }

    [Fact]
    public void sets_striped_fill_on_node_collection()
    {
        var graph = new DotGraph();
        graph.Nodes.Style.SetStripedFill(Color.Red, Color.Blue);
        Snapshot.Match(graph.ToDot(), "striped_fill_on_node_collection_params");

        graph = new DotGraph();
        graph.Nodes.Style.SetStripedFill(new DotMulticolor(Color.Red, Color.Blue));
        Snapshot.Match(graph.ToDot(), "striped_fill_on_node_collection_multicolor");
    }
}