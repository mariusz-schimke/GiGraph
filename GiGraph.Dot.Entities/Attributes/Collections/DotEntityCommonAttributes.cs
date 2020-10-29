using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: porównać mapę właściwości wszystkich elementów do tego, co było w poprzedniej wersji, żeby upewnić się,
    // że nie zostały pominięte/dodane jakieś atrybuty
    
    // TODO: spróbować zastąpić Style konkretną klasą, tylko trzeba uważać, bo zmiana flagi w tej klasie nie spowoduje aktualizacji kolekcji
    // więc może klasy powinny być read only
    
    // TODO: czy istnieją klasy, które są stosowane jako value w atrybutach, a których właściwości można zmieniać? Jeśli pobierze się z kolekcji
    // atrybut, który został skonwertowany z innego typu, to zmiana właściwości na tym typie nie wpłynie na kolekcję
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

        /// <summary>
        ///     Sets the style to <see cref="DotStyles.Default" />. Useful when the style of this type of element is set globally, and you
        ///     want to restore it to the default one.
        /// </summary>
        public virtual void RestoreDefaultStyle()
        {
            Style = DotStyles.Default;
        }

        /// <summary>
        ///     Applies the specified style option(s) to the <see cref="Style" /> attribute, preserving those that are already set.
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