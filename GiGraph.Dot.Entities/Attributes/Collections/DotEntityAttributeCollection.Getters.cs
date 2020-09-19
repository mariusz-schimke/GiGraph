using System.Reflection;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes>
    {
        protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, out T value)
        {
            return GetValueAs(GetKey(propertyAccessor), out value);
        }

        protected virtual int? GetValueAsInt(MethodBase propertyAccessor)
        {
            return GetValueAsInt(GetKey(propertyAccessor));
        }

        protected virtual double? GetValueAsDouble(MethodBase propertyAccessor)
        {
            return GetValueAsDouble(GetKey(propertyAccessor));
        }

        protected virtual bool? GetValueAsBool(MethodBase propertyAccessor)
        {
            return GetValueAsBool(GetKey(propertyAccessor));
        }

        protected virtual DotColor GetValueAsColor(MethodBase propertyAccessor)
        {
            return GetValueAsColor(GetKey(propertyAccessor));
        }

        protected virtual DotPoint GetValueAsPoint(MethodBase propertyAccessor)
        {
            return GetValueAsPoint(GetKey(propertyAccessor));
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(MethodBase propertyAccessor)
        {
            return GetValueAsColorDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotLabel GetValueAsLabel(MethodBase propertyAccessor)
        {
            return GetValueAsLabel(GetKey(propertyAccessor));
        }

        protected virtual string GetValueAsString(MethodBase propertyAccessor)
        {
            return GetValueAsString(GetKey(propertyAccessor));
        }

        protected virtual DotEscapeString GetValueAsEscapeString(MethodBase propertyAccessor)
        {
            return GetValueAsEscapeString(GetKey(propertyAccessor));
        }

        protected virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(MethodBase propertyAccessor)
        {
            return GetValueAsArrowheadDefinition(GetKey(propertyAccessor));
        }

        protected virtual DotEndpointPort GetValueAsEndpointPort(MethodBase propertyAccessor)
        {
            return GetValueAsEndpointPort(GetKey(propertyAccessor));
        }
    }
}