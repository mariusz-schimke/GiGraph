using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies hyperlink properties.
    /// </summary>
    public class DotHyperlink
    {
        /// <summary>
        ///     The URL.
        /// </summary>
        public DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        public DotEscapeString Href { get; set; }

        /// <summary>
        ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets" />.
        /// </summary>
        public DotEscapeString Target { get; set; }
    }
}