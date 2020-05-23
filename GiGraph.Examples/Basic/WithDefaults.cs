using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using System;
using System.Drawing;

namespace GiGraph.Examples.Basic
{
    public static class WithDefaults
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            // set left to right layout direction of the graph
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;


            // set the defaults for all nodes
            graph.NodeDefaults.Shape = DotShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled;
            graph.NodeDefaults.FillColor = Color.FromArgb(0xbb, 0x10, 0x98, 0xad);

            // set the defaults for all edges
            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;


            // -- add some nodes --

            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            graph.Nodes.Add("Decision", node =>
            {
                node.Attributes.Shape = DotShape.Diamond;
                node.Attributes.Label = $"Decision{Environment.NewLine}point";
            });

            graph.Nodes.Add("Option1").Attributes.Label = "Option 1";
            graph.Nodes.Add("Option2").Attributes.Label = "Option 2";

            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;


            // join the nodes together with edges
            graph.Edges.Add("Entry", "Decision");

            graph.Edges.Add("Decision", "Option1").Attributes.Label = "true";
            graph.Edges.Add("Decision", "Option2").Attributes.Label = "false";

            graph.Edges.AddManyToOne("Exit", "Option1", "Option2");


            return graph;
        }
    }
}
