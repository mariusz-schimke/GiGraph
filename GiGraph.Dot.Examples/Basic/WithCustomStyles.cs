using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Examples.Basic
{
    public static class WithCustomStyles
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            // set left to right layout direction of the graph using graph attributes
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;
            graph.Attributes.FontName = "Helvetica";

            // set the defaults for all nodes of the graph
            graph.NodeDefaults.Shape = DotNodeShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled;
            graph.NodeDefaults.FontName = graph.Attributes.FontName;
            graph.NodeDefaults.FillColor = DotColorDefinition.Gradient(Color.Turquoise, Color.RoyalBlue);

            // set the defaults for all edges of the graph
            graph.EdgeDefaults.ArrowHead = graph.EdgeDefaults.ArrowTail = DotArrowType.Vee;
            graph.EdgeDefaults.FontName = graph.Attributes.FontName;
            graph.EdgeDefaults.FontSize = 10;


            // -- (subgraphs are used here only to control the order the elements are visualized, and may be removed) --

            graph.Subgraphs.Add(sg =>
            {
                // a dotted edge
                sg.Edges.Add("G", "H", edge =>
                {
                    edge.Attributes.Label = "DOTTED";
                    edge.Attributes.Style = DotStyle.Dotted;
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // edges rendered as parallel splines
                sg.Edges.Add("E", "F", edge =>
                {
                    edge.Attributes.Label = "PARALLEL SPLINES";
                    edge.Attributes.ArrowDirection = DotArrowDirection.Both;

                    // this will render two parallel splines (but more of them can be added by adding further colors)
                    edge.Attributes.Color = DotColorDefinition.Multi(Color.Turquoise, Color.RoyalBlue);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // nodes with a two-color fill; fill proportions specified by the weight parameter
                sg.Nodes.Add("C").Attributes.FillColor = DotColorDefinition.Double(Color.RoyalBlue, Color.Turquoise, weight2: 0.25);
                sg.Nodes.Add("D").Attributes.FillColor = DotColorDefinition.Double(Color.Navy, Color.RoyalBlue, weight1: 0.25);

                sg.Edges.Add("C", "D", edge =>
                {
                    edge.Attributes.Label = "MULTICOLOR SERIES";
                    edge.Attributes.ArrowDirection = DotArrowDirection.Both;

                    // this will render a multicolor edge, where each color may optionally have an area proportion determined by the weight parameter
                    edge.Attributes.Color = DotColorDefinition.Multi(
                        new DotWeightedColor(Color.Turquoise, 0.33),
                        new DotWeightedColor(Color.Gray, 0.33),
                        Color.Navy);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // a rectangular node with a striped fill
                sg.Nodes.Add("STRIPED", attrs =>
                {
                    // set style to striped
                    attrs.Style = DotStyle.Filled | DotStyle.Striped;

                    attrs.Color = Color.Transparent;

                    // set the colors of individual stripes and their proportions
                    attrs.FillColor = DotColorDefinition.Multi(
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.RoyalBlue,
                        Color.Turquoise,
                        Color.Orange);
                });

                // a circular node with a wedged fill
                sg.Nodes.Add("WEDGED", attrs =>
                {
                    attrs.Shape = DotNodeShape.Circle;

                    // set wedged style
                    attrs.Style = DotStyle.Filled | DotStyle.Wedged;

                    attrs.Color = Color.Transparent;

                    // set the colors of individual wedges and their proportions
                    attrs.FillColor = DotColorDefinition.Multi(
                        Color.Orange,
                        Color.RoyalBlue,
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.Turquoise);
                });

                sg.Edges.Add("STRIPED", "WEDGED");
            });

            // a subgraph example – to override the default attributes for a group of nodes and/or edges
            graph.Subgraphs.Add(sg =>
            {
                sg.NodeDefaults.Color = Color.RoyalBlue;
                sg.NodeDefaults.FillColor = Color.Orange;
                sg.NodeDefaults.Shape = DotNodeShape.Circle;

                sg.EdgeDefaults.Color = Color.RoyalBlue;

                sg.Edges.Add("A", "B").Attributes.Label = "PLAIN COLOR";
            });

            return graph;
        }
    }
}