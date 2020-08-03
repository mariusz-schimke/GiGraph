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
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes> : IDotEntityAttributeCollection<TExposedEntityAttributes>
    {
        public virtual string GetKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
                               throw new ArgumentException("Property expression expected.", nameof(property));

            var currentType = GetType();

            // make sure the property expression refers to current instance type, to any of its base classes, or to an interface it implements
            if (!propertyInfo.DeclaringType.IsAssignableFrom(currentType))
            {
                throw new ArgumentException("The property expression must refer to a member of the current instance.", nameof(property));
            }

            if (propertyInfo.DeclaringType.IsInterface)
            {
                // get the get method (property expression is impossible for write-only properties)
                // include non-public methods (interface may be implemented explicitly)
                var propertyMethod = propertyInfo.GetGetMethod(nonPublic: true);

                var interfaceMap = currentType.GetInterfaceMap(propertyInfo.DeclaringType);
                var interfaceMethodIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(propertyMethod));
                var targetMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

                return GetKey(targetMethod, currentType);
            }

            return GetKey(propertyInfo);
        }

        public virtual DotNullAttribute SetNull<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return SetNull(key);
        }

        public virtual DotAttribute Get<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return TryGetValue(key, out var result) ? result : null;
        }

        public virtual bool Remove<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return Remove(key);
        }

        public virtual bool Contains<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
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
            AddOrRemove(GetKey(propertyMethod), value, newAttribute);
        }

        protected virtual string GetKey(MethodBase propertyMethod)
        {
            return GetKey(propertyMethod, propertyMethod.DeclaringType);
        }

        protected virtual string GetKey(MethodBase propertyMethod, Type declaringType)
        {
            var property = declaringType
              ?.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
              ?.FirstOrDefault(propertyInfo => propertyInfo.GetSetMethod(nonPublic: true) == propertyMethod ||
                                               propertyInfo.GetGetMethod(nonPublic: true) == propertyMethod);

            if (property is null)
            {
                throw new ArgumentException("The specified method must be a property setter or getter.", nameof(propertyMethod));
            }

            return GetKey(property);
        }

        protected virtual string GetKey(PropertyInfo property)
        {
            return property.GetCustomAttribute<DotAttributeKeyAttribute>()?.Key ??
                   throw new KeyNotFoundException("The specified property has no DOT attribute key assigned.");
        }

        protected virtual bool GetValueAs<T>(MethodBase propertyMethod, out T value)
        {
            return GetValueAs(GetKey(propertyMethod), out value);
        }

        protected virtual double? GetValueAsDouble(string key)
        {
            return GetValueAs(key, out var value, v => v is int i ? (true, i) : (false, default))
                ? value
                : (double?) null;
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