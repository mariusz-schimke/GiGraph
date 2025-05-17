using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table;

/// <summary>
///     An HTML &lt;table&gt; element.
/// </summary>
public partial class DotHtmlTable : DotHtmlElement, IDotHasHtmlTableBorders
{
    /// <summary>
    ///     Initializes a new table instance.
    /// </summary>
    public DotHtmlTable()
        : this(new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlTable(DotHtmlAttributeCollection attributes)
        : this(
            new DotHtmlTableAttributes(attributes),
            new DotHtmlTableStyleAttributes(attributes),
            new DotHtmlTableTableCellHyperlinkAttributes(attributes),
            new DotHtmlTableTableCellSizeAttributes(attributes),
            new DotHtmlTableAlignmentAttributes(attributes)
        )
    {
    }

    protected DotHtmlTable(
        DotHtmlTableAttributes attributes,
        DotHtmlTableStyleAttributes styleAttributes,
        DotHtmlTableTableCellHyperlinkAttributes hyperlinkAttributes,
        DotHtmlTableTableCellSizeAttributes sizeAttributes,
        DotHtmlTableAlignmentAttributes alignmentAttributes
    )
        : base("table", attributes.Collection)
    {
        Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlTableAttributes, DotHtmlTableAttributes>(attributes);
        Style = styleAttributes;
        Hyperlink = hyperlinkAttributes;
        Size = sizeAttributes;
        Alignment = alignmentAttributes;
    }

    /// <summary>
    ///     Provides access to the attributes of the table.
    /// </summary>
    public new DotHtmlElementRootAttributesAccessor<IDotHtmlTableAttributes, DotHtmlTableAttributes> Attributes { get; }

    /// <summary>
    ///     Adds a new row to the table and optionally initializes it.
    /// </summary>
    /// <param name="init">
    ///     An optional row initializer delegate.
    /// </param>
    public virtual DotHtmlTableRow AddRow(Action<DotHtmlTableRow>? init = null) => Content.Add([], init);

    /// <summary>
    ///     Adds a horizontal rule to separate two neighboring rows.
    /// </summary>
    public virtual DotHtmlHorizontalRule AddHorizontalRule() => Content.Add(new DotHtmlHorizontalRule(), init: null);

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="columnFormat">
    ///     The column format to set. See <see cref="DotHtmlTableColumnFormat"/> for accepted values.
    /// </param>
    /// <param name="rowFormat">
    ///     The row format to set. See <see cref="DotHtmlTableRowFormat"/> for accepted values.
    /// </param>
    public virtual void SetFormat(string? columnFormat = null, string? rowFormat = null)
    {
        ColumnFormat = columnFormat;
        RowFormat = rowFormat;
    }
}