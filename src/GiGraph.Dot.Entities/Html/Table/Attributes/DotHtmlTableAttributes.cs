using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableAttributes : DotHtmlTableTableCellCommonAttributes<IDotHtmlTableAttributes>, IDotHtmlTableAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlTableAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAttributes, IDotHtmlTableAttributes>().Build();

        protected DotHtmlTableAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlTableAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlTableAttributesKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        DotHorizontalAlignment? IDotHtmlTableAttributes.HorizontalAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("cellborder")]
        int? IDotHtmlTableAttributes.CellBorderWidth
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("rows")]
        string IDotHtmlTableAttributes.RowFormatting
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("columns")]
        string IDotHtmlTableAttributes.ColumnFormatting
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}