﻿using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Colors;

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
            graph.NodeDefaults.Style = DotStyle.Filled;
            graph.NodeDefaults.FillColor = DotColorDefinition.From(Color.Turquoise, Color.RoyalBlue);

            // set the defaults for all edges of the graph
            graph.EdgeDefaults.ArrowHead
                = graph.EdgeDefaults.ArrowTail
                    = DotArrowType.Vee;


            // -- (subgraphs are used here only to control the order in which elements are visualized) --

            graph.Subgraphs.Add(sg =>
            {
                // a dotted edge
                sg.Edges.Add("G", "H", attrs =>
                {
                    attrs.Label = "dotted";
                    attrs.Style = DotStyle.Dotted;
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // edges rendered as parallel splines
                sg.Edges.Add("E", "F", attrs =>
                {
                    attrs.Label = "parallel splines";
                    attrs.ArrowDirection = DotArrowDirection.Both;

                    // this will render two parallel splines (but more of them can be added by adding further colors)
                    attrs.Color = DotColorDefinition.From(Color.Turquoise, Color.RoyalBlue);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // nodes with a two-color fill; fill proportions specified by the weight parameter
                sg.Nodes.Add("C").Attributes.FillColor = DotColorDefinition.From(Color.RoyalBlue, Color.Turquoise, weight2: 0.25);
                sg.Nodes.Add("D").Attributes.FillColor = DotColorDefinition.From(Color.Navy, Color.RoyalBlue, weight1: 0.25);

                sg.Edges.Add("C", "D", attrs =>
                {
                    attrs.Label = "multicolor series";
                    attrs.ArrowDirection = DotArrowDirection.Both;

                    // this will render a multicolor edge, where each color may optionally have a proportion specified by the weight parameter
                    attrs.Color = DotColorDefinition.From(
                        new DotWeightedColor(Color.Turquoise, 0.33),
                        new DotWeightedColor(Color.Gray, 0.33),
                        Color.Navy);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // a rectangular node with a striped fill
                sg.Nodes.Add("Striped", attrs =>
                {
                    // set style to striped
                    attrs.Style = DotStyle.Filled | DotStyle.Striped;

                    attrs.Color = Color.Transparent;

                    // set the colors of individual stripes and their proportions
                    attrs.FillColor = DotColorDefinition.From(
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.RoyalBlue,
                        Color.Turquoise,
                        Color.Orange);
                });

                // a circular node with a wedged fill
                sg.Nodes.Add("Wedged", attrs =>
                {
                    attrs.Shape = DotShape.Circle;

                    // set wedged style
                    attrs.Style = DotStyle.Filled | DotStyle.Wedged;

                    attrs.Color = Color.Transparent;

                    // set the colors of individual wedges and their proportions
                    attrs.FillColor = DotColorDefinition.From(
                        Color.Orange,
                        Color.RoyalBlue,
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.Turquoise);
                });

                sg.Edges.Add("Striped", "Wedged");
            });

            // a subgraph example – to override the default attributes for a group of nodes and/or edges
            graph.Subgraphs.Add(sg =>
            {
                sg.NodeDefaults.Color = Color.RoyalBlue;
                sg.NodeDefaults.FillColor = Color.Orange;
                sg.NodeDefaults.Shape = DotShape.Circle;

                sg.EdgeDefaults.Color = Color.RoyalBlue;

                sg.Edges.Add("A", "B").Attributes.Label = "plain color";
            });

            return graph;
        }
    }
}