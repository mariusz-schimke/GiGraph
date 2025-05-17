using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Records;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Nodes;

public class DotNodeRoundedRecordExtensionTest
{
    [Fact]
    public void converts_node_to_rounded_record_node()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetRoundedRecordAsLabel(new DotRecord("field1", "field2"));

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_rounded_record_node"
        );
    }

    [Fact]
    public void converts_node_to_rounded_record_node_from_builder()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node1").SetRoundedRecordAsLabel(b => b.AppendFields("field1", "field2"));

        Snapshot.Match(
            graph.ToDot(),
            "graph_with_rounded_record_node_from_builder"
        );
    }
}