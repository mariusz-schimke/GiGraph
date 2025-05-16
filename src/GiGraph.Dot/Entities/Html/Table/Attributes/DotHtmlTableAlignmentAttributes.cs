using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableAlignmentAttributes : DotEntityAttributes<IDotHtmlTableAlignmentAttributes, DotHtmlTableAlignmentAttributes>, IDotHtmlTableAlignmentAttributes
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

    /// <inheritdoc cref="IDotHtmlTableAlignmentAttributes.Vertical"/>
    [DotAttributeKey("valign")]
    public virtual partial DotVerticalAlignment? Vertical { get; set; }

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

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual void Set(DotAlignment alignment)
    {
        Set(new DotAlignmentOptions(alignment));
    }

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual void Set(DotAlignmentOptions alignment)
    {
        Set(alignment.Horizontal, alignment.Vertical);
    }
}