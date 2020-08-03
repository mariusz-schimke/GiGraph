using System;
using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes>
    {
        public virtual void SetFilled(Color color)
        {
            SetFilled((DotColorDefinition) color);
        }

        public virtual void SetFilled(DotColorDefinition value)
        {
            Style = Style.GetValueOrDefault(DotStyle.Filled) | DotStyle.Filled;
            FillColor = value;
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(MethodBase propertyMethod, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(GetKey(propertyMethod), value, newAttribute);
        }

        protected virtual bool GetValueAs<T>(MethodBase propertyMethod, out T value)
        {
            return GetValueAs(GetKey(propertyMethod), out value);
        }

        protected virtual double? GetValueAsDouble(MethodBase propertyMethod)
        {
            return GetValueAsDouble(GetKey(propertyMethod));
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(MethodBase propertyMethod)
        {
            return GetValueAsColorDefinition(GetKey(propertyMethod));
        }

        protected virtual DotLabel GetValueAsLabel(MethodBase propertyMethod)
        {
            return GetValueAsLabel(GetKey(propertyMethod));
        }

        protected virtual DotEscapeString GetValueAsEscapeString(MethodBase propertyMethod)
        {
            return GetValueAsEscapeString(GetKey(propertyMethod));
        }
    }
}