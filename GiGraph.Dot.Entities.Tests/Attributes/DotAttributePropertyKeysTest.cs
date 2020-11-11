using System.Collections.Generic;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributePropertyKeysTest : DotAttributeTestBase
    {
        private readonly DotSyntaxOptions _syntaxOptions = new DotSyntaxOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        // [Theory]
        // [InlineData(typeof(IDotClusterAttributes), typeof(DotClusterAttributeCollection))]
        // [InlineData(typeof(IDotEdgeAttributes), typeof(DotEdgeAttributes))]
        // [InlineData(typeof(IDotGraphAttributes), typeof(DotGraphAttributeCollection))]
        // [InlineData(typeof(IDotNodeAttributes), typeof(DotNodeAttributeCollection))]
        // [InlineData(typeof(IDotSubgraphAttributes), typeof(DotSubgraphAttributeCollection))]
        // public void all_entity_properties_have_a_non_empty_and_unique_attribute_key_assigned(Type entityAttributesInterface, Type entityAttributesImplementation)
        // {
        //     var method = GetType()
        //        .GetRuntimeMethods()
        //        .Single(m => m.Name == nameof(ensure_all_entity_properties_have_a_non_empty_and_unique_attribute_key_assigned));
        //
        //     method.MakeGenericMethod(entityAttributesImplementation, entityAttributesInterface)
        //        .Invoke(this, null);
        // }

        // private void ensure_all_entity_properties_have_a_non_empty_and_unique_attribute_key_assigned<TCollection, TIEntityAttributeProperties>()
        //     where TCollection : DotEntityAttributeCollection<TIEntityAttributeProperties>
        // {
        //     var interfaceProperties = GetEntityAttributePropertiesOf(
        //         attributeCollectionType: typeof(TCollection),
        //         entityAttributePropertiesInterfaceType: typeof(TIEntityAttributeProperties)
        //     );
        //
        //     foreach (var interfaceProperty in interfaceProperties)
        //     {
        //         var collection = Activator.CreateInstance<TCollection>();
        //
        //         // exception expected if there is no key available for the specified interface property in the internal lookup
        //         var key = collection.GetKey(interfaceProperty);
        //         Assert.NotEmpty(key);
        //
        //         // exception expected if there is no key available for a property getter or setter
        //         interfaceProperty.GetValue(collection);
        //         interfaceProperty.SetValue(collection, null);
        //     }
        // }

        [Fact]
        public void property_key_mappings_have_unique_keys_for_all_attribute_collection_types()
        {
            // it is assumed that if a key repeats, an exception will be thrown by the mapping method on dictionary creation

            var graphAttributes = new DotGraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(graphAttributes), "graph_attribute_key_map");

            var nodeAttributes = new DotNode("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(nodeAttributes), "node_attribute_key_map");

            var edgeAttributes = new DotEdge("", "").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(edgeAttributes), "edge_attribute_key_map");

            var subgraphAttributes = new DotSubgraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(subgraphAttributes), "subgraph_attribute_key_map");

            var clusterAttributes = new DotCluster("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(clusterAttributes), "cluster_attribute_key_map");
        }
    }
}