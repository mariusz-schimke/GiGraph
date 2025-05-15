using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableTableCellSizeAttributes : DotEntityAttributes<IDotHtmlTableTableCellSizeAttributes, DotHtmlTableTableCellSizeAttributes>, IDotHtmlTableTableCellSizeAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableTableCellSizeAttributes, IDotHtmlTableTableCellSizeAttributes>().BuildLazy();

    public DotHtmlTableTableCellSizeAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableTableCellSizeAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.Width"/>
    [DotAttributeKey("width")]
    public virtual partial int? Width { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.Height"/>
    [DotAttributeKey("height")]
    public virtual partial int? Height { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.FixedSize"/>
    [DotAttributeKey("fixedsize")]
    public virtual partial bool? FixedSize { get; set; }
}