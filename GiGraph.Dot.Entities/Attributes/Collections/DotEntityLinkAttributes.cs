using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityLinkAttributes : DotEntityAttributes<IDotEntityLinkAttributes>, IDotEntityLinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EntityLinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEntityLinkAttributes));

        protected DotEntityLinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup)
            : base(attributes, propertyAttributeKeyLookup)
        {
        }

        public DotEntityLinkAttributes(DotAttributeCollection attributes)
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
        public virtual DotEscapeString UrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }
    }
}