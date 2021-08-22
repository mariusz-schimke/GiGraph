using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies hyperlink properties.
    /// </summary>
    /// <param name="Url">
    ///     The URL.
    /// </param>
    /// <param name="Target">
    ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets" />.
    /// </param>
    /// <param name="Href">
    ///     Synonym for <paramref name="Url" />.
    /// </param>
    public record DotHyperlink(DotEscapeString Url = null, DotEscapeString Target = null, DotEscapeString Href = null);
}