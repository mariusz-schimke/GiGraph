using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public static class DotElementAttributesMetadataFactory
    {
        public static IEnumerable<(DotCompatibleElements Element, Dictionary<string, DotAttributePropertyMetadata> Attributes)> Create()
        {
            var graph = new DotGraph();
            var edge = new DotEdge("");

            var result = new List<(DotCompatibleElements, Dictionary<string, DotAttributePropertyMetadata>)>
            {
                (DotCompatibleElements.Node, new DotNode("").Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Subgraph, new DotSubgraph().Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Cluster, new DotCluster("").Attributes.GetMetadataDictionary()),
                (
                    DotCompatibleElements.Graph,
                    graph.Attributes.GetMetadataDictionary()
                       .Concat(GetMetadataDictionary(graph.Clusters.Attributes, rootProperty: graph.GetType().GetProperty(nameof(graph.Clusters), typeof(DotGraphClusterCollection))))
                       .ToDictionary(key => key.Key, element => element.Value)
                ),
                (
                    DotCompatibleElements.Edge,
                    edge.Attributes.GetMetadataDictionary()
                       .Concat(GetMetadataDictionary(edge.Tail.Attributes, rootProperty: edge.GetType().GetProperty(nameof(edge.Tail))))
                       .Concat(GetMetadataDictionary(edge.Head.Attributes, rootProperty: edge.GetType().GetProperty(nameof(edge.Head))))
                       .ToDictionary(key => key.Key, element => element.Value)
                )
            };

            result.Reverse();
            return result;
        }

        public static Dictionary<string, DotAttributePropertyMetadata> GetMetadataDictionary<TIEntityAttributeProperties>(DotEntityAttributesWithMetadata<TIEntityAttributeProperties> attributes, PropertyInfo rootProperty)
        {
            var prefix = rootProperty is not null
                ? Enumerable.Empty<PropertyInfo>().Append(rootProperty)
                : Enumerable.Empty<PropertyInfo>();

            return attributes.GetMetadataDictionary().ToDictionary(
                k => k.Key,
                v => new DotAttributePropertyMetadata(
                    v.Key, v.Value.CompatibleElements, v.Value.CompatibleLayoutEngines, v.Value.CompatibleOutputs,
                    prefix.Concat(v.Value.GetPropertyInfoPath()).ToArray()
                )
            );
        }
    }
}