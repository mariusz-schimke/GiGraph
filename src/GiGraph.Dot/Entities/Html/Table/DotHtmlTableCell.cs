using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Entities.Qualities;

namespace GiGraph.Dot.Entities.Html.Table;

/// <summary>
///     A cell of an HTML table row (&lt;td&gt;).
/// </summary>
public partial class DotHtmlTableCell : DotHtmlElement, IDotHasHtmlTableBorders
{
    /// <summary>
    ///     Initializes a new table cell instance.
    /// </summary>
    public DotHtmlTableCell()
        : this(new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlTableCell(DotHtmlAttributeCollection attributes)
        : this(
            new DotHtmlTableCellAttributes(attributes),
            new DotHtmlTableCellStyleAttributes(attributes),
            new DotHtmlTableTableCellHyperlinkAttributes(attributes),
            new DotHtmlTableTableCellSizeAttributes(attributes),
            new DotHtmlTableCellAlignmentAttributes(attributes)
        )
    {
    }

    protected DotHtmlTableCell(
        DotHtmlTableCellAttributes attributes,
        DotHtmlTableCellStyleAttributes styleAttributes,
        DotHtmlTableTableCellHyperlinkAttributes hyperlinkAttributes,
        DotHtmlTableTableCellSizeAttributes sizeAttributes,
        DotHtmlTableCellAlignmentAttributes alignmentAttributes
    )
        : base("td", attributes.Collection)
    {
        Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes>(attributes);
        Style = styleAttributes;
        Hyperlink = hyperlinkAttributes;
        Size = sizeAttributes;
        Alignment = alignmentAttributes;
    }

    /// <summary>
    ///     Provides access to the attributes of the table cell.
    /// </summary>
    public new DotHtmlElementRootAttributesAccessor<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes> Attributes { get; }

    /// <summary>
    ///     Sets row and column span.
    /// </summary>
    /// <param name="columnSpan">
    ///     The column span to set.
    /// </param>
    /// <param name="rowSpan">
    ///     The row span to set.
    /// </param>
    public virtual void SetSpan(int? columnSpan = null, int? rowSpan = null)
    {
        ColumnSpan = columnSpan;
        RowSpan = rowSpan;
    }
}