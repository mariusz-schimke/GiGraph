using System;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Extensions;

namespace GiGraph.Dot.Examples.Basic
{
    public static class RecordNodes
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            graph.Nodes.Add("Bar").ToRecord
            (
                $"Foo{Environment.NewLine}Bar",
                new DotRecordField[]
                {
                    "Baz",
                    new DotRecord
                    (
                        "Garply",
                        "Waldo",
                        new DotRecordTextField("Fred", portName: "port1")
                    ),
                    "Plugh",
                },
                "Qux",
                "Quux");

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                edge.Head.Port.Name = "port1";
                edge.Head.Port.CompassPoint = DotCompassPoint.NorthEast;
            });

            return graph;
        }
    }
}