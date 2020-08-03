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

        protected virtual DotColorDefinition TryGetValueAsColorDefinition(string key)
        {
            if (TryGetValueAs<DotColorDefinition>(key, out var colorDefinition))
            {
                return colorDefinition;
            }

            return TryGetValueAs<Color>(key, out var color) ? new DotColor(color) : null;
        }

        protected virtual DotColorDefinition TryGetValueAsColorDefinition(MethodBase propertyMethod)
        {
            return TryGetValueAsColorDefinition(GetKey(propertyMethod));
        }

        protected virtual DotLabel TryGetValueAsLabel(string key)
        {
            if (TryGetValueAs<DotLabel>(key, out var label))
            {
                return label;
            }

            return TryGetValueAsEscapeString(key);
        }

        protected virtual DotLabel TryGetValueAsLabel(MethodBase propertyMethod)
        {
            return TryGetValueAsLabel(GetKey(propertyMethod));
        }

        protected virtual DotEscapeString TryGetValueAsEscapeString(string key)
        {
            if (TryGetValueAs<DotEscapeString>(key, out var escapeString))
            {
                return escapeString;
            }

            return TryGetValueAs<string>(key, out var value) ? (DotEscapedString) value : null;
        }

        protected virtual DotEscapeString TryGetValueAsEscapeString(MethodBase propertyMethod)
        {
            return TryGetValueAsEscapeString(GetKey(propertyMethod));
        }
    }
}