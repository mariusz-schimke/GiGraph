﻿using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Complex
{
    public static class WithSubsections
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // the root section
            graph.Annotation = "the example graph (the root section)";

            graph.NodeDefaults.Annotation = "set default node color and style";
            graph.NodeDefaults.Color = Color.Orange;
            graph.NodeDefaults.Style = DotStyles.Filled;

            graph.Edges.Add("foo", "bar");

            // the subsections
            graph.Subsections.Add(subsection =>
            {
                subsection.Annotation = "subsection 1 - override node color";
                subsection.NodeDefaults.Color = Color.Turquoise;
                subsection.Edges.Add("baz", "qux");
            });

            graph.Subsections.Add(subsection =>
            {
                subsection.Annotation = "subsection 2 - set default edge style";
                subsection.EdgeDefaults.Style = DotStyles.Dashed;
                subsection.Edges.Add("quux", "fred");
            });

            return graph;
        }
    }
}