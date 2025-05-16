using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableAttributes : DotHtmlTableTableCellCommonAttributes<IDotHtmlTableAttributes, DotHtmlTableAttributes>, IDotHtmlTableAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAttributes, IDotHtmlTableAttributes>().BuildLazy();

    public DotHtmlTableAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableAttributes.RowFormat"/>
    [DotAttributeKey("rows")]
    public virtual partial string? RowFormat { get; set; }

    /// <inheritdoc cref="IDotHtmlTableAttributes.ColumnFormat"/>
    [DotAttributeKey("columns")]
    public virtual partial string? ColumnFormat { get; set; }
}