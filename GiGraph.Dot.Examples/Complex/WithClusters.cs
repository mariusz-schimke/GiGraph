using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Complex
{
    public static class WithClusters
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // set graph attributes
            graph.Attributes.Label = "Example Flow";
            graph.Attributes.LayoutDirection = DotLayoutDirection.LeftToRight;
            graph.Attributes.EdgeShape = DotEdgeShape.Orthogonal;

            // set attributes for clusters
            graph.Clusters.Attributes.AllowEdgeClipping = true;

            // set individual node styles
            graph.Nodes.Add("Start").Attributes.Shape = DotNodeShape.Circle;
            graph.Nodes.Add("Decision").Attributes.Shape = DotNodeShape.Diamond;
            graph.Nodes.Add("Exit").Attributes.Shape = DotNodeShape.DoubleCircle;


            // --- define edges ---

            graph.Edges.Add("Start", "Decision");

            // (!) Note that CROSS-DIAGRAM EDGES SHOULD BE DEFINED IN THE COMMON PARENT LEVEL GRAPH/SUBGRAPH
            // (which is the root graph in this case)
            graph.Edges.Add("Decision", "Cluster 1 Start", edge =>
            {
                edge.Attributes.Label = "yes";

                // attach the arrow to cluster border
                edge.Attributes.Head.ClusterId = "Flow 1";
            });

            graph.Edges.Add("Decision", "Cluster 2 Start", edge =>
            {
                edge.Attributes.Label = "no";

                // attach the arrow to cluster border
                edge.Attributes.Head.ClusterId = "Flow 2";
            });

            graph.Edges.Add("Cluster 1 Exit", "Exit").Attributes.Tail.ClusterId = "Flow 1";
            graph.Edges.Add("Cluster 2 Exit", "Exit").Attributes.Tail.ClusterId = "Flow 2";


            // --- add clusters ---

            // (!) Note that even though clusters do not require an identifier, when you don't specify it
            // for multiple of them, or specify the same identifier for multiple clusters,
            // they will be treated as one cluster when visualized.

            graph.Clusters.Add(id: "Flow 1", cluster =>
            {
                cluster.Attributes.BackgroundColor = Color.Turquoise;
                cluster.Attributes.Label = "Flow 1";

                cluster.Edges.AddSequence("Cluster 1 Start", "Cluster 1 Node", "Cluster 1 Exit");
            });

            graph.Clusters.Add(id: "Flow 2", cluster =>
            {
                cluster.Attributes.Label = "Flow 2";
                cluster.Attributes.BackgroundColor = Color.Orange;

                cluster.Edges.AddSequence("Cluster 2 Start", "Cluster 2 Node", "Cluster 2 Exit");
            });

            return graph;
        }
    }
}