using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Basic
{
    public static class ElementAnnotation
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // graph
            graph.Annotation = "graph";
            graph.Attributes.Annotation = "graph attributes";
            graph.Attributes.Set(a => a.Label, "Foo Graph").Annotation = "label";

            // node defaults
            graph.NodeDefaults.Annotation = "global node attributes";
            graph.NodeDefaults.Shape = DotNodeShape.Rectangle;
            
            // nodes
            graph.Nodes.Annotation = "nodes";
            graph.Nodes.Add("foo", attrs =>
            {
                attrs.Annotation = "node attributes";
                attrs.Set(a => a.Label, "foo").Annotation = "label";
            }).Annotation = "node comment";

            // edge defaults
            graph.EdgeDefaults.Annotation = "global edge attributes";
            graph.EdgeDefaults.ArrowHead = DotArrowheadShape.Curve;
            
            // edges
            graph.Edges.Annotation = "edges";
            graph.Edges.Add("foo", "bar",edge =>
            {
                edge.Head.Annotation = "head";
                edge.Tail.Annotation = "tail";
                
                edge.Attributes.Annotation = "edge attributes";
                edge.Attributes.Set(a => a.Color, Color.Red).Annotation = "color";
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
}