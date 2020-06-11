using System.Drawing;
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

            // just to change the order the elements are visualized
            graph.Nodes.Add("h", "g", "f", "e", "d", "c", "b", "a");


            // -- add nodes --

            // add nodes with a two-color fill, and fill proportions specified by the weight parameter
            graph.Nodes.Add("a").Attributes.FillColor = DotColorDefinition.From(Color.RoyalBlue, Color.Turquoise, weight2: 0.25);
            graph.Nodes.Add("b").Attributes.FillColor = DotColorDefinition.From(Color.Navy, Color.RoyalBlue, weight1: 0.25);

            // a rectangular node with a striped fill
            graph.Nodes.Add("striped", attrs =>
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
            graph.Nodes.Add("wedged", attrs =>
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


            // a subgraph example – to override the default attributes for a group of nodes and/or edges
            graph.Subgraphs.Add(sg =>
            {
                sg.NodeDefaults.Color = Color.RoyalBlue;
                sg.NodeDefaults.FillColor = Color.Orange;
                sg.NodeDefaults.Shape = DotShape.Circle;

                sg.EdgeDefaults.Color = Color.RoyalBlue;

                sg.Edges.Add("g", "h").Attributes.Label = "plain color";
            });


            // -- add edges --

            graph.Edges.Add("a", "b", attrs =>
            {
                attrs.Label = "multicolor series";
                attrs.ArrowDirection = DotArrowDirection.Both;

                // this will render a multicolor edge, where each color may optionally have a proportion specified by the weight parameter
                attrs.Color = DotColorDefinition.From(
                    new DotWeightedColor(Color.Turquoise, 0.33),
                    new DotWeightedColor(Color.Gray, 0.33),
                    Color.Navy);
            });
            
            graph.Edges.Add("c", "d", attrs =>
            {
                attrs.Label = "parallel splines";
                attrs.ArrowDirection = DotArrowDirection.Both;

                // this will render two parallel splines (but more of them can be added by adding further colors)
                attrs.Color = DotColorDefinition.From(Color.Turquoise, Color.RoyalBlue);
            });

            // a dotted edge
            graph.Edges.Add("e", "f", attrs =>
            {
                attrs.Label = "dotted";
                attrs.Style = DotStyle.Dotted;
            });

            graph.Edges.Add("striped", "wedged");

            return graph;
        }
    }
}