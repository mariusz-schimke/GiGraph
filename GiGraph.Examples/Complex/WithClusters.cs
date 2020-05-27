using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using System.Drawing;

namespace GiGraph.Examples.Complex
{
    public static class WithClusters
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            graph.Attributes.Label = "Example Flow";
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;

            graph.Nodes.Add("Start").Attributes.Shape = DotShape.Circle;
            graph.Nodes.Add("Decision").Attributes.Shape = DotShape.Diamond;
            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;

            // --- define edges ---

            graph.Edges.Add("Start", "Decision");

            // (!) Note that CROSS-DIAGRAM EDGES SHOULD BE DEFINED IN THE COMMON PARENT LEVEL GRAPH/SUBGRAPH
            // (which is the root graph in this case)
            graph.Edges.Add("Decision", "Cluster 1 Start").Attributes.Label = "yes";
            graph.Edges.Add("Decision", "Cluster 2 Start").Attributes.Label = "no";

            graph.Edges.Add("Cluster 1 Exit", "Exit");
            graph.Edges.Add("Cluster 2 Exit", "Exit");


            // --- add clusters ---

            // (!) Note that clusters do not require an identifier, but when you don't specify it
            // for multiple of them, or specify the same identifier for multiple clusters,
            // they will be treated as one cluster when visualized.

            graph.Subgraphs.AddCluster(id: "Positive path", cluster =>
            {
                cluster.Attributes.BackgroundColor = Color.LightGreen;
                cluster.Attributes.Label = "Positive path";

                cluster.Edges.AddSequence("Cluster 1 Start", "Cluster 1 Node", "Cluster 1 Exit");
            });

            graph.Subgraphs.AddCluster(id: "Negative path", cluster =>
            {
                cluster.Attributes.Label = "Negative path";
                cluster.Attributes.BackgroundColor = Color.LightPink;

                cluster.Edges.AddSequence("Cluster 2 Start", "Cluster 2 Node", "Cluster 2 Exit");
            });

            return graph;
        }
    }
}
