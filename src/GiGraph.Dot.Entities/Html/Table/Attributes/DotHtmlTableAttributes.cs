using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableAttributes : DotHtmlTableTableCellCommonAttributes<IDotHtmlTableAttributes, DotHtmlTableAttributes>, IDotHtmlTableAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAttributes, IDotHtmlTableAttributes>().BuildLazy();

        // TODO: konstruktory z AttributeKeyLookup - brakuje ich w elementach HTML

        public DotHtmlTableAttributes(DotHtmlAttributeCollection attributes)
            : base(attributes, AttributeKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey("cellborder")]
        public virtual int? CellBorderWidth
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("rows")]
        public virtual string RowFormat
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("columns")]
        public virtual string ColumnFormat
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}