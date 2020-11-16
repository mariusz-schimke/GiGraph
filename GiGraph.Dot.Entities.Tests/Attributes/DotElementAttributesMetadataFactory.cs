using System.Collections.Generic;
using System.Linq;
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
            var graphMetadata = new DotGraph().Attributes.GetMetadataDictionary();
            var graphClusterMetadata = new DotGraph().Clusters.Attributes.GetMetadataDictionary();

            var result = new List<(DotElementSupport, Dictionary<string, DotAttributePropertyMetadata>)>
            {
                (DotElementSupport.Edge, new DotEdge("").Attributes.GetMetadataDictionary()),
                (DotElementSupport.Node, new DotNode("").Attributes.GetMetadataDictionary()),
                (DotElementSupport.Subgraph, new DotSubgraph().Attributes.GetMetadataDictionary()),
                (DotElementSupport.Cluster, new DotCluster("").Attributes.GetMetadataDictionary())
            };

            if (distinguishGraphCluster)
            {
                result.Add((DotElementSupport.Graph, graphMetadata));
                result.Add((DotElementSupport.Graph | DotElementSupport.Cluster, graphClusterMetadata));
            }
            else
            {
                result.Add((
                    DotElementSupport.Graph,
                    graphMetadata.Concat(graphClusterMetadata).ToDictionary(
                        key => key.Key,
                        element => element.Value)
                ));
            }

            result.Reverse();
            return result;
        }
    }
}