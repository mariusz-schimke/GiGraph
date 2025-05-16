using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public abstract partial class DotHtmlTableTableCellCommonAlignmentAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties, THorizontalAlignment>(
    DotHtmlAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotHtmlElementAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties>(attributes, attributeKeyLookup), IDotHtmlTableTableCellCommonAlignmentAttributes<THorizontalAlignment>
    where TIHtmlTableTableCellAlignmentAttributeProperties : IDotHtmlTableTableCellCommonAlignmentAttributes<THorizontalAlignment>
    where THtmlTableTableCellAlignmentAttributeProperties : DotHtmlTableTableCellCommonAlignmentAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties, THorizontalAlignment>, TIHtmlTableTableCellAlignmentAttributeProperties
    where THorizontalAlignment : struct, Enum
{
    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAlignmentAttributes{THorizontalAlignment}.Horizontal"/>
    [DotAttributeKey("align")]
    public virtual partial THorizontalAlignment? Horizontal { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAlignmentAttributes{THorizontalAlignment}.Vertical"/>
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
    public virtual void Set(THorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
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
        Set(new DotAlignmentOptions<THorizontalAlignment, DotVerticalAlignment>(alignment));
    }

    protected virtual void Set<TAlignmentOptions>(TAlignmentOptions alignment)
        where TAlignmentOptions : DotAlignmentOptions<THorizontalAlignment, DotVerticalAlignment>
    {
        Set(alignment.Horizontal, alignment.Vertical);
    }
}