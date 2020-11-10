using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    // TODO: porównać mapę właściwości wszystkich elementów do tego, co było w poprzedniej wersji, żeby upewnić się,
    // że nie zostały pominięte/dodane jakieś atrybuty

    // TODO: czy istnieją klasy, które są stosowane jako value w atrybutach, a których właściwości można zmieniać? Jeśli pobierze się z kolekcji
    // atrybut, który został skonwertowany z innego typu, to zmiana właściwości na tym typie nie wpłynie na kolekcję
    // (może to, czy klasa powinna mieć właściwości write'able powinno zależeć tylko od kontekstu wykorzystania?)
    public abstract class DotEntityCommonAttributes<TIEntityAttributeProperties> : DotEntityRootAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityCommonAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup, DotEntityHyperlinkAttributes hyperlinkAttributes)
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        /// <summary>
        ///     Hyperlink attributes.
        /// </summary>
        public virtual DotEntityHyperlinkAttributes Hyperlink { get; }

        [DotAttributeKey(DotAttributeKeys.Label)]
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        public virtual string ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }
    }
}