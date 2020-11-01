using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityStyleAttributes : DotEntityAttributes<IDotEntityStyleAttributes>, IDotEntityStyleAttributes
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

        /// <summary>
        ///     Gets style options of the element.
        /// </summary>
        public virtual DotStyles? Options
        {
            get => ((IDotEntityStyleAttributes) this).Options;
            protected set => ((IDotEntityStyleAttributes) this).Options = value;
        }

        [DotAttributeKey(DotAttributeKeys.Style)]
        DotStyles? IDotEntityStyleAttributes.Options
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        /// <summary>
        ///     Sets style to <see cref="DotStyles.Default" />. Useful when the style of elements of the current type is set globally, and it
        ///     needs to be restored to the default value for the current element.
        /// </summary>
        public virtual void RestoreDefault()
        {
            Options = DotStyles.Default;
        }

        /// <summary>
        ///     Removes style options from the current element.
        /// </summary>
        public virtual void Remove()
        {
            Options = null;
        }

        /// <summary>
        ///     Applies the specified style option(s) to the element.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void SetOptions(DotStyles options)
        {
            Options = Options.GetValueOrDefault(options) | options;
        }

        protected virtual void SetOptions(DotStyleOptions options)
        {
            Options = options.ApplyTo(Options);
        }

        /// <summary>
        ///     Removes the specified style option(s) from the <see cref="Options" /> attribute.
        /// </summary>
        /// <param name="options">
        ///     The options to remove.
        /// </param>
        public virtual void RemoveOptions(DotStyles options)
        {
            if (Options.HasValue)
            {
                Options &= ~options;
            }
        }

        /// <summary>
        ///     Checks whether the style has the specified option(s) set.
        /// </summary>
        /// <param name="options">
        ///     The option(s) to check.
        /// </param>
        public virtual bool HasOptions(DotStyles options)
        {
            return Options.HasValue && Options.Value.HasFlag(options);
        }

        protected virtual void ApplyOption(DotStyles option, bool set)
        {
            if (set)
            {
                SetOptions(option);
            }
            else
            {
                RemoveOptions(option);
            }
        }
    }
}