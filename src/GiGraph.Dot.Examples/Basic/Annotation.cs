using System.Diagnostics.Contracts;
using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Basic;

public static class Annotation
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // graph
        graph.Annotation = "graph";
        graph.Attributes.Annotation = "graph attributes";
        graph.Attributes.SetValue(a => a.Label, "Foo Graph").Annotation = "label";

        // node defaults
        graph.Nodes.Attributes.Annotation = "global node attributes";
        graph.Nodes.Shape = DotNodeShape.Rectangle;

        // nodes
        graph.Nodes.Annotation = "nodes";
        graph.Nodes.Add("foo", node =>
        {
            node.Attributes.Annotation = "node attributes";
            node.Attributes.SetValue(a => a.Label, "foo").Annotation = "label";
        }).Annotation = "node comment";

        // edge defaults
        graph.Edges.Attributes.Annotation = "global edge attributes";
        graph.Edges.Head.Arrowhead = DotArrowheadShape.Curve;

        // edges
        graph.Edges.Annotation = "edges";
        graph.Edges.Add("foo", "bar", edge =>
        {
            edge.Head.Endpoint.Annotation = "head";
            edge.Tail.Endpoint.Annotation = "tail";

            edge.Attributes.Annotation = "edge attributes";
            edge.Style.Attributes.SetValue(a => a.Color, Color.Red).Annotation = "color";
        }).Annotation = "edge comment";

        // subsections
        graph.Subsections.Add(sub =>
        {
            sub.Annotation = "subsection 1";

            // clusters
            sub.Clusters.Annotation = "clusters";
            sub.Clusters.Add("cluster 1").Annotation = "cluster";

            // subgraphs
            sub.Subgraphs.Annotation = "subgraphs";
            sub.Subgraphs.Add().Annotation = "subgraph";
        });

        return graph;
    }
}