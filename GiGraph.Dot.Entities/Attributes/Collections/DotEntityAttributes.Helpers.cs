using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
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
            return TryGetValueAsColorDefinition(GetAttributeKey(propertyMethod));
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
            return TryGetValueAsLabel(GetAttributeKey(propertyMethod));
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
            return TryGetValueAsEscapeString(GetAttributeKey(propertyMethod));
        }

        protected virtual bool TryGetValueAs<T>(MethodBase propertyMethod, out T value)
        {
            return TryGetValueAs(GetAttributeKey(propertyMethod), out value);
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(MethodBase propertyMethod, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(GetAttributeKey(propertyMethod), value, newAttribute);
        }

        protected virtual string GetAttributeKey(MethodBase propertyMethod)
        {
            var property = propertyMethod?.DeclaringType
              ?.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
              ?.FirstOrDefault(propertyInfo => propertyInfo.GetGetMethod(true) == propertyMethod ||
                                               propertyInfo.GetSetMethod(true) == propertyMethod);

            return property?.GetCustomAttribute<DotAttributeKeyAttribute>()?.Key ??
                   throw new KeyNotFoundException("The property has no DOT attribute key assigned.");
        }

        protected virtual string GetAttributeKey<TIAttributeCollection, TProperty>(Expression<Func<TIAttributeCollection, TProperty>> property)
            where TIAttributeCollection : IDotAttributeCollection
        {
            var memberExpression = property.Body as MemberExpression;
            var propertyInfo = memberExpression?.Member as PropertyInfo ??
                               throw new ArgumentException("Property expression expected.", nameof(property));

            if (propertyInfo.DeclaringType != typeof(TIAttributeCollection))
            {
                throw new ArgumentException("Invalid property expression.", nameof(property));
            }

            var currentType = GetType();

            if (!propertyInfo.DeclaringType.IsAssignableFrom(currentType))
            {
                throw new TypeAccessException($"The current object has to implement or be a descendant of {propertyInfo.DeclaringType.FullName}.");
            }

            var propertyMethod = propertyInfo.GetSetMethod() ?? propertyInfo.GetGetMethod();

            if (propertyInfo.DeclaringType.IsInterface)
            {
                var interfaceMap = currentType.GetInterfaceMap(propertyInfo.DeclaringType);
                var interfaceMethodIndex = Array.IndexOf(interfaceMap.InterfaceMethods, propertyMethod);
                var targetMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

                return GetAttributeKey(targetMethod);
            }

            return GetAttributeKey(propertyMethod);
        }

        protected virtual bool Remove<TIAttributeCollection, TProperty>(Expression<Func<TIAttributeCollection, TProperty>> property)
            where TIAttributeCollection : IDotAttributeCollection
        {
            var key = GetAttributeKey(property);

            if (ContainsKey(key))
            {
                Remove(key);
                return true;
            }

            return false;
        }

        protected virtual bool ContainsKey<TIAttributeCollection, TProperty>(Expression<Func<TIAttributeCollection, TProperty>> property)
            where TIAttributeCollection : IDotAttributeCollection
        {
            var key = GetAttributeKey(property);
            return ContainsKey(key);
        }
    }
}