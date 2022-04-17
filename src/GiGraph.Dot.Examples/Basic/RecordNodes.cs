using System;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Examples.Basic;

public static class RecordNodes
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("Bar").ToRecordNode(new DotRecord(
            $"Foo{Environment.NewLine}Bar",
            new DotRecord
            (
                DotEscapeString.JustifyLeft("Baz"),
                new DotRecord
                (
                    "Garply",
                    "Waldo",
                    new DotRecordTextField("Fred", PortName: "port1")
                ),
                DotEscapeString.JustifyRight("Plugh")
            ),
            "Qux",
            "Quux"
        ));

        // you can achieve the same effect using a record builder
        graph.Nodes.Add("Baz").ToRecordNode(rb1 => rb1
           .AppendField($"Foo{Environment.NewLine}Bar")
           .AppendRecord(rb2 => rb2
               .AppendField(tf => tf.AppendLeftJustifiedLine("Baz"))
               .AppendRecord(rb3 => rb3
                   .AppendFields("Garply", "Waldo")
                   .AppendField("Fred", "port1")
                )
               .AppendField(tf => tf.AppendRightJustifiedLine("Plugh"))
            )
           .AppendFields("Qux", "Quux")
        );

        graph.Edges.Add("Foo", "Bar", edge =>
        {
            edge.Head.Endpoint.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);
        });

        return graph;
    }
}