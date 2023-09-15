using System;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder;

public partial class DotHtmlBuilder
{
    /// <summary>
    ///     Appends a bold element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBuilder> init) => Append(new DotHtmlBold(), init);

    /// <summary>
    ///     Appends an italic element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendItalic(Action<DotHtmlBuilder> init) => Append(new DotHtmlItalic(), init);

    /// <summary>
    ///     Appends an underline element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendUnderline(Action<DotHtmlBuilder> init) => Append(new DotHtmlUnderline(), init);

    /// <summary>
    ///     Appends an overline element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendOverline(Action<DotHtmlBuilder> init) => Append(new DotHtmlOverline(), init);

    /// <summary>
    ///     Appends a subscript element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendSubscript(Action<DotHtmlBuilder> init) => Append(new DotHtmlSubscript(), init);

    /// <summary>
    ///     Appends a superscript element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendSuperscript(Action<DotHtmlBuilder> init) => Append(new DotHtmlSuperscript(), init);

    /// <summary>
    ///     Appends a strikethrough element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendStrikethrough(Action<DotHtmlBuilder> init) => Append(new DotHtmlStrikethrough(), init);

    /// <summary>
    ///     Appends nested font style elements to this instance based on the specified style and initializes the content of the bottom
    ///     one.
    /// </summary>
    /// <param name="fontStyle">
    ///     The font style to use.
    /// </param>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendStyled(DotFontStyles fontStyle, Action<DotHtmlBuilder> init)
    {
        var rootElement = (IDotHtmlContentEntity) DotHtmlFontStyle.FromStyle(fontStyle, out var contentElement)
         ?? new DotHtmlEntityCollection();

        (contentElement ?? rootElement).SetContent(init);
        return AppendEntity(rootElement);
    }
}