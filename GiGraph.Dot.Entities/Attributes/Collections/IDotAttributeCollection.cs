using System;
using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotAttributeCollection : IDictionary<string, DotAttribute>, IDotEntity, IDotAnnotatable
    {
        /// <summary>
        ///     Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="attribute">
        ///     The attribute to include in the collection.
        /// </param>
        T Set<T>(T attribute) where T : DotAttribute;

        /// <summary>
        ///     Adds or replaces the specified attributes in the collection.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to include in the collection.
        /// </param>
        void SetRange(IEnumerable<DotAttribute> attributes);

        /// <summary>
        ///     Sets a null value for the specified attribute key.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute whose value to set.
        /// </param>
        DotNullAttribute SetNull(string key);

        /// <summary>
        ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute whose value to check.
        /// </param>
        bool IsNullified(string key);

        /// <summary>
        ///     Adds or replaces the specified attribute in the collection. The value can be any string understood by the DOT visualization
        ///     tool for the specified attribute key.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotStringAttribute Set(string key, string value);

        /// <summary>
        ///     Adds or replaces the specified escape string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEscapeStringAttribute Set(string key, DotEscapeString value);

        /// <summary>
        ///     Adds or replaces the specified escaped string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEscapeStringAttribute Set(string key, DotEscapedString value);

        /// <summary>
        ///     Adds or replaces the specified unescaped string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEscapeStringAttribute Set(string key, DotUnescapedString value);

        /// <summary>
        ///     Adds or replaces the specified label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotLabelAttribute Set(string key, DotLabel value);

        /// <summary>
        ///     Adds or replaces the specified textual label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotLabelAttribute Set(string key, DotTextLabel value);

        /// <summary>
        ///     Adds or replaces the specified HTML label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotLabelAttribute Set(string key, DotHtmlLabel value);

        /// <summary>
        ///     Adds or replaces the specified record label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotLabelAttribute Set(string key, DotRecordLabel value);

        /// <summary>
        ///     Adds or replaces the specified label justification attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotHorizontalAlignmentAttribute Set(string key, DotHorizontalAlignment value);

        /// <summary>
        ///     Adds or replaces the specified vertical label alignment attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotVerticalAlignmentAttribute Set(string key, DotVerticalAlignment value);

        /// <summary>
        ///     Adds or replaces the specified image alignment attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotAlignmentAttribute Set(string key, DotAlignment value);

        /// <summary>
        ///     Adds or replaces the specified integer value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotIntAttribute Set(string key, int value);

        /// <summary>
        ///     Adds or replaces the specified double value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotDoubleAttribute Set(string key, double value);

        /// <summary>
        ///     Adds or replaces the specified double list value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotDoubleArrayAttribute Set(string key, params double[] value);

        /// <summary>
        ///     Adds or replaces the specified double list value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotDoubleArrayAttribute Set(string key, IEnumerable<double> value);

        /// <summary>
        ///     Adds or replaces the specified boolean value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotBoolAttribute Set(string key, bool value);

        /// <summary>
        ///     Adds or replaces the specified color value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotColorAttribute Set(string key, Color value);

        /// <summary>
        ///     Adds or replaces the specified color definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotColorDefinitionAttribute Set(string key, DotColorDefinition value);

        /// <summary>
        ///     Adds or replaces the specified aspect ratio attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotGraphScalingAttribute Set(string key, DotGraphScaling value);

        /// <summary>
        ///     Adds or replaces the specified aspect ratio attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotGraphScalingDefinitionAttribute Set(string key, DotGraphScalingDefinition value);

        /// <summary>
        ///     Adds or replaces the specified packing definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotPackingDefinitionAttribute Set(string key, DotPackingDefinition value);

        /// <summary>
        ///     Adds or replaces the specified point attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotPointAttribute Set(string key, DotPoint value);

        /// <summary>
        ///     Adds or replaces the specified node shape attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotNodeShapeAttribute Set(string key, DotNodeShape value);

        /// <summary>
        ///     Adds or replaces the specified edge shape attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEdgeShapeAttribute Set(string key, DotEdgeShape value);

        /// <summary>
        ///     Adds or replaces the specified node fixed size attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotNodeSizingAttribute Set(string key, DotNodeSizing value);

        /// <summary>
        ///     Adds or replaces the specified image scaling option attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotImageScalingAttribute Set(string key, DotImageScaling value);

        /// <summary>
        ///     Adds or replaces the specified element style attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotStyleAttribute Set(string key, DotStyles value);

        /// <summary>
        ///     Adds or replaces the specified arrow type attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotArrowheadShapeAttribute Set(string key, DotArrowheadShape value);

        /// <summary>
        ///     Adds or replaces the specified cluster mode attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotClusterVisualizationModeAttribute Set(string key, DotClusterVisualizationMode value);

        /// <summary>
        ///     Adds or replaces the specified arrow definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotArrowheadDefinitionAttribute Set(string key, DotArrowheadDefinition value);

        /// <summary>
        ///     Adds or replaces the specified arrow direction attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotArrowDirectionsAttribute Set(string key, DotArrowDirections value);

        /// <summary>
        ///     Adds or replaces the specified rank constraint attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotRankAttribute Set(string key, DotRank value);

        /// <summary>
        ///     Adds or replaces the specified graph layout direction attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotLayoutDirectionAttribute Set(string key, DotLayoutDirection value);

        /// <summary>
        ///     Adds or replaces the specified edge ordering mode attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEdgeOrderingModeAttribute Set(string key, DotEdgeOrderingMode value);

        /// <summary>
        ///     Adds or replaces the specified graph orientation attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotOrientationAttribute Set(string key, DotOrientation value);

        /// <summary>
        ///     Adds or replaces the specified rank separation attribute in the collection (<see cref="DotRankSeparation" /> or
        ///     <see cref="DotRadialRankSeparation" />).
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotRankSeparationDefinitionAttribute Set(string key, DotRankSeparationDefinition value);

        /// <summary>
        ///     Sets an endpoint port, that is a point on a node where an edge is attached to.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotEndpointPortAttribute Set(string key, DotEndpointPort value);

        /// <summary>
        ///     Sets an endpoint compass point, that is a point on a node where an edge is attached to.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotCompassPointAttribute Set(string key, DotCompassPoint value);

        /// <summary>
        ///     Adds or replaces the specified packing granularity attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotPackingGranularityAttribute Set(string key, DotPackingGranularity value);

        /// <summary>
        ///     Adds or replaces the specified packing mode attribute in the collection (<see cref="DotGranularPackingMode" /> or
        ///     <see cref="DotArrayPackingMode" />).
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        DotPackingModeDefinitionAttribute Set(string key, DotPackingModeDefinition value);

        /// <summary>
        ///     Checks if an attribute with the specified key exists in the collection, and returns it as the specified type. If the
        ///     attribute is found, but cannot be cast as the specified type, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return the attribute as.
        /// </typeparam>
        /// <param name="key">
        ///     The key of the attribute to get.
        /// </param>
        T GetAs<T>(string key) where T : DotAttribute;

        /// <summary>
        ///     Checks if an attribute with the specified key exists in the collection, and returns it as the specified type. If the
        ///     attribute is found, but cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return the attribute as.
        /// </typeparam>
        /// <param name="key">
        ///     The key of the attribute to get.
        /// </param>
        /// <param name="attribute">
        ///     The attribute if found and valid, or null otherwise.
        /// </param>
        bool TryGetAs<T>(string key, out T attribute) where T : DotAttribute;

        /// <summary>
        ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
        ///     attribute is found, but its value cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return the attribute value as.
        /// </typeparam>
        /// <param name="key">
        ///     The key of the attribute to get.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute if found and valid, or null otherwise.
        /// </param>
        bool TryGetValueAs<T>(string key, out T value);

        /// <summary>
        ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
        ///     attribute is found, but its value cannot be cast as the specified type, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">
        ///     The type to return the attribute value as.
        /// </typeparam>
        /// <param name="key">
        ///     The key of the attribute to get.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute if found and valid, or null if not found.
        /// </param>
        bool GetValueAs<T>(string key, out T value);

        /// <summary>
        ///     Removes all attributes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">
        ///     The predicate to use for matching attributes.
        /// </param>
        int RemoveAll(Predicate<DotAttribute> match);
    }
}