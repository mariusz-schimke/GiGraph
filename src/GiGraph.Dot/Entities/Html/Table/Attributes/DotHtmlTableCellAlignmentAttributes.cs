using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableCellAlignmentAttributes : DotEntityAttributes<IDotHtmlTableCellAlignmentAttributes, DotHtmlTableCellAlignmentAttributes>, IDotHtmlTableCellAlignmentAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellAlignmentAttributes, IDotHtmlTableCellAlignmentAttributes>().BuildLazy();

    public DotHtmlTableCellAlignmentAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableCellAlignmentAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableCellAlignmentAttributes.Horizontal"/>
    [DotAttributeKey("align")]
    public virtual partial DotHtmlTableCellHorizontalAlignment? Horizontal { get; set; }

    /// <inheritdoc cref="IDotHtmlTableCellAlignmentAttributes.Vertical"/>
    [DotAttributeKey("valign")]
    public virtual partial DotVerticalAlignment? Vertical { get; set; }

    /// <inheritdoc cref="IDotHtmlTableCellAlignmentAttributes.Line"/>
    [DotAttributeKey("balign")]
    public virtual partial DotHorizontalAlignment? Line { get; set; }
}