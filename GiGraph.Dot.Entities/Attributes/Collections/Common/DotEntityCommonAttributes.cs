using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
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