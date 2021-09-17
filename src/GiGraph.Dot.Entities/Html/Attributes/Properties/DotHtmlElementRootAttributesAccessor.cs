using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public class DotHtmlElementRootAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>
        where TEntityAttributeProperties : DotHtmlEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
    {
        public DotHtmlElementRootAttributesAccessor(TEntityAttributeProperties attributes)
            : base(attributes)
        {
        }

        public DotHtmlAttributeCollection Collection => ((DotHtmlEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>) _attributes).Collection;
    }
}