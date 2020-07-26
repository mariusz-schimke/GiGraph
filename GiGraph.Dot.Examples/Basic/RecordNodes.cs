using System;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Extensions;

namespace GiGraph.Dot.Examples.Basic
{
    public static class RecordNodes
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            graph.Nodes.Add("Bar").ToRecord
            (
                $"Foo{Environment.NewLine}Bar",
                new DotRecord
                (
                    "Baz" + DotEscapeString.JustifyLeft,
                    new DotRecord
                    (
                        "Garply",
                        "Waldo",
                        new DotRecordTextField("Fred", portName: "port1")
                    ),
                    "Plugh" + DotEscapeString.JustifyRight
                ),
                "Qux",
                "Quux"
            );

            // you can achieve the same effect using a record builder
            graph.Nodes.Add("Baz").ToRecord
            (
                r1 => r1
                     .AppendField(f => f.AppendLine("Foo").Append("Bar"))
                     .AppendRecord
                      (
                          r2 => r2
                               .AppendField(f => f.AppendLeftJustifiedLine("Baz"))
                               .AppendRecord
                                (
                                    r3 => r3
                                         .AppendField("Garply")
                                         .AppendField("Waldo")
                                         .AppendField("Fred", "port1")
                                )
                               .AppendField(f => f.AppendRightJustifiedLine("Plugh"))
                      )
                     .AppendField("Qux")
                     .AppendField("Quux")
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