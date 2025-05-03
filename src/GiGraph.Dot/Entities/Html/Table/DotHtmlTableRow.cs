using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Table;

/// <summary>
///     An HTML table row (&lt;tr&gt;).
/// </summary>
public partial class DotHtmlTableRow : DotHtmlElement
{
    /// <summary>
    ///     Initializes a new table row instance.
    /// </summary>
    public DotHtmlTableRow()
        : this(new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlTableRow(DotHtmlAttributeCollection attributes)
        : base("tr", attributes)
    {
    }

    /// <summary>
    ///     Adds a cell to the current row.
    /// </summary>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(Action<DotHtmlTableCell>? init = null) => Content.Add([], init);

    /// <summary>
    ///     Adds a cell to the current row.
    /// </summary>
    /// <param name="content">
    ///     The entity to use as the content of the cell.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(IDotHtmlEntity content, Action<DotHtmlTableCell>? init = null) => Content.Add([content], init);

    /// <summary>
    ///     Adds a cell with an image to the current row.
    /// </summary>
    /// <param name="source">
    ///     The image file to be displayed in the cell.
    /// </param>
    /// <param name="scaling">
    ///     Specifies how the image will use any extra space available in its cell.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddImageCell(string? source, DotImageScaling? scaling = null, Action<DotHtmlTableCell>? init = null) =>
        Content.Add([new DotHtmlImage(source, scaling)], init);

    /// <summary>
    ///     Adds a cell with a nested table to the current row.
    /// </summary>
    /// <param name="buildTable">
    ///     A table initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddTableCell(Action<DotHtmlTable>? buildTable)
    {
        var table = new DotHtmlTable();
        buildTable?.Invoke(table);
        return Content.Add<DotHtmlTableCell>([table], init: null);
    }

    /// <summary>
    ///     Adds a cell with a nested table to the current row.
    /// </summary>
    /// <param name="init">
    ///     A cell and table initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddTableCell(Action<DotHtmlTableCell, DotHtmlTable>? init)
    {
        var table = new DotHtmlTable();
        var cell = Content.Add<DotHtmlTableCell>([table], init: null);
        init?.Invoke(cell, table);
        return cell;
    }

    /// <summary>
    ///     Adds a vertical rule to separate two neighboring cells.
    /// </summary>
    public virtual DotHtmlVerticalRule AddVerticalRule() => Content.Add(new DotHtmlVerticalRule(), init: null);
}