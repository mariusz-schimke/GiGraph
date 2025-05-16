using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableCellAlignmentAttributes : DotHtmlTableTableCellCommonAlignmentAttributes<IDotHtmlTableCellAlignmentAttributes, DotHtmlTableCellAlignmentAttributes>, IDotHtmlTableCellAlignmentAttributes
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

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="horizontal">
    ///     The horizontal alignment to set.
    /// </param>
    /// <param name="vertical">
    ///     The vertical alignment to set.
    /// </param>
    public virtual void Set(DotHtmlTableCellHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    protected override void SetAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        Set((DotHtmlTableCellHorizontalAlignment?) horizontal, vertical);
    }
}