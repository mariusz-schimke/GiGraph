using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityHyperlinkAttributes : DotEntityAttributes<IDotEntityHyperlinkAttributes>, IDotEntityHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EntityLinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEntityHyperlinkAttributes));

        protected DotEntityHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityLinkAttributesKeyLookup)
        {
        }

        [DotAttributeKey("URL")]
        public virtual DotEscapeString Url
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("href")]
        public virtual DotEscapeString Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("target")]
        public virtual DotEscapeString Target
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public void Set(DotEscapeString url, DotEscapeString target, DotEscapeString href = null)
        {
        }
    }
}