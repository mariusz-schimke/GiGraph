using System;
using System.Reflection;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Labels;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes
    {
        protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, out T value)
        {
            return _attributes.GetValueAs(GetKey(propertyAccessor), out value);
        }

        protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, out T value, params Func<object, (bool IsValid, T Result)>[] converters)
        {
            return _attributes.GetValueAs(GetKey(propertyAccessor), out value, converters);
        }

        protected virtual int? GetValueAsInt(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsInt(GetKey(propertyAccessor));
        }

        protected virtual double? GetValueAsDouble(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsDouble(GetKey(propertyAccessor));
        }

        protected virtual bool? GetValueAsBool(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsBool(GetKey(propertyAccessor));
        }

        protected virtual DotColor GetValueAsColor(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsColor(GetKey(propertyAccessor));
        }

        protected virtual DotPoint GetValueAsPoint(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsPoint(GetKey(propertyAccessor));
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsColorDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotLabel GetValueAsLabel(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsLabel(GetKey(propertyAccessor));
        }

        protected virtual string GetValueAsString(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsString(GetKey(propertyAccessor));
        }

        protected virtual DotEscapeString GetValueAsEscapeString(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsEscapeString(GetKey(propertyAccessor));
        }

        protected virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsArrowheadDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotPackingDefinition GetValueAsPackingDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsPackingDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotPackingModeDefinition GetValueAsPackingModeDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsPackingModeDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotRankSeparationDefinition GetValueAsRankSeparationDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsRankSeparationDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotGraphScalingDefinition GetValueAsGraphScalingDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsGraphScalingDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotEndpointPort GetValueAsEndpointPort(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsEndpointPort(GetKey(propertyAccessor));
        }

        protected virtual DotId GetValueAsId(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsId(GetKey(propertyAccessor));
        }

        protected virtual DotClusterId GetValueAsClusterId(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsClusterId(GetKey(propertyAccessor));
        }
    }
}