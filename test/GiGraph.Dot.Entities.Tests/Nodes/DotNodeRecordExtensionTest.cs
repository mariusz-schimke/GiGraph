using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Records;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Nodes;

public class DotNodeRecordExtensionTest
{
    [Fact]
    public void converts_node_to_record_node()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetRecordAsLabel(new DotRecord("field1", "field2"));

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_record_node"
        );
    }

    [Fact]
    public void converts_node_to_record_node_from_builder()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetRecordAsLabel(b => b.AppendFields("field1", "field2"));

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_record_node_from_builder"
        );
    }
}