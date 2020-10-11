using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributes<TIEntityAttributeProperties>
    {
        DotAttribute GetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);
        DotAttribute SetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value);
        bool HasAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);
        bool HasNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);
        DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);
        string GetAttributeKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);
        Dictionary<string, string> GetAttributeKeyMapping();
    }
}