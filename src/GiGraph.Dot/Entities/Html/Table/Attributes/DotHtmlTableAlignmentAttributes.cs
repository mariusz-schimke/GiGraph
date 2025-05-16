using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableAlignmentAttributes : DotHtmlTableTableCellCommonAlignmentAttributes<IDotHtmlTableAlignmentAttributes, DotHtmlTableAlignmentAttributes>, IDotHtmlTableAlignmentAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableAlignmentAttributes, IDotHtmlTableAlignmentAttributes>().BuildLazy();

    public DotHtmlTableAlignmentAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableAlignmentAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableAlignmentAttributes.Horizontal"/>
    [DotAttributeKey("align")]
    public virtual partial DotHorizontalAlignment? Horizontal { get; set; }

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="horizontal">
    ///     The horizontal alignment to set.
    /// </param>
    /// <param name="vertical">
    ///     The vertical alignment to set.
    /// </param>
    public virtual void Set(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    protected override void SetAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        Set(horizontal, vertical);
    }
}