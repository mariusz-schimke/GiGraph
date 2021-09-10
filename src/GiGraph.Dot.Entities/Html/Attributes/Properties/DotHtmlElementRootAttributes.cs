using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public abstract class DotHtmlElementRootAttributes<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected DotHtmlElementRootAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public virtual DotAttributeCollection Collection => _attributes;
    }
}