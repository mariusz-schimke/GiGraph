using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image.Attributes
{
    public class DotHtmlImageAttributes : DotHtmlElementRootAttributes<IDotHtmlImageAttributes>, IDotHtmlImageAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlImageAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlImageAttributes, IDotHtmlImageAttributes>().Build();

        protected DotHtmlImageAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlImageAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlImageAttributesKeyLookup)
        {
        }

        [DotAttributeKey("src")]
        string IDotHtmlImageAttributes.Source
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("scale")]
        DotImageScaling? IDotHtmlImageAttributes.Scaling
        {
            get => GetValueAs<DotImageScaling>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}