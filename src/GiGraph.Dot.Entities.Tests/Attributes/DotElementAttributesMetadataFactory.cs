using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public static class DotElementAttributesMetadataFactory
    {
        public static IEnumerable<(DotCompatibleElements Element, Dictionary<string, DotAttributePropertyMetadata> Attributes)> Create()
        {
            var result = new List<(DotCompatibleElements, Dictionary<string, DotAttributePropertyMetadata>)>
            {
                (DotCompatibleElements.Node, new DotNode("").Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Subgraph, new DotSubgraph().Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Cluster, new DotCluster("").Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Graph, new DotGraph().Attributes.GetMetadataDictionary()),
                (DotCompatibleElements.Edge, new DotEdge("").Attributes.GetMetadataDictionary())
            };

            result.Reverse();
            return result;
        }

        public static Dictionary<string, DotAttributePropertyMetadata> GetMetadataDictionary<TIEntityAttributeProperties, TEntityAttributeProperties>(
            DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> attributes, PropertyInfo rootProperty
        )
            where TEntityAttributeProperties : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
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