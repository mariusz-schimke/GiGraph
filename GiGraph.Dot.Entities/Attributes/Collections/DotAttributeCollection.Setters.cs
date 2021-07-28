using System;
using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Images;
using GiGraph.Dot.Types.Labels;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Text;
using GiGraph.Dot.Types.Viewport;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection
    {
        /// <summary>
        ///     Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="attribute">
        ///     The attribute to include in the collection.
        /// </param>
        public virtual T Set<T>(T attribute)
            where T : DotAttribute
        {
            this[attribute.Key] = attribute;
            return attribute;
        }

        protected internal virtual void SetOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            SetOrRemove(key, value is null ? null : newAttribute(key, value));
        }

        protected virtual void SetOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                Remove(key);
            }
            else
            {
                Set(attribute);
            }
        }

        /// <summary>
        ///     Adds or replaces the specified attributes in the collection.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to include in the collection.
        /// </param>
        public virtual void SetRange(IEnumerable<DotAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Set(attribute);
            }
        }

        /// <summary>
        ///     Sets a null value for the specified attribute key.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute whose value to set.
        /// </param>
        public virtual DotNullAttribute Nullify(string key)
        {
            return Set(new DotNullAttribute(key));
        }

        /// <summary>
        ///     Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotStringAttribute Set(string key, string value)
        {
            return Set(new DotStringAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified escape string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEscapeStringAttribute Set(string key, DotEscapeString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified escaped string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEscapeStringAttribute Set(string key, DotEscapedString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified unescaped string attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEscapeStringAttribute Set(string key, DotUnescapedString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified HTML text attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEscapeStringAttribute Set(string key, DotHtml value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotLabel> Set(string key, DotLabel value)
        {
            return Set(new DotComplexAttribute<DotLabel>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified textual label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotTextLabel> Set(string key, DotTextLabel value)
        {
            return Set(new DotComplexAttribute<DotTextLabel>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified HTML label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotHtmlLabel> Set(string key, DotHtmlLabel value)
        {
            return Set(new DotComplexAttribute<DotHtmlLabel>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified record label attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotRecordLabel> Set(string key, DotRecordLabel value)
        {
            return Set(new DotComplexAttribute<DotRecordLabel>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified label justification attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotHorizontalAlignment> Set(string key, DotHorizontalAlignment value)
        {
            return Set(new DotEnumAttribute<DotHorizontalAlignment>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified vertical label alignment attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotVerticalAlignment> Set(string key, DotVerticalAlignment value)
        {
            return Set(new DotEnumAttribute<DotVerticalAlignment>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified integer value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotIntAttribute Set(string key, int value)
        {
            return Set(new DotIntAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified double value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotDoubleAttribute Set(string key, double value)
        {
            return Set(new DotDoubleAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified double list value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotDoubleArrayAttribute Set(string key, params double[] value)
        {
            return Set(new DotDoubleArrayAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified double list value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotDoubleArrayAttribute Set(string key, IEnumerable<double> value)
        {
            return Set(new DotDoubleArrayAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified boolean value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotBoolAttribute Set(string key, bool value)
        {
            return Set(new DotBoolAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified color value attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotColorAttribute Set(string key, Color value)
        {
            return Set(new DotColorAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified color definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotColorDefinition> Set(string key, DotColorDefinition value)
        {
            return Set(new DotComplexAttribute<DotColorDefinition>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified node shape attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotNodeShape> Set(string key, DotNodeShape value)
        {
            return Set(new DotEnumAttribute<DotNodeShape>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified edge shape attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotEdgeShape> Set(string key, DotEdgeShape value)
        {
            return Set(new DotEnumAttribute<DotEdgeShape>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified node fixed size attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotNodeSizing> Set(string key, DotNodeSizing value)
        {
            return Set(new DotEnumAttribute<DotNodeSizing>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified element style attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotStyleAttribute Set(string key, DotStyles value)
        {
            return Set(new DotStyleAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified arrow type attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotArrowheadShape> Set(string key, DotArrowheadShape value)
        {
            return Set(new DotEnumAttribute<DotArrowheadShape>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified arrow direction attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotEdgeDirections> Set(string key, DotEdgeDirections value)
        {
            return Set(new DotEnumAttribute<DotEdgeDirections>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified rank constraints attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotRank> Set(string key, DotRank value)
        {
            return Set(new DotEnumAttribute<DotRank>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified graph layout direction attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotLayoutDirection> Set(string key, DotLayoutDirection value)
        {
            return Set(new DotEnumAttribute<DotLayoutDirection>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified cluster mode attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotClusterVisualizationMode> Set(string key, DotClusterVisualizationMode value)
        {
            return Set(new DotEnumAttribute<DotClusterVisualizationMode>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified edge ordering mode attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotEdgeOrderingMode> Set(string key, DotEdgeOrderingMode value)
        {
            return Set(new DotEnumAttribute<DotEdgeOrderingMode>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified graph orientation attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotOrientation> Set(string key, DotOrientation value)
        {
            return Set(new DotEnumAttribute<DotOrientation>(key, value));
        }

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
        public virtual DotComplexAttribute<DotRankSeparationDefinition> Set(string key, DotRankSeparationDefinition value)
        {
            return Set(new DotComplexAttribute<DotRankSeparationDefinition>(key, value));
        }

        /// <summary>
        ///     Sets an endpoint port, that is a point on a node where an edge is attached to.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotEndpointPort> Set(string key, DotEndpointPort value)
        {
            return Set(new DotComplexAttribute<DotEndpointPort>(key, value));
        }

        /// <summary>
        ///     Sets an endpoint compass point, that is a point on a node where an edge is attached to.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotCompassPoint> Set(string key, DotCompassPoint value)
        {
            return Set(new DotEnumAttribute<DotCompassPoint>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified image alignment attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotAlignment> Set(string key, DotAlignment value)
        {
            return Set(new DotEnumAttribute<DotAlignment>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified point attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotPoint> Set(string key, DotPoint value)
        {
            return Set(new DotComplexAttribute<DotPoint>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified rectangle attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotRectangle> Set(string key, DotRectangle value)
        {
            return Set(new DotComplexAttribute<DotRectangle>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified rectangle array attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotRectangleArrayAttribute Set(string key, DotRectangle[] value)
        {
            return Set(new DotRectangleArrayAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified rectangle array attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotRectangleArrayAttribute Set(string key, IEnumerable<DotRectangle> value)
        {
            return Set(new DotRectangleArrayAttribute(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified aspect ratio attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotGraphScalingDefinition> Set(string key, DotGraphScalingDefinition value)
        {
            return Set(new DotComplexAttribute<DotGraphScalingDefinition>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified packing definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotPackingDefinition> Set(string key, DotPackingDefinition value)
        {
            return Set(new DotComplexAttribute<DotPackingDefinition>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified aspect ratio attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotGraphScaling> Set(string key, DotGraphScaling value)
        {
            return Set(new DotEnumAttribute<DotGraphScaling>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified arrow definition attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotArrowheadDefinition> Set(string key, DotArrowheadDefinition value)
        {
            return Set(new DotComplexAttribute<DotArrowheadDefinition>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified packing granularity attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotPackingGranularity> Set(string key, DotPackingGranularity value)
        {
            return Set(new DotEnumAttribute<DotPackingGranularity>(key, value));
        }

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
        public virtual DotComplexAttribute<DotPackingModeDefinition> Set(string key, DotPackingModeDefinition value)
        {
            return Set(new DotComplexAttribute<DotPackingModeDefinition>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified image scaling option attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotImageScaling> Set(string key, DotImageScaling value)
        {
            return Set(new DotEnumAttribute<DotImageScaling>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified element identifier attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotId> Set(string key, DotId value)
        {
            return Set(new DotComplexAttribute<DotId>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified cluster identifier attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotClusterId> Set(string key, DotClusterId value)
        {
            return Set(new DotComplexAttribute<DotClusterId>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified viewport attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotComplexAttribute<DotViewport> Set(string key, DotViewport value)
        {
            return Set(new DotComplexAttribute<DotViewport>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified font convention attribute in the collection.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotEnumAttribute<DotFontConvention> Set(string key, DotFontConvention value)
        {
            return Set(new DotEnumAttribute<DotFontConvention>(key, value));
        }

        /// <summary>
        ///     Adds or replaces the specified attribute in the collection. The value is rendered AS IS in the output DOT script, so the
        ///     attribute can be used for any type of value, not only for strings. Make sure, however, that the value is escaped when
        ///     necessary, following the DOT syntax rules ( <see href="https://graphviz.org/doc/info/lang.html" />). If, for instance, it
        ///     contains an unescaped quotation mark, the output script will be syntactically incorrect.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute to include in the collection.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute to include in the collection.
        /// </param>
        public virtual DotCustomAttribute SetCustom(string key, string value)
        {
            return Set(new DotCustomAttribute(key, value));
        }
    }
}