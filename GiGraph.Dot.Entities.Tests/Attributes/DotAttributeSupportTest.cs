using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Types.Attributes;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeSupportTest
    {
        public static IEnumerable<object[]> EntityAttributeKeyMappings =>
            new List<object[]>
            {
                new object[] { DotEntityTypes.Graph, new DotGraph().Attributes.GetKeyMapping() },
                new object[] { DotEntityTypes.Graph, new DotGraph().Clusters.Attributes.GetKeyMapping() },
                new object[] { DotEntityTypes.Cluster, new DotCluster("").Attributes.GetKeyMapping() },
                new object[] { DotEntityTypes.Subgraph, new DotSubgraph().Attributes.GetKeyMapping() },
                new object[] { DotEntityTypes.Node, new DotNode("").Attributes.GetKeyMapping() },
                new object[] { DotEntityTypes.Edge, new DotEdge("").Attributes.GetKeyMapping() }
            };

        [Theory]
        [MemberData(nameof(EntityAttributeKeyMappings))]
        public void entity_supports_correct_attribute_keys(DotEntityTypes entityType, Dictionary<string, string> entityKeyMapping)
        {
            var validKeys = GetSupportedKeysFor(entityType);

            var result = entityKeyMapping.Keys
               .Except(validKeys.Intersect(entityKeyMapping.Keys))
               .ToArray();

            if (result.Any())
            {
                throw new Exception($"Incorrect attributes supported by {entityType}: {string.Join(", ", result)}");
            }
        }

        private static string[] GetSupportedKeysFor(DotEntityTypes entityType)
        {
            return DotAttributeKeys.GetSupportMapping()
               .Where(item => item.Value.HasFlag(entityType))
               .Select(item => item.Key)
               .ToArray();
        }
    }
}