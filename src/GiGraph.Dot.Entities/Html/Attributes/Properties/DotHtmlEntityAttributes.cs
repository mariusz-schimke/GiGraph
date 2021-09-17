using System;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public abstract class DotHtmlEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>
        where TEntityAttributeProperties : DotHtmlEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
    {
        protected DotHtmlEntityAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        internal new DotHtmlAttributeCollection Collection => (DotHtmlAttributeCollection) _attributes;
    }
}