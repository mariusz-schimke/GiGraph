using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Table.Attributes;

namespace GiGraph.Dot.Entities.Html.Table;

/// <summary>
///     A cell of an HTML table row (&lt;td&gt;).
/// </summary>
public partial class DotHtmlTableCell : DotHtmlElement
{
    /// <summary>
    ///     Initializes a new table cell instance.
    /// </summary>
    public DotHtmlTableCell()
        : this(new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlTableCell(DotHtmlAttributeCollection attributes)
        : this(new DotHtmlTableCellAttributes(attributes), new DotHtmlTableCellStyleAttributes(attributes), new DotHtmlTableHyperlinkAttributes(attributes))
    {
    }

    protected DotHtmlTableCell(DotHtmlTableCellAttributes attributes, DotHtmlTableCellStyleAttributes styleAttributes, DotHtmlTableHyperlinkAttributes hyperlinkAttributes)
        : base("td", attributes.Collection)
    {
        Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes>(attributes);
        Style = styleAttributes;
        Hyperlink = hyperlinkAttributes;
    }

    /// <summary>
    ///     Provides access to the attributes of the table cell.
    /// </summary>
    public new DotHtmlElementRootAttributesAccessor<IDotHtmlTableCellAttributes, DotHtmlTableCellAttributes> Attributes { get; }
}