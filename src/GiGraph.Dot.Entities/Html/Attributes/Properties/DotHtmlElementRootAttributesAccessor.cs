using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public class DotHtmlElementRootAttributesAccessor<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties> : DotEntityAttributesAccessor<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>
        where THtmlElementAttributeProperties : DotHtmlEntityAttributes<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>, TIHtmlElementAttributeProperties
    {
        public DotHtmlElementRootAttributesAccessor(THtmlElementAttributeProperties attributes)
            : base(attributes)
        {
        }

        public DotHtmlAttributeCollection Collection => ((DotHtmlEntityAttributes<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>) _attributes).Collection;
    }
}