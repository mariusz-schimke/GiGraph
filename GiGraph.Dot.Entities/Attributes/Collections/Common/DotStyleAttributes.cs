using System;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Mappers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotStyleAttributes
    {
        public const string StyleKey = DotAttributeKeys.Style;
        protected readonly DotAttributeCollection _attributes;

        public DotStyleAttributes(DotAttributeCollection attributes)
        {
            _attributes = attributes;
        }

        protected virtual DotStyles? Style
        {
            get => _attributes.GetValueAs<DotStyles>(StyleKey, out var result) ? result : null;
            set => _attributes.SetOrRemove(StyleKey, value, (k, v) => new DotEnumAttribute<DotStyles>(k, v!.Value));
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
            Style = DotStyles.Default;
        }

        protected virtual void Apply(DotStyles options)
        {
            Style = Style.GetValueOrDefault(options) | options;
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