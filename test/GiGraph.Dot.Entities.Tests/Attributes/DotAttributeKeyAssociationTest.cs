using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Tests.Attributes.Helpers;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;
using GiGraph.Dot.Types.Edges.Layout;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs.Canvas;
using GiGraph.Dot.Types.Graphs.Canvas.Scaling;
using GiGraph.Dot.Types.Graphs.Canvas.Viewport;
using GiGraph.Dot.Types.Graphs.Layout;
using GiGraph.Dot.Types.Graphs.Layout.Packing;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Images;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

/// <summary>
///     This test class is used to check if attribute keys are correctly associated with the properties of all DOT entities since
///     properties are auto-generated, and the implementations have to use the correct keys provided by annotations.
/// </summary>
public class DotAttributeKeyAssociationTest
{
    private static readonly IDictionary<Type, object> PropertyTypeValues = new Dictionary<Type, object>
    {
        { typeof(bool), true },
        { typeof(double), 123.0 },
        { typeof(int), 1234 },
        { typeof(string), "text" },
        { typeof(DotAlignment), DotAlignment.BottomCenter },
        { typeof(DotClusterVisualizationMode), DotClusterVisualizationMode.Bounded },
        { typeof(DotEdgeDirections), DotEdgeDirections.Backward },
        { typeof(DotEdgeOrderingMode), DotEdgeOrderingMode.OutgoingEdges },
        { typeof(DotEdgeShape), DotEdgeShape.Polyline },
        { typeof(DotFontConvention), DotFontConvention.Fontconfig },
        { typeof(DotHorizontalAlignment), DotHorizontalAlignment.Center },
        { typeof(DotImageScaling), DotImageScaling.Uniform },
        { typeof(DotLayoutDirection), DotLayoutDirection.LeftToRight },
        { typeof(DotNodeShape), DotNodeShape.Box },
        { typeof(DotSizing), DotSizing.Auto },
        { typeof(DotOrientation), DotOrientation.Landscape },
        { typeof(DotOutputOrder), DotOutputOrder.EdgesFirst },
        { typeof(DotRank), DotRank.Same },
        { typeof(DotStyles), (DotStyles) 0xff },
        { typeof(DotVerticalAlignment), DotVerticalAlignment.Bottom },
        { typeof(DotArrowheadDefinition), new DotArrowhead(DotArrowheadShape.Dot) },
        { typeof(DotClusterId), new DotClusterId("cluster_id") },
        { typeof(DotColor), new DotColor(Color.Red) },
        { typeof(DotColorDefinition), new DotWeightedColor(Color.Red, 1, DotColorSchemes.Default) },
        { typeof(DotEndpointPort), new DotEndpointPort("port1", DotCompassPoint.East) },
        { typeof(DotEscapeString), (DotEscapeString) "escape" },
        { typeof(DotGraphScalingDefinition), new DotGraphScalingMode(DotGraphScaling.Auto) },
        { typeof(DotId), new DotId("id") },
        { typeof(DotLabel), new DotTextLabel("text") },
        { typeof(DotPackingDefinition), new DotPackingMargin(12) },
        { typeof(DotPackingModeDefinition), new DotArrayPackingMode(DotArrayPackingOptions.AlignBottom) },
        { typeof(DotPoint), new DotPoint(1, 2) },
        { typeof(DotRankSeparationDefinition), new DotRadialRankSeparation(1) },
        { typeof(DotViewport), new DotViewport(1, 2, 3) }
    };

    [Fact]
    public void graph_elements_have_correct_attribute_keys_on_properties()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("cluster1");
        var subgraph = graph.Subgraphs.Add("subgraph1");
        var node = graph.Nodes.Add("node1");
        var edge = graph.Edges.Add("node1", "node2");

        SetAllElementAttributesWithChecks(graph.Attributes, graph.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributesWithChecks(cluster.Attributes, cluster.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributesWithChecks(subgraph.Attributes, subgraph.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributesWithChecks(node.Attributes, node.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributesWithChecks(edge.Attributes, edge.Attributes.GetMetadataDictionary().Values.ToArray());

        var formatOptions = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineAttributeLists = false },
            Nodes = { SingleLineAttributeLists = false },
            Edges = { SingleLineAttributeLists = false }
        };

        var syntaxOptions = new DotSyntaxOptions
        {
            Attributes = { PreferExplicitSeparator = false },
            SortElements = true
        };

        Snapshot.Match(graph.ToDot(formatOptions, syntaxOptions), "graph_with_all_attributes_on_all_elements");
    }

    private static void SetAllElementAttributesWithChecks(IDotEntityAttributesAccessor targetRootObject, DotAttributePropertyMetadata[] attributes)
    {
        var propertyTree = DotPropertyTreeFactory.GetFlattenedPropertyTreeByMetadata(targetRootObject, attributes);

        foreach (var propertySubtree in propertyTree)
        {
            foreach (var property in propertySubtree)
            {
                SetPropertyValueWithCheck(propertySubtree.Key, property);
            }
        }
    }

    private static void SetPropertyValueWithCheck(DotEntityAttributes targetObject, PropertyInfo targetProperty)
    {
        var propertyType = TypeHelper.Unwrap(targetProperty.PropertyType);
        if (!PropertyTypeValues.TryGetValue(propertyType, out var value))
        {
            throw new Exception($"No test property value has been specified for type {propertyType.Name}.");
        }

        // make sure the attribute does not exist before setting the value
        var attributeKey = ((IDotEntityAttributes) targetObject).Accessor.GetPropertyKey(targetProperty);
        var containsAttribute = targetObject.Collection.ContainsKey(attributeKey);
        Assert.False(containsAttribute);

        // set the value
        targetProperty.SetValue(targetObject, value);

        // make sure the attribute does exist after setting the value (this also proves that the key specified
        // on the property accessor is the same as the one used by the getting and setting methods)
        var attribute = targetObject.Collection.Get(attributeKey);
        Assert.NotNull(attribute);
        Assert.True(attribute.HasValue);

        // make sure the getter uses the same key as the setter by comparing the values
        // (this is necessary to check the auto-generated code)
        var actualValue = targetProperty.GetValue(targetObject);
        if (targetProperty.PropertyType.IsValueType)
        {
            Assert.Equal(value, actualValue);
            Assert.Equal(value, attribute.GetValue());
        }
        else
        {
            Assert.Same(value, actualValue);
            Assert.Same(value, attribute.GetValue());
        }
    }
}