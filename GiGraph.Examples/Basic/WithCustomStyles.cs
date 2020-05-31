using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using System;
using System.Drawing;

namespace GiGraph.Examples.Basic
{
    public static class WithCustomStyles
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            // set left to right layout direction of the graph using graph attributes
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;


            // set the defaults for all nodes of the graph
            graph.NodeDefaults.Shape = DotShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled | DotStyle.Bold;
            graph.NodeDefaults.FillColor = Color.DarkOrange;

            // set the defaults for all edges of the graph
            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;


            // -- add nodes --

            // the Add method returns the newly added node, so you can easily access its attributes
            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            // or you can set the attributes using a delegate
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


            // -- add edges --

            // join the nodes by edges
            graph.Edges.Add("Entry", "Decision");

            // you can set custom attributes for the added edge the same way you can do it for nodes
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

            // this is a shorthand for adding two edges at once, that join multiple nodes with one node
            graph.Edges.AddManyToOne("Exit", "Option1", "Option2");

            return graph;
        }
    }
}
