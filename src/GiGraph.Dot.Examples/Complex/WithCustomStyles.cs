using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Examples.Complex
{
    public static class WithCustomStyles
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // set left to right layout direction of the graph using graph attributes
            graph.Layout.Direction = DotLayoutDirection.LeftToRight;
            graph.Font.Name = "Helvetica";

            // set global node attributes (for all nodes of the graph)
            graph.Nodes.Shape = DotNodeShape.Rectangle;
            graph.Nodes.SetGradientFill(new DotGradientColor(Color.Turquoise, Color.RoyalBlue));
            graph.Nodes.Font.Name = graph.Font.Name;

            // set global edge attributes (for all edges of the graph)
            graph.Edges.Head.Arrowhead = graph.Edges.Tail.Arrowhead = DotArrowheadShape.Vee;
            graph.Edges.Font.Set(graph.Font.Name, 10);


            // -- (subgraphs are used here only to control the order the elements are visualized, and may be removed) --

            graph.Subgraphs.Add(sg =>
            {
                // a dotted edge
                sg.Edges.Add("G", "H", edge =>
                {
                    edge.Label = "DOTTED";
                    edge.Style.LineStyle = DotLineStyle.Dotted;
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // edges rendered as parallel splines
                sg.Edges.Add("E", "F", edge =>
                {
                    edge.Label = "PARALLEL SPLINES";
                    edge.Directions = DotEdgeDirections.Both;

                    // this will render two parallel splines (but more of them may be specified)
                    edge.Attributes.SetMultiline(Color.Turquoise, Color.RoyalBlue);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // nodes with dual-color fill; fill proportions specified by the weight properties
                sg.Nodes.Add("C").FillColor = new DotMultiColor(Color.RoyalBlue, new DotWeightedColor(Color.Turquoise, 0.25));
                sg.Nodes.Add("D").FillColor = new DotMultiColor(new DotWeightedColor(Color.Navy, 0.25), Color.RoyalBlue);

                sg.Edges.Add("C", "D", edge =>
                {
                    edge.Label = "MULTICOLOR SERIES";
                    edge.Directions = DotEdgeDirections.Both;

                    // this will render a multicolor edge, where each color may optionally have an area proportion determined by the weight parameter
                    edge.Attributes.SetSegmented(
                        new DotWeightedColor(Color.Turquoise, 0.33),
                        new DotWeightedColor(Color.Gray, 0.33),
                        Color.Navy);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // a rectangular node with a striped fill
                sg.Nodes.Add("STRIPED", node =>
                {
                    node.Color = Color.Transparent;

                    // set style to striped
                    node.SetStripedFill(
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.RoyalBlue,
                        Color.Turquoise,
                        Color.Orange);
                });

                // a circular node with a wedged fill
                sg.Nodes.Add("WEDGED", node =>
                {
                    node.Shape = DotNodeShape.Circle;
                    node.Color = Color.Transparent;

                    // set wedged style
                    node.SetWedgedFill(
                        Color.Orange,
                        Color.RoyalBlue,
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.Turquoise);
                });

                sg.Edges.Add("STRIPED", "WEDGED");
            });

            // a subgraph example – to override global attributes for a group of nodes and/or edges
            graph.Subgraphs.Add(sg =>
            {
                sg.Nodes.Color = Color.RoyalBlue;
                sg.Nodes.FillColor = Color.Orange;
                sg.Nodes.Shape = DotNodeShape.Circle;

                sg.Edges.Color = Color.RoyalBlue;

                sg.Edges.Add("A", "B").Label = "PLAIN COLOR";
            });

            return graph;
        }
    }
}