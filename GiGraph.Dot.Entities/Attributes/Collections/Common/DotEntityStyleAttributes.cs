using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Helpers;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotEntityStyleAttributes
    {
        protected const string StyleKey = DotAttributeKeys.Style;
        protected readonly DotAttributeCollection _attributes;

        public DotEntityStyleAttributes(DotAttributeCollection attributes)
        {
            _attributes = attributes;
        }

        protected virtual DotStyles? Style
        {
            get => _attributes.GetValueAs<DotStyles>(StyleKey, out var result) ? result : (DotStyles?) null;
            set => _attributes.SetOrRemove(StyleKey, value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        /// <summary>
        ///     Determines if any style is assigned to the element.
        /// </summary>
        public virtual bool IsSet()
        {
            return Style.HasValue;
        }

        /// <summary>
        ///     Determines if the default style is assigned to the element.
        /// </summary>
        public virtual bool IsDefault()
        {
            return Style == DotStyles.Default;
        }

        // TODO: jak temu atrybutowi ustawić annotation, jeśli nie ma metod pobrania go?
        // Może wystawic prywatnie Style jako DotStyle w interfejsach klas nadrzędnych i wtedy z ich poziomu
        // będzie się dało ustawiac ten atrybut?
        // Czy wtedy interfejs IDotEntityStyleAttributes można usunąć, a do atrybutu odnosić się po stałej?

        /// <summary>
        ///     Removes style from the element.
        /// </summary>
        public virtual void Remove()
        {
            Style = null;
        }

        /// <summary>
        ///     Assigns the default style to the element. Useful when the style of elements of the current type is set globally, and needs to
        ///     be restored to the default value for the current element.
        /// </summary>
        public virtual void SetDefault()
        {
            SetValue(DotStyles.Default);
        }

        protected virtual void Apply(DotStyles options)
        {
            var value = Style.GetValueOrDefault(options) | options;
            SetValue(value);
        }

        protected virtual void Remove(DotStyles options)
        {
            Style = Style & ~options;
        }

        protected virtual bool HasOptions(DotStyles options)
        {
            return Style.GetValueOrDefault(DotStyles.Default).HasFlag(options);
        }

        protected virtual void ApplyOption(DotStyles option, bool set)
        {
            if (set)
            {
                Apply(option);
            }
            else
            {
                Remove(option);
            }
        }

        protected virtual void SetValue(DotStyles value)
        {
            _attributes.Set(StyleKey, value);
        }

        protected virtual void SetPart<TPart>(TPart style)
            where TPart : Enum
        {
            Style = DotPartialEnumMapper.ToComplete(style, Style.GetValueOrDefault(DotStyles.Default));
        }

        protected virtual TPart GetPart<TPart>()
            where TPart : Enum
        {
            return DotPartialEnumMapper.ToPartial<DotStyles, TPart>(Style.GetValueOrDefault(DotStyles.Default));
        }
    }
}