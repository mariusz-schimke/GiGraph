using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Html.Font.Attributes
{
    public class DotHtmlFontAttributes : DotHtmlElementRootAttributes<IDotHtmlFontAttributes>, IDotHtmlFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlFontAttributes, IDotHtmlFontAttributes>().Build();

        protected DotHtmlFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlFontAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlFontAttributesKeyLookup)
        {
        }

        [DotAttributeKey("face")]
        string IDotHtmlFontAttributes.Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("point-size")]
        int? IDotHtmlFontAttributes.Size
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("color")]
        DotColor IDotHtmlFontAttributes.Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}