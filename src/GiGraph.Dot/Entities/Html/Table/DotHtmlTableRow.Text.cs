using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Table;

public partial class DotHtmlTableRow
{
    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string? text, Action<DotHtmlTableCell>? init = null) => AddCell(text, lineAlignment: null, init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string? text, DotHorizontalAlignment? lineAlignment, Action<DotHtmlTableCell>? init = null) =>
        Content.Add([new DotHtmlText(text, lineAlignment)], init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="font">
    ///     The font to use.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string? text, DotFont font, Action<DotHtmlTableCell>? init = null) =>
        AddCell(text, font, lineAlignment: null, init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="font">
    ///     The font to use.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string? text, DotFont font, DotHorizontalAlignment? lineAlignment, Action<DotHtmlTableCell>? init = null) =>
        Content.Add([DotHtmlFont.WithText(text, font, lineAlignment)], init);
}