using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Examples.Complex
{
    public static class WithCustomStyles
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // set left to right layout direction of the graph using graph attributes
            graph.Attributes.LayoutDirection = DotLayoutDirection.LeftToRight;
            graph.Attributes.Font.Name = "Helvetica";

            // set global node attributes (for all nodes of the graph)
            graph.Nodes.Attributes.Shape = DotNodeShape.Rectangle;
            graph.Nodes.Attributes.SetFilled(new DotGradientColor(Color.Turquoise, Color.RoyalBlue));
            graph.Nodes.Attributes.Font.Name = graph.Attributes.Font.Name;

            // set global edge attributes (for all edges of the graph)
            graph.Edges.Attributes.Head.Arrowhead = graph.Edges.Attributes.Tail.Arrowhead = DotArrowheadShape.Vee;
            graph.Edges.Attributes.Font.Name = graph.Attributes.Font.Name;
            graph.Edges.Attributes.Font.Size = 10;


            // -- (subgraphs are used here only to control the order the elements are visualized, and may be removed) --

            graph.Subgraphs.Add(sg =>
            {
                // a dotted edge
                sg.Edges.Add("G", "H", edge =>
                {
                    edge.Attributes.Label = "DOTTED";
                    edge.Attributes.Style.LineStyle = DotLineStyle.Dotted;
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // edges rendered as parallel splines
                sg.Edges.Add("E", "F", edge =>
                {
                    edge.Attributes.Label = "PARALLEL SPLINES";
                    edge.Attributes.Directions = DotEdgeDirections.Both;

                    // this will render two parallel splines (but more of them may be specified)
                    edge.Attributes.SetMultiline(Color.Turquoise, Color.RoyalBlue);
                });
            });

            graph.Subgraphs.Add(sg =>
            {
                // nodes with dual-color fill; fill proportions specified by the weight properties
                sg.Nodes.Add("C").Attributes.FillColor = new DotMultiColor(Color.RoyalBlue, new DotWeightedColor(Color.Turquoise, 0.25));
                sg.Nodes.Add("D").Attributes.FillColor = new DotMultiColor(new DotWeightedColor(Color.Navy, 0.25), Color.RoyalBlue);

                sg.Edges.Add("C", "D", edge =>
                {
                    edge.Attributes.Label = "MULTICOLOR SERIES";
                    edge.Attributes.Directions = DotEdgeDirections.Both;

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
                sg.Nodes.Add("STRIPED", attrs =>
                {
                    attrs.Color = Color.Transparent;

                    // set style to striped
                    attrs.SetStriped(new DotMultiColor(
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.RoyalBlue,
                        Color.Turquoise,
                        Color.Orange)
                    );
                });

                // a circular node with a wedged fill
                sg.Nodes.Add("WEDGED", attrs =>
                {
                    attrs.Shape = DotNodeShape.Circle;
                    attrs.Color = Color.Transparent;

                    // set wedged style
                    attrs.SetWedged(new DotMultiColor(
                        Color.Orange,
                        Color.RoyalBlue,
                        new DotWeightedColor(Color.Navy, 0.1),
                        Color.Turquoise)
                    );
                });

                sg.Edges.Add("STRIPED", "WEDGED");
            });

            // a subgraph example – to override global attributes for a group of nodes and/or edges
            graph.Subgraphs.Add(sg =>
            {
                sg.Nodes.Attributes.Color = Color.RoyalBlue;
                sg.Nodes.Attributes.FillColor = Color.Orange;
                sg.Nodes.Attributes.Shape = DotNodeShape.Circle;

                sg.Edges.Attributes.Color = Color.RoyalBlue;

                sg.Edges.Add("A", "B").Attributes.Label = "PLAIN COLOR";
            });

            return graph;
        }
    }
}