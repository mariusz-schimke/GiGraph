using GiGraph.Dot.Entities.Html.Table.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table;

public partial class DotHtmlTableCell : IDotHtmlTableCellAttributes
{
    /// <summary>
    ///     The style attributes.
    /// </summary>
    public DotHtmlTableCellStyleAttributes Style { get; }

    /// <summary>
    ///     The hyperlink attributes.
    /// </summary>
    public DotHtmlTableTableCellHyperlinkAttributes Hyperlink { get; }

    /// <summary>
    ///     The size attributes.
    /// </summary>
    public DotHtmlTableTableCellSizeAttributes Size { get; }

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

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalAlignment"/>
    public virtual DotHtmlTableCellHorizontalAlignment? HorizontalAlignment
    {
        get => Attributes.Implementation.HorizontalAlignment;
        set => Attributes.Implementation.HorizontalAlignment = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment"/>
    public virtual DotVerticalAlignment? VerticalAlignment
    {
        get => Attributes.Implementation.VerticalAlignment;
        set => Attributes.Implementation.VerticalAlignment = value;
    }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.HorizontalLineAlignment"/>
    public virtual DotHorizontalAlignment? HorizontalLineAlignment
    {
        get => Attributes.Implementation.HorizontalLineAlignment;
        set => Attributes.Implementation.HorizontalLineAlignment = value;
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

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.ColumnSpan"/>
    public virtual int? ColumnSpan
    {
        get => Attributes.Implementation.ColumnSpan;
        set => Attributes.Implementation.ColumnSpan = value;
    }

    /// <inheritdoc cref="IDotHtmlTableCellAttributes.RowSpan"/>
    public virtual int? RowSpan
    {
        get => Attributes.Implementation.RowSpan;
        set => Attributes.Implementation.RowSpan = value;
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders"/>
    public virtual DotHtmlTableBorders? Borders
    {
        get => Attributes.Implementation.Borders;
        set => Attributes.Implementation.Borders = value;
    }
}