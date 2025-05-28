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
    /// <param name="tableBorderWidth">
    ///     The border width to set.
    /// </param>
    /// <param name="cellBorderWidth">
    ///     The cell border width to set.
    /// </param>
    /// <param name="color">
    ///     The color to set.
    /// </param>
    public virtual DotHtmlTableStyleAttributes SetBorderStyle(int? tableBorderWidth, int? cellBorderWidth, DotColor? color)
    {
        // !!! mind the order of arguments in the overload of this method in the base class to keep them consistent !!!
        // (see also the methods in DotHasBorderStyleAttributesExtension)

        BorderColor = color;
        return SetBorderWidths(tableBorderWidth, cellBorderWidth);
    }

    /// <summary>
    ///     Sets border widths.
    /// </summary>
    /// <param name="tableBorderWidth">
    ///     The border width to set for the table.
    /// </param>
    /// <param name="cellBorderWidth">
    ///     The border width to set for the cells.
    /// </param>
    public virtual DotHtmlTableStyleAttributes SetBorderWidths(int? tableBorderWidth, int? cellBorderWidth)
    {
        BorderWidth = tableBorderWidth;
        CellBorderWidth = cellBorderWidth;
        return this;
    }
}