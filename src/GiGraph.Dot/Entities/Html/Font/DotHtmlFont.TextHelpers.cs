using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font;

public partial class DotHtmlFont
{
    /// <summary>
    ///     Embeds the text in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="text">
    ///     The text to embed in font and style elements.
    /// </param>
    /// <param name="font">
    ///     The font and/or style to apply.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    public static DotHtmlFont WithText(string? text, DotFont font, DotHorizontalAlignment? lineAlignment = null) => WithEntity(new DotHtmlText(text, lineAlignment), font);

    /// <summary>
    ///     Embeds the text in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="text">
    ///     The text to embed in font and style elements.
    /// </param>
    /// <param name="font">
    ///     The font and/or style to apply.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    public static DotHtmlFont WithText(string? text, DotStyledFont font, DotHorizontalAlignment? lineAlignment = null) => WithEntity(new DotHtmlText(text, lineAlignment), font);
}