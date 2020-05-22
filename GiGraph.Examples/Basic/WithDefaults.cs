using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using System.Drawing;

namespace GiGraph.Examples.Basic
{
    public static class WithDefaults
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            graph.NodeDefaults.Shape = DotShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled;
            graph.NodeDefaults.FillColor = Color.FromArgb(0xbb, 0x10, 0x98, 0xad);

            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;

            // add nodes
            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            graph.Nodes.Add("Decision", node =>
            {
                node.Attributes.Shape = DotShape.Diamond;
                node.Attributes.Label = "Decision point";
            });

            graph.Nodes.Add("Option1").Attributes.Label = "Option 1";
            graph.Nodes.Add("Option2").Attributes.Label = "Option 2";

            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;

            // connect nodes with edges
            graph.Edges.Add("Entry", "Decision", "Option1", "Exit");
            graph.Edges.Add("Decision", "Option2", "Exit");

            return graph;
        }
    }
}
