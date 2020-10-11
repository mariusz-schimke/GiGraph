using System;
using System.Linq.Expressions;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties> : IDotEntityAttributes<TIEntityAttributeProperties>
    {
        protected readonly DotAttributeCollection _attributes;

        public DotEntityAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup)
        {
            _attributes = attributes;
            _propertyAttributeKeyLookup = propertyAttributeKeyLookup;
        }
        
        public virtual DotAttribute GetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.TryGetValue(key, out var result) ? result : null;
        }
        
        public virtual DotAttribute SetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(this, value);

            var key = GetAttributeKey(propertyInfo);
            return _attributes.TryGetValue(key, out var attribute) ? attribute : null;
        }

        public virtual bool RemoveAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.Remove(key);
        }
        
        public virtual bool HasAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.ContainsKey(key);
        }

        public virtual bool HasNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.IsNullified(key);
        }
    }
}