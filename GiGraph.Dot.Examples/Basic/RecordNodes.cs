using System;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Extensions;

namespace GiGraph.Dot.Examples.Basic
{
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
                        new DotRecordTextField("Fred", portName: "port1")
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
                   .AppendField(tf => tf.AppendLineLeftJustified("Baz"))
                   .AppendRecord(rb3 => rb3
                       .AppendFields("Garply", "Waldo")
                       .AppendField("Fred", "port1")
                    )
                   .AppendField(tf => tf.AppendLineRightJustified("Plugh"))
                )
               .AppendFields("Qux", "Quux")
            );

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                edge.Head.Port.Name = "port1";
                edge.Head.Port.CompassPoint = DotCompassPoint.NorthEast;
            });

            return graph;
        }
    }
}