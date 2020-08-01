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
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes>
    {
        public virtual string GetAttributeKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            var propertyInfo = memberExpression?.Member as PropertyInfo ??
                               throw new ArgumentException("Property expression expected.", nameof(property));

            if (propertyInfo.DeclaringType != typeof(TExposedEntityAttributes))
            {
                throw new ArgumentException("Invalid property expression.", nameof(property));
            }

            var currentType = GetType();

            if (!propertyInfo.DeclaringType.IsAssignableFrom(currentType))
            {
                throw new TypeAccessException($"The current instance type has to be assignable to {propertyInfo.DeclaringType.FullName}.");
            }

            if (propertyInfo.DeclaringType.IsInterface)
            {
                var propertyMethod = propertyInfo.GetSetMethod(nonPublic: true) ?? propertyInfo.GetGetMethod(nonPublic: true);

                var interfaceMap = currentType.GetInterfaceMap(propertyInfo.DeclaringType);
                var interfaceMethodIndex = Array.IndexOf(interfaceMap.InterfaceMethods, propertyMethod);
                var targetMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

                return GetAttributeKey(targetMethod, currentType);
            }

            return GetAttributeKey(propertyInfo);
        }

        public virtual bool Remove<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return Remove(key);
        }

        public virtual bool ContainsKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return ContainsKey(key);
        }

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
            AddOrRemove(GetAttributeKey(propertyMethod), value, newAttribute);
        }

        protected virtual string GetAttributeKey(MethodBase propertyMethod)
        {
            return GetAttributeKey(propertyMethod, propertyMethod.DeclaringType);
        }

        protected virtual string GetAttributeKey(MethodBase propertyMethod, Type declaringType)
        {
            var property = declaringType
              ?.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
              ?.FirstOrDefault(propertyInfo => propertyInfo.GetGetMethod(nonPublic: true) == propertyMethod ||
                                               propertyInfo.GetSetMethod(nonPublic: true) == propertyMethod);

            if (property is null)
            {
                throw new ArgumentException("The specified method must be a property setter or getter.", nameof(propertyMethod));
            }

            return GetAttributeKey(property);
        }

        protected virtual string GetAttributeKey(PropertyInfo property)
        {
            return property.GetCustomAttribute<DotAttributeKeyAttribute>()?.Key ??
                   throw new KeyNotFoundException("The specified property has no DOT attribute key assigned.");
        }

        protected virtual bool TryGetValueAs<T>(MethodBase propertyMethod, out T value)
        {
            return TryGetValueAs(GetAttributeKey(propertyMethod), out value);
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
    }
}