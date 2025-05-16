using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public abstract partial class DotHtmlTableTableCellCommonAlignmentAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties>(
    DotHtmlAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotHtmlElementAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties>(attributes, attributeKeyLookup), IDotHtmlTableTableCellCommonAlignmentAttributes
    where TIHtmlTableTableCellAlignmentAttributeProperties : IDotHtmlTableTableCellCommonAlignmentAttributes
    where THtmlTableTableCellAlignmentAttributeProperties : DotHtmlTableTableCellCommonAlignmentAttributes<TIHtmlTableTableCellAlignmentAttributeProperties, THtmlTableTableCellAlignmentAttributeProperties>, TIHtmlTableTableCellAlignmentAttributeProperties
{
    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAlignmentAttributes.Vertical"/>
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
    protected abstract void SetAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical);

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
        SetAlignment(alignment.Horizontal, alignment.Vertical);
    }
}