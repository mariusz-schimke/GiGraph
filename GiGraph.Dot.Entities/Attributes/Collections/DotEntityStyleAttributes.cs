using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityStyleAttributes : DotEntityAttributes, IDotEntityStyleAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EntityStyleAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEntityStyleAttributes, IDotEntityStyleAttributes>().Build();

        protected DotEntityStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityStyleAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityStyleAttributesKeyLookup)
        {
        }

        [DotAttributeKey(DotAttributeKeys.Style)]
        public virtual DotStyles? Value
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        /// <summary>
        ///     Applies the specified style option(s) to the element, without removing those that are already set.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Apply(DotStyles options)
        {
            Value = Value.GetValueOrDefault(options) | options;
        }

        /// <summary>
        ///     Assigns the specified style to the element.
        /// </summary>
        /// <param name="options">
        ///     The style to apply.
        /// </param>
        public virtual void Set(DotStyles? options)
        {
            Value = options;
        }

        /// <summary>
        ///     Determines if any style is assigned to the element.
        /// </summary>
        public virtual bool IsSet()
        {
            return Value.HasValue;
        }

        /// <summary>
        ///     Removes style from the current element.
        /// </summary>
        public virtual void Remove()
        {
            Value = null;
        }

        /// <summary>
        ///     Removes the specified style option(s) from the element.
        /// </summary>
        /// <param name="options">
        ///     The options to remove.
        /// </param>
        public virtual void Remove(DotStyles options)
        {
            Value &= ~options;
        }

        /// <summary>
        ///     Sets the style to <see cref="DotStyles.Default" />. Useful when the style of elements of the current type is set globally,
        ///     and needs to be restored to the default value for the current element.
        /// </summary>
        public virtual void SetDefault()
        {
            Value = DotStyles.Default;
        }

        /// <summary>
        ///     Determines if the default style (<see cref="DotStyles.Default" />) is assigned to the element.
        /// </summary>
        public virtual bool IsDefault()
        {
            return Value == DotStyles.Default;
        }

        /// <summary>
        ///     Checks whether the style has the specified option(s) set.
        /// </summary>
        /// <param name="options">
        ///     The option(s) to check.
        /// </param>
        public virtual bool HasOptions(DotStyles options)
        {
            return Value.HasValue && Value.Value.HasFlag(options);
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
    }
}