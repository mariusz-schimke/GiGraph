using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Complex;

public static class WithClusters
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // set graph attributes
        graph.Label = "Example Flow";
        graph.Layout.Direction = DotLayoutDirection.LeftToRight;
        graph.EdgeShape = DotEdgeShape.Orthogonal;

        // set attributes for clusters
        graph.Clusters.EnableEdgeClipping = true;

        // set individual node styles
        graph.Nodes.Add("Start").Shape = DotNodeShape.Circle;
        graph.Nodes.Add("Decision").Shape = DotNodeShape.Diamond;
        graph.Nodes.Add("Exit").Shape = DotNodeShape.DoubleCircle;


        // --- define edges ---

        graph.Edges.Add("Start", "Decision");

        // (!) Note that CROSS-DIAGRAM EDGES SHOULD BE DEFINED IN THE COMMON PARENT LEVEL GRAPH/SUBGRAPH
        // (which is the root graph in this case)
        graph.Edges.Add("Decision", "Cluster 1 Start", edge =>
        {
            edge.Label = "yes";

            // attach the arrow to cluster border
            edge.Head.ClusterId = "Flow 1";
        });

        graph.Edges.Add("Decision", "Cluster 2 Start", edge =>
        {
            edge.Label = "no";

            // attach the arrow to cluster border
            edge.Head.ClusterId = "Flow 2";
        });

        graph.Edges.Add("Cluster 1 Exit", "Exit").Tail.ClusterId = "Flow 1";
        graph.Edges.Add("Cluster 2 Exit", "Exit").Tail.ClusterId = "Flow 2";


        // --- add clusters ---

        // (!) Note that even though clusters do not require an identifier, when you don't specify it
        // for multiple of them, or specify the same identifier for multiple clusters,
        // they will be treated as one cluster when visualized.

        graph.Clusters.Add(id: "Flow 1", cluster =>
        {
            cluster.BackgroundColor = Color.Turquoise;
            cluster.Label = "Flow 1";

            cluster.Edges.AddSequence("Cluster 1 Start", "Cluster 1 Node", "Cluster 1 Exit");
        });

        graph.Clusters.Add(id: "Flow 2", cluster =>
        {
            cluster.Label = "Flow 2";
            cluster.BackgroundColor = Color.Orange;

            cluster.Edges.AddSequence("Cluster 2 Start", "Cluster 2 Node", "Cluster 2 Exit");
        });

        return graph;
    }
}