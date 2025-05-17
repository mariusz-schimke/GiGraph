using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableStyleAttributes : DotHtmlTableTableCellCommonStyleAttributes<IDotHtmlTableStyleAttributes, DotHtmlTableStyleAttributes>, IDotHtmlTableStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableStyleAttributes, IDotHtmlTableStyleAttributes>().BuildLazy();

    public DotHtmlTableStyleAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableStyleAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableStyleAttributes.CellBorderWidth"/>
    [DotAttributeKey("cellborder")]
    public virtual partial int? CellBorderWidth { get; set; }
}