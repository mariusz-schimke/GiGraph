using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: the properties of this class don't inherit documentation comments. Add them manually.
    public abstract class DotEntityCommonAttributes<TIEntityAttributeProperties> : DotEntityTopLevelAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityCommonAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEntityHyperlinkAttributes hyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        protected DotEntityCommonAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : this(attributes, attributeKeyLookup, new DotEntityHyperlinkAttributes(attributes))
        {
        }

        /// <summary>
        ///     Hyperlink attributes.
        /// </summary>
        public virtual DotEntityHyperlinkAttributes Hyperlink { get; }

        [DotAttributeKey("label")]
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("colorscheme")]
        public virtual string ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("style")]
        public virtual DotStyles? Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        [DotAttributeKey("comment")]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        protected internal virtual DotStyles? SetStyle(
            bool? filled = null,
            bool? solid = null,
            bool? dashed = null,
            bool? dotted = null,
            bool? bold = null,
            bool? rounded = null,
            bool? diagonals = null,
            bool? striped = null,
            bool? wedged = null,
            bool? radial = null,
            bool? tapered = null,
            bool? invisible = null
        )
        {
            var result = Style.GetValueOrDefault(DotStyles.Default);

            var setOption = new Action<DotStyles, bool?>((option, set) =>
            {
                if (set == true)
                {
                    result |= option;
                }
                else if (set == false)
                {
                    result &= ~option;
                }
            });

            setOption(DotStyles.Filled, filled);
            setOption(DotStyles.Solid, solid);
            setOption(DotStyles.Dashed, dashed);
            setOption(DotStyles.Dotted, dotted);
            setOption(DotStyles.Bold, bold);
            setOption(DotStyles.Rounded, rounded);
            setOption(DotStyles.Diagonals, diagonals);
            setOption(DotStyles.Striped, striped);
            setOption(DotStyles.Wedged, wedged);
            setOption(DotStyles.Radial, radial);
            setOption(DotStyles.Tapered, tapered);
            setOption(DotStyles.Invisible, invisible);

            if (result == DotStyles.Default)
            {
                // restore to default style if any style was set, or leave null otherwise
                return Style = Style.HasValue ? result : Style;
            }

            return Style = result;
        }

        public virtual void SetDefaultStyle()
        {
            Style = DotStyles.Default;
        }

        /// <summary>
        ///     Applies the specified style options to the <see cref="Style" /> attribute.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void ApplyStyleOptions(DotStyles options)
        {
            Style = Style.GetValueOrDefault(options) | options;
        }

        /// <summary>
        ///     Removes the specified style options from the <see cref="Style" /> attribute.
        /// </summary>
        /// <param name="options">
        ///     The options to remove.
        /// </param>
        public virtual void RemoveStyleOptions(DotStyles options)
        {
            if (Style.HasValue)
            {
                Style &= ~options;
            }
        }
    }
}