using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableCellAttributes : DotHtmlTableTableCellCommonAttributes, IDotHtmlTableCellAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> HtmlTableCellAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellAttributes, IDotHtmlTableCellAttributes>().BuildLazy();

        public DotHtmlTableCellAttributes(DotHtmlAttributeCollection attributes)
            : this(attributes, HtmlTableCellAttributesKeyLookup)
        {
        }

        private DotHtmlTableCellAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        public virtual DotHtmlTableCellHorizontalAlignment? HorizontalAlignment
        {
            get => GetValueAs<DotHtmlTableCellHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("balign")]
        public virtual DotHorizontalAlignment? HorizontalLineAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("colspan")]
        public virtual int? ColumnSpan
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("rowspan")]
        public virtual int? RowSpan
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}