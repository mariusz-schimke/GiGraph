using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public  abstract partial class DotEntityAttributes<TIEntityAttributeProperties> 
    {
        public virtual DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.SetNull(key);
        }

        // TODO: zrobić metody set i nazwać je analogicznie do getów, np. SetValueAsString()
        protected virtual void AddOrRemove<TAttribute, TValue>(MethodBase propertyAccessor, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(GetAttributeKey(propertyAccessor), value, newAttribute);
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : newAttribute(key, value));
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                _attributes.Remove(key);
            }
            else
            {
                _attributes.Set(attribute);
            }
        }
    }
}