using System;
using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Output;
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
        public virtual DotAttributeCollection Set<T>(T attribute)
            where T : DotAttribute
        {
            this[attribute.Key] = attribute;
            return this;
        }

        protected internal virtual void SetOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            SetOrRemove(key, value is null ? null : newAttribute(key, value));
        }

        protected internal void SetOrRemove(string key, DotEscapeString value)
        {
            SetOrRemove(key, value, _attributeFactory.CreateEscapeString);
        }

        protected internal void SetOrRemove(string key, string value)
        {
            SetOrRemove(key, value, _attributeFactory.CreateString);
        }

        protected internal void SetOrRemove(string key, int? value)
        {
            SetOrRemove(key, value, (k, v) => _attributeFactory.CreateInt(k, v!.Value));
        }

        protected internal void SetOrRemove(string key, double? value)
        {
            SetOrRemove(key, value, (k, v) => _attributeFactory.CreateDouble(k, v!.Value));
        }

        protected internal void SetOrRemove(string key, bool? value)
        {
            SetOrRemove(key, value, (k, v) => _attributeFactory.CreateBool(k, v!.Value));
        }

        protected internal void SetOrRemoveComplex<TComplex>(string key, TComplex value)
            where TComplex : IDotEncodable
        {
            SetOrRemove(key, value, _attributeFactory.CreateComplex);
        }

        protected internal void SetOrRemoveEnum<TEnum>(string key, bool hasValue, Func<TEnum> value)
            where TEnum : Enum
        {
            SetOrRemove(key, hasValue ? _attributeFactory.CreateEnum(key, value()) : null);
        }

        protected virtual void SetOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is not null)
            {
                Set(attribute);
            }
            else
            {
                Remove(key);
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
        public virtual DotAttributeCollection Nullify(string key)
        {
            return Set(_attributeFactory.CreateNull(key));
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
        public virtual DotAttributeCollection Set(string key, string value)
        {
            return Set(_attributeFactory.CreateString(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEscapeString value)
        {
            return Set(_attributeFactory.CreateEscapeString(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEscapedString value)
        {
            return Set(_attributeFactory.CreateEscapeString(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotUnescapedString value)
        {
            return Set(_attributeFactory.CreateEscapeString(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotHtml value)
        {
            return Set(_attributeFactory.CreateEscapeString(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotLabel value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotTextLabel value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotHtmlLabel value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotRecordLabel value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotHorizontalAlignment value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotVerticalAlignment value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, int value)
        {
            return Set(_attributeFactory.CreateInt(key, value));
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
        public virtual DotAttributeCollection Set(string key, double value)
        {
            return Set(_attributeFactory.CreateDouble(key, value));
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
        public virtual DotAttributeCollection Set(string key, params double[] value)
        {
            return Set(_attributeFactory.CreateDoubleArray(key, value));
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
        public virtual DotAttributeCollection Set(string key, IEnumerable<double> value)
        {
            return Set(_attributeFactory.CreateDoubleArray(key, value));
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
        public virtual DotAttributeCollection Set(string key, bool value)
        {
            return Set(_attributeFactory.CreateBool(key, value));
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
        public virtual DotAttributeCollection Set(string key, Color value)
        {
            return Set(_attributeFactory.CreateColor(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotColorDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotNodeShape value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEdgeShape value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotNodeSizing value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotStyles value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotArrowheadShape value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEdgeDirections value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotRank value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotLayoutDirection value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotClusterVisualizationMode value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEdgeOrderingMode value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotOrientation value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotRankSeparationDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotEndpointPort value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotCompassPoint value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotAlignment value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotPoint value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotRectangle value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotRectangle[] value)
        {
            return Set(_attributeFactory.CreateComplexArray(key, value));
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
        public virtual DotAttributeCollection Set(string key, IEnumerable<DotRectangle> value)
        {
            return Set(_attributeFactory.CreateComplexArray(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotGraphScalingDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotPackingDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotGraphScaling value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotArrowheadDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotPackingGranularity value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotPackingModeDefinition value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotImageScaling value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotId value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotClusterId value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotViewport value)
        {
            return Set(_attributeFactory.CreateComplex(key, value));
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
        public virtual DotAttributeCollection Set(string key, DotFontConvention value)
        {
            return Set(_attributeFactory.CreateEnum(key, value));
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
        public virtual DotAttributeCollection SetCustom(string key, string value)
        {
            return Set(_attributeFactory.CreateCustom(key, value));
        }
    }
}