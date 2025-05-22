using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table;

public partial class DotHtmlTable : IDotHtmlTableAttributes
{
    /// <summary>
    ///     The style attributes.
    /// </summary>
    public DotHtmlTableStyleAttributes Style { get; }

    /// <summary>
    ///     The hyperlink attributes.
    /// </summary>
    public DotHtmlTableTableCellHyperlinkAttributes Hyperlink { get; }

    /// <summary>
    ///     The size attributes.
    /// </summary>
    public DotHtmlTableTableCellSizeAttributes Size { get; }

    /// <summary>
    ///     The alignment attributes.
    /// </summary>
    public DotHtmlTableAlignmentAttributes Alignment { get; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id"/>
    public virtual DotEscapeString? Id
    {
        get => Attributes.Implementation.Id;
        set => Attributes.Implementation.Id = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName"/>
    public virtual string? PortName
    {
        get => Attributes.Implementation.PortName;
        set => Attributes.Implementation.PortName = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding"/>
    public virtual int? CellPadding
    {
        get => Attributes.Implementation.CellPadding;
        set => Attributes.Implementation.CellPadding = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing"/>
    public virtual int? CellSpacing
    {
        get => Attributes.Implementation.CellSpacing;
        set => Attributes.Implementation.CellSpacing = value;
    }

    /// <inheritdoc cref="IDotHtmlTableAttributes.RowFormat"/>
    public virtual string? RowFormat
    {
        get => Attributes.Implementation.RowFormat;
        set => Attributes.Implementation.RowFormat = value;
    }

    /// <inheritdoc cref="IDotHtmlTableAttributes.ColumnFormat"/>
    public virtual string? ColumnFormat
    {
        get => Attributes.Implementation.ColumnFormat;
        set => Attributes.Implementation.ColumnFormat = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders"/>
    public virtual DotHtmlTableBorders? Borders
    {
        get => Attributes.Implementation.Borders;
        set => Attributes.Implementation.Borders = value;
    }

    /// <summary>
    ///     Sets alignment.
    /// </summary>
    /// <param name="columnFormat">
    ///     The column format to set. See <see cref="DotHtmlTableColumnFormat"/> for accepted values.
    /// </param>
    /// <param name="rowFormat">
    ///     The row format to set. See <see cref="DotHtmlTableRowFormat"/> for accepted values.
    /// </param>
    public virtual DotHtmlTable SetFormat(string? columnFormat, string? rowFormat)
    {
        ColumnFormat = columnFormat;
        RowFormat = rowFormat;
        return this;
    }
}