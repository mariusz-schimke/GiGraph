using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public class DotHtmlElementRootAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>
        where TEntityAttributeProperties : DotHtmlEntityAttributes, TIEntityAttributeProperties
    {
        public DotHtmlElementRootAttributes(TEntityAttributeProperties attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public new DotHtmlAttributeCollection Collection => (DotHtmlAttributeCollection) _attributes;
    }
}