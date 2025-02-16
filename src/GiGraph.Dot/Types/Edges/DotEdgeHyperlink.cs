using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Types.Edges;

/// <summary>
///     Specifies hyperlink attributes (edge specific).
/// </summary>
/// <param name="Url">
///     The URL.
/// </param>
/// <param name="Target">
///     Determines which window of the browser is used for the URL. See
///     <see cref="GiGraph.Dot.Types.Hyperlinks.DotHyperlinkTargets" />.
/// </param>
/// <param name="Tooltip">
///     Tooltip annotation.
/// </param>
/// <param name="Href">
///     Synonym for <paramref name="Url" />.
/// </param>
public record DotEdgeHyperlink(DotEscapeString? Url = null, DotEscapeString? Target = null, DotEscapeString? Tooltip = null, DotEscapeString? Href = null)
    : DotHyperlink(Url, Target, Href);