using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Hyperlinks;

/// <summary>
///     Specifies hyperlink attributes.
/// </summary>
/// <param name="Href">
///     The URL (equivalent to <see cref="Url"/>).
/// </param>
/// <param name="Target">
///     Determines which window of the browser is used for the URL. See
///     <see cref="GiGraph.Dot.Types.Hyperlinks.DotHyperlinkTargets"/>.
/// </param>
/// <param name="Tooltip">
///     The tooltip of the hyperlink (equivalent to <see cref="Title"/>).
/// </param>
/// <param name="Url">
///     The URL (equivalent to <see cref="Href"/>).
/// </param>
/// <param name="Title">
///     The tooltip of the hyperlink (equivalent to <see cref="Tooltip"/>).
/// </param>
public record DotHyperlink(DotEscapeString? Href = null, DotEscapeString? Target = null, DotEscapeString? Tooltip = null, DotEscapeString? Url = null, DotEscapeString? Title = null);