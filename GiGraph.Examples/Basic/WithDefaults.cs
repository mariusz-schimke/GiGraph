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
            graph.NodeDefaults.Style = DotStyle.Filled | DotStyle.Bold;
            graph.NodeDefaults.FillColor = Color.DarkOrange;

            // set the defaults for all edges
            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;


            // -- add some nodes --

            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            graph.Nodes.Add("Decision", attrs =>
            {
                attrs.Shape = DotShape.Diamond;
                attrs.Label = $"Decision{Environment.NewLine}point";
            });

            graph.Nodes.Add("Option1", attrs =>
            {
                attrs.Color = Color.Green;
                attrs.Label = "Positive path";
            });

            graph.Nodes.Add("Option2", attrs =>
            {
                attrs.Color = Color.DarkRed;
                attrs.Label = "Negative path";
            });

            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;


            // join the nodes together with edges
            graph.Edges.Add("Entry", "Decision");

            graph.Edges.Add("Decision", "Option1", attrs =>
            {
                attrs.Color = Color.Green;
                attrs.Label = "yes";
            });

            graph.Edges.Add("Decision", "Option2", attrs =>
            {
                attrs.Color = Color.DarkRed;
                attrs.Label = "no";
            });

            graph.Edges.AddManyToOne("Exit", "Option1", "Option2");


            return graph;
        }
    }
}
