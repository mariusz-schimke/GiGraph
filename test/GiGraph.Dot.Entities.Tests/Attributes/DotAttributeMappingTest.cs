using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Tests.Attributes.Helpers;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Images;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Viewport;
using Snapshooter.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotAttributeMappingTest
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
        { typeof(DotNodeSizing), DotNodeSizing.Auto },
        { typeof(DotOrientation), DotOrientation.Landscape },
        { typeof(DotRank), DotRank.Same },
        { typeof(DotStyles), (DotStyles) 0xff },
        { typeof(DotVerticalAlignment), DotVerticalAlignment.Bottom },
        { typeof(DotArrowheadDefinition), new DotArrowhead(DotArrowheadShape.Dot, DotArrowheadParts.Both) },
        { typeof(DotClusterId), new DotClusterId("cluster_id") },
        { typeof(DotColor), new DotColor(Color.Red) },
        { typeof(DotColorDefinition), new DotWeightedColor(Color.Red, 1, DotColorSchemes.Default) },
        { typeof(DotEndpointPort), new DotEndpointPort("port1", DotCompassPoint.East) },
        { typeof(DotEscapeString), (DotEscapeString) "escape" },
        { typeof(DotGraphScalingDefinition), new DotGraphScalingOption(DotGraphScaling.Auto) },
        { typeof(DotId), new DotId("id") },
        { typeof(DotLabel), new DotTextLabel("text") },
        { typeof(DotPackingDefinition), new DotPackingMargin(12) },
        { typeof(DotPackingModeDefinition), new DotArrayPackingMode(DotArrayPackingOptions.AlignBottom) },
        { typeof(DotPoint), new DotPoint(1, 2) },
        { typeof(DotRankSeparationDefinition), new DotRadialRankSeparation(1) },
        { typeof(DotViewport), new DotViewport(1, 2, 3) }
    };

    [Fact]
    public void complete_graph_has_correct_attribute_keys_on_all_element_types()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("cluster1");
        var subgraph = graph.Subgraphs.Add("subgraph1");
        var node = graph.Nodes.Add("node1");
        var edge = graph.Edges.Add("node1", "node2");

        SetAllElementAttributes(graph.Attributes, graph.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributes(cluster.Attributes, cluster.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributes(subgraph.Attributes, subgraph.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributes(node.Attributes, node.Attributes.GetMetadataDictionary().Values.ToArray());
        SetAllElementAttributes(edge.Attributes, edge.Attributes.GetMetadataDictionary().Values.ToArray());

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

        Snapshot.Match(graph.Build(formatOptions, syntaxOptions), "graph_with_all_attributes_on_all_elements");
    }

    private static void SetAllElementAttributes(IDotEntityAttributesAccessor targetRootObject, DotAttributePropertyMetadata[] attributes)
    {
        var propertyTree = DotPropertyTreeFactory.GetFlattenedPropertyTreeByMetadata(targetRootObject, attributes);

        foreach (var propertySubtree in propertyTree)
        {
            foreach (var property in propertySubtree)
            {
                SetPropertyValue(propertySubtree.Key, property);
            }
        }
    }

    private static void SetPropertyValue(DotEntityAttributes targetObject, PropertyInfo targetProperty)
    {
        var propertyType = (targetProperty.PropertyType.IsNullable() && targetProperty.PropertyType.IsGenericType
                ? Nullable.GetUnderlyingType(targetProperty.PropertyType)
                : targetProperty.PropertyType)
         ?? throw new("Can't determine the property type.");

        if (!PropertyTypeValues.TryGetValue(propertyType, out var value))
        {
            throw new($"No test property value has been specified for type {propertyType.Name}.");
        }

        targetProperty.SetValue(targetObject, value);
    }
}