using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableCellAttributes : DotHtmlTableTableCellCommonAttributes<IDotHtmlTableAttributes>, IDotHtmlTableCellAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlTableCellAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellAttributes, IDotHtmlTableCellAttributes>().Build();

        protected DotHtmlTableCellAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlTableCellAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlTableCellAttributesKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        DotHorizontalCellAlignment? IDotHtmlTableCellAttributes.HorizontalAlignment
        {
            get => GetValueAs<DotHorizontalCellAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}