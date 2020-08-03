using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes>
    {
        protected virtual bool GetValueAs<T>(MethodBase propertyMethod, out T value)
        {
            return GetValueAs(GetKey(propertyMethod), out value);
        }

        protected virtual int? GetValueAsInt(MethodBase propertyMethod)
        {
            return GetValueAsInt(GetKey(propertyMethod));
        }

        protected virtual double? GetValueAsDouble(MethodBase propertyMethod)
        {
            return GetValueAsDouble(GetKey(propertyMethod));
        }

        protected virtual bool? GetValueAsBool(MethodBase propertyMethod)
        {
            return GetValueAsBool(GetKey(propertyMethod));
        }

        protected virtual Color? GetValueAsColor(MethodBase propertyMethod)
        {
            return GetValueAsColor(GetKey(propertyMethod));
        }

        protected virtual DotPoint GetValueAsPoint(MethodBase propertyMethod)
        {
            return GetValueAsPoint(GetKey(propertyMethod));
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(MethodBase propertyMethod)
        {
            return GetValueAsColorDefinition(GetKey(propertyMethod));
        }

        protected virtual DotLabel GetValueAsLabel(MethodBase propertyMethod)
        {
            return GetValueAsLabel(GetKey(propertyMethod));
        }

        protected virtual string GetValueAsString(MethodBase propertyMethod)
        {
            return GetValueAsString(GetKey(propertyMethod));
        }

        protected virtual DotEscapeString GetValueAsEscapeString(MethodBase propertyMethod)
        {
            return GetValueAsEscapeString(GetKey(propertyMethod));
        }

        protected virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(MethodBase propertyMethod)
        {
            return GetValueAsArrowheadDefinition(GetKey(propertyMethod));
        }
    }
}