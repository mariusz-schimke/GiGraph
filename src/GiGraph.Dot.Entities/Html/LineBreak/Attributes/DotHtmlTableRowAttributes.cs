using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak.Attributes
{
    public class DotHtmlLineBreakAttributes : DotHtmlElementRootAttributes<IDotHtmlTableRowAttributes>, IDotHtmlLineBreakAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlLineBreakAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlLineBreakAttributes, IDotHtmlLineBreakAttributes>().Build();

        protected DotHtmlLineBreakAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlLineBreakAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlLineBreakAttributesKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        DotHorizontalAlignment? IDotHtmlLineBreakAttributes.HorizontalAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}