using Gigraph.Dot.Entities.Attributes;
using System;
using System.Drawing;

namespace Gigraph.Dot.Entities
{
    public abstract class DotAttributedEntity : IDotEntity
    {
        /// <summary>
        /// The collection of attributes of the element.
        /// </summary>
        public virtual DotAttributeCollection Attributes { get; } = new DotAttributeCollection();

        /// <summary>
        /// Gets or sets the label to display on the element.
        /// </summary>
        public virtual DotLabelAttribute Label
        {
            get => Attributes.TryGet<DotLabelAttribute>(DotLabelAttribute.AttributeKey);
            set => AddOrRemove(DotLabelAttribute.AttributeKey, value);
        }

        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => Attributes.TryGet<DotColorAttribute>(DotColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotColorAttribute.AttributeKey, value, v => new DotColorAttribute(v.Value));
        }

        /// <summary>
        /// Gets or sets the background color of the element.
        /// </summary>
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
