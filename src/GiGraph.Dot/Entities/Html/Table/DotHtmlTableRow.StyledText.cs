using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Font.Styles;
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
    /// <param name="style">
    ///     The style to apply to the text.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string text, DotFontStyles style, Action<DotHtmlTableCell> init = null) => AddCell(text, style, lineAlignment: null, init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="style">
    ///     The style to apply to the text.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string text, DotFontStyles style, DotHorizontalAlignment? lineAlignment, Action<DotHtmlTableCell> init = null) => Content.Add(new() { DotHtmlFontStyle.WithText(text, style, lineAlignment) }, init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="font">
    ///     The font and style to apply to the text.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string text, DotStyledFont font, Action<DotHtmlTableCell> init = null) => AddCell(text, font, lineAlignment: null, init);

    /// <summary>
    ///     Adds a text cell to the current row.
    /// </summary>
    /// <param name="text">
    ///     The text to initialize the cell with.
    /// </param>
    /// <param name="font">
    ///     The font and style to apply to the text.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    /// <param name="init">
    ///     A cell initializer delegate.
    /// </param>
    public virtual DotHtmlTableCell AddCell(string text, DotStyledFont font, DotHorizontalAlignment? lineAlignment, Action<DotHtmlTableCell> init = null) => Content.Add(new() { DotHtmlFont.WithText(text, font, lineAlignment) }, init);
}