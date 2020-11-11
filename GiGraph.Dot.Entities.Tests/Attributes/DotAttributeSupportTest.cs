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

        [Fact]
        public void attribute_key_is_supported_by_all_required_or_by_none()
        {
            // get all supported keys per entity type
            var entityKeys = EntityAttributeKeyMappings
               .GroupBy(
                    x => (DotEntityTypes) x[0],
                    x => ((Dictionary<string, string>) x[1]).Keys.Select(key => key).ToArray()
                )
               .ToLookup(
                    key => key.Key,
                    values => values.SelectMany(x => x).ToArray()
                );

            // for all valid keys check if any of them is supported by any entity, and if so,
            // then it must be supported by all entities that the mapping indicates 
            foreach (var attribute in DotAttributeKeys.GetSupportMapping())
            {
                var supportedByOtherEntities = false;

                foreach (var entityType in Enum.GetValues(typeof(DotEntityTypes)).Cast<DotEntityTypes>())
                {
                    if (attribute.Value.HasFlag(entityType))
                    {
                        if (entityKeys[entityType].First().Contains(attribute.Key))
                        {
                            supportedByOtherEntities = true;
                        }
                        else if (supportedByOtherEntities)
                        {
                            throw new Exception($"The '{attribute.Key}' attribute is not supported by {entityType} (expected support by: {attribute.Value})");
                        }
                    }
                }
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