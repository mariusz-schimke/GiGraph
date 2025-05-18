using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

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

    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="color">
    ///     The color to set.
    /// </param>
    /// <param name="width">
    ///     The border width to set.
    /// </param>
    /// <param name="cellBorderWidth">
    ///     The cell border width to set.
    /// </param>
    public virtual void SetBorderStyle(DotColor? color, int? width, int? cellBorderWidth)
    {
        CellBorderWidth = cellBorderWidth;
        SetBorderStyle(color, width);
    }
}