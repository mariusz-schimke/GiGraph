using System;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public abstract class DotHtmlEntityAttributes : DotEntityAttributes
    {
        protected DotHtmlEntityAttributes(DotHtmlEntityAttributes source)
            : base(source)
        {
        }

        protected DotHtmlEntityAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        internal new DotHtmlAttributeCollection Collection => (DotHtmlAttributeCollection) base.Collection;
    }
}