using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableCellAttributes : DotHtmlTableTableCellCommonAttributes<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes>, IDotHtmlTableCellAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellAttributes, IDotHtmlTableCellAttributes>().BuildLazy();

    public DotHtmlTableCellAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableCellAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalAlignment"/>
    [DotAttributeKey("align")]
    public virtual partial DotHtmlTableCellHorizontalAlignment? HorizontalAlignment { get; set; }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalLineAlignment"/>
    [DotAttributeKey("balign")]
    public virtual partial DotHorizontalAlignment? HorizontalLineAlignment { get; set; }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.ColumnSpan"/>
    [DotAttributeKey("colspan")]
    public virtual partial int? ColumnSpan { get; set; }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.RowSpan"/>
    [DotAttributeKey("rowspan")]
    public virtual partial int? RowSpan { get; set; }
}