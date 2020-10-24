using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: the properties of this class don't inherit documentation comments. Add them manually.
    // TODO: spróbować zrobić coś, żeby atrybuty w klasach potomnych nie powtarzały się między klasami,
    // a jeśli już, to zapewnić spójność nazw za pomocą jakiegoś wspólnego interfejsu?
    public abstract class DotEntityCommonAttributes<TIEntityAttributeProperties> : DotEntityRootAttributes<TIEntityAttributeProperties>
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

        protected internal virtual void SetStyle(DotStyleOptions options)
        {
            Style = options.ApplyTo(Style);
        }

        public virtual void SetDefaultStyle()
        {
            Style = DotStyles.Default;
        }

        /// <summary>
        ///     Applies the specified style option(s) to the <see cref="Style" /> attribute.
        /// </summary>
        /// <param name="option">
        ///     The options to apply.
        /// </param>
        public virtual void ApplyStyleOption(DotStyles option)
        {
            Style = Style.GetValueOrDefault(option) | option;
        }

        /// <summary>
        ///     Removes the specified style option(s) from the <see cref="Style" /> attribute.
        /// </summary>
        /// <param name="option">
        ///     The options to remove.
        /// </param>
        public virtual void RemoveStyleOption(DotStyles option)
        {
            if (Style.HasValue)
            {
                Style &= ~option;
            }
        }
    }
}