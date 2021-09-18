using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties
{
    public class DotHtmlElementRootAttributesAccessor<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties> : DotEntityAttributesAccessor<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>
        where THtmlElementAttributeProperties : DotHtmlElementAttributes<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>, TIHtmlElementAttributeProperties
    {
        public DotHtmlElementRootAttributesAccessor(THtmlElementAttributeProperties attributes)
            : base(attributes)
        {
        }

        public DotHtmlAttributeCollection Collection => ((DotHtmlElementAttributes<TIHtmlElementAttributeProperties, THtmlElementAttributeProperties>) _attributes).Collection;
    }
}