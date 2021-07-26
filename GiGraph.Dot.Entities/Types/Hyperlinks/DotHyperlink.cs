using GiGraph.Dot.Entities.Types.Text;

namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies hyperlink properties.
    /// </summary>
    public class DotHyperlink
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
        /// <param name="href">
        ///     Synonym for <paramref name="url" />.
        /// </param>
        public DotHyperlink(DotEscapeString url = null, DotEscapeString target = null, DotEscapeString href = null)
        {
            Url = url;
            Target = target;
            Href = href;
        }

        /// <summary>
        ///     The URL.
        /// </summary>
        public virtual DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        public virtual DotEscapeString Href { get; set; }

        /// <summary>
        ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets" />.
        /// </summary>
        public virtual DotEscapeString Target { get; set; }
    }
}