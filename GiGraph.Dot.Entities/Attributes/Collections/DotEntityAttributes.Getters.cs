using System;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, out T value)
        {
            return _attributes.GetValueAs(GetAttributeKey(propertyAccessor), out value);
        }

        protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, out T value, params Func<object, (bool IsValid, T Result)>[] converters)
        {
            return _attributes.GetValueAs(GetAttributeKey(propertyAccessor), out value, converters);
        }

        protected virtual int? GetValueAsInt(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsInt(GetAttributeKey(propertyAccessor));
        }

        protected virtual double? GetValueAsDouble(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsDouble(GetAttributeKey(propertyAccessor));
        }

        protected virtual bool? GetValueAsBool(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsBool(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotColor GetValueAsColor(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsColor(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotPoint GetValueAsPoint(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsPoint(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsColorDefinition(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotLabel GetValueAsLabel(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsLabel(GetAttributeKey(propertyAccessor));
        }

        protected virtual string GetValueAsString(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsString(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotEscapeString GetValueAsEscapeString(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsEscapeString(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsArrowheadDefinition(GetAttributeKey(propertyAccessor));
        }

        protected virtual DotEndpointPort GetValueAsEndpointPort(MethodBase propertyAccessor)
        {
            return _attributes.GetValueAsEndpointPort(GetAttributeKey(propertyAccessor));
        }

        // TODO: zrobić metody set i nazwać je analogicznie do getów, np. SetValueAsString()
    }
}