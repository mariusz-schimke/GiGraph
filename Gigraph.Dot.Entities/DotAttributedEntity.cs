using Gigraph.Dot.Entities.Attributes;
using System;
using System.Drawing;

namespace Gigraph.Dot.Entities
{
    public abstract class DotAttributedEntity : IDotEntity
    {
        public virtual DotAttributeCollection Attributes { get; } = new DotAttributeCollection();

        public virtual DotLabelAttribute Label
        {
            get => Attributes.TryGet<DotLabelAttribute>(DotLabelAttribute.AttributeKey);
            set => AddOrRemove(DotLabelAttribute.AttributeKey, value);
        }

        public virtual Color? Color
        {
            get => Attributes.TryGet<DotColorAttribute>(DotColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotColorAttribute.AttributeKey, value, v => new DotColorAttribute(v.Value));
        }

        public virtual Color? BackgroundColor
        {
            get => Attributes.TryGet<DotBackgroundColorAttribute>(DotBackgroundColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotBackgroundColorAttribute.AttributeKey, value, v => new DotBackgroundColorAttribute(v.Value));
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                Attributes.Remove(key);
            }
            else
            {
                Attributes.AddOrReplace(attribute);
            }
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<TValue, TAttribute> attribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : attribute(value));
        }
    }
}
