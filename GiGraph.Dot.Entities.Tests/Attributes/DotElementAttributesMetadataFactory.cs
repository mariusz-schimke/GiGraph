using System.Collections.Generic;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public static class DotElementAttributesMetadataFactory
    {
        public static IEnumerable<(DotElementSupport Element, Dictionary<string, DotAttributePropertyMetadata> Attributes)> Create(bool distinguishGraphCluster = false)
        {
            return new List<(DotElementSupport, Dictionary<string, DotAttributePropertyMetadata>)>
            {
                (DotElementSupport.Graph, new DotGraph().Attributes.GetMetadataDictionary()),
                (
                    distinguishGraphCluster ? DotElementSupport.Graph | DotElementSupport.Cluster : DotElementSupport.Graph,
                    new DotGraph().Clusters.Attributes.GetMetadataDictionary()
                ),
                (DotElementSupport.Cluster, new DotCluster("").Attributes.GetMetadataDictionary()),
                (DotElementSupport.Subgraph, new DotSubgraph().Attributes.GetMetadataDictionary()),
                (DotElementSupport.Node, new DotNode("").Attributes.GetMetadataDictionary()),
                (DotElementSupport.Edge, new DotEdge("").Attributes.GetMetadataDictionary())
            };
        }
    }
}