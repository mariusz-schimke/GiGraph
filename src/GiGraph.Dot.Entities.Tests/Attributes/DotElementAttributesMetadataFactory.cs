using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public static class DotElementAttributesMetadataFactory
    {
        public static IEnumerable<(DotCompatibleElements Element, Dictionary<string, DotAttributePropertyMetadata> Attributes)> Create(bool distinguishGraphClusterAndGraphSubgraph = false)
        {
            var graphMetadata = new DotGraph().Attributes.GetMetadataDictionary();
            var graphClusterMetadata = new DotGraph().Clusters.Attributes.GetMetadataDictionary();

            var result = new List<(DotCompatibleElements, Dictionary<string, DotAttributePropertyMetadata>)>
            {
                (DotCompatibleElements.Edge, new DotEdge("").Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Node, new DotNode("").Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Subgraph, new DotSubgraph().Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Cluster, new DotCluster("").Attributes.GetMetadataDictionary())
            };

            if (distinguishGraphClusterAndGraphSubgraph)
            {
                result.Add((DotCompatibleElements.Graph, graphMetadata));
                result.Add((DotCompatibleElements.Graph | DotCompatibleElements.Cluster, graphClusterMetadata));
            }
            else
            {
                result.Add((
                    DotCompatibleElements.Graph,
                    graphMetadata
                       .Concat(graphClusterMetadata)
                       .ToDictionary(
                            key => key.Key,
                            element => element.Value
                        )
                ));
            }

            result.Reverse();
            return result;
        }
    }
}