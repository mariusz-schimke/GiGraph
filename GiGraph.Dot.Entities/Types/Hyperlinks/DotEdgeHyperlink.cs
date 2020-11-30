using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies hyperlink properties (edge specific).
    /// </summary>
    public class DotEdgeHyperlink : DotHyperlink
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="url">
        ///     The URL.
        /// </param>
        /// <param name="target">
        ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets" />.
        /// </param>
        /// <param name="tooltip">
        ///     Tooltip annotation.
        /// </param>
        /// <param name="href">
        ///     Synonym for <paramref name="url" />.
        /// </param>
        public DotEdgeHyperlink(DotEscapeString url = null, DotEscapeString target = null, DotEscapeString tooltip = null, DotEscapeString href = null)
            : base(url, target, href)
        {
            Tooltip = tooltip;
        }

        /// <summary>
        ///     The tooltip annotation.
        /// </summary>
        public virtual DotEscapeString Tooltip { get; set; }
    }
}