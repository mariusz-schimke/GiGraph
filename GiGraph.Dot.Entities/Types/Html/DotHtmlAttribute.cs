using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     An attribute of an HTML tag.
    /// </summary>
    public abstract class DotHtmlAttribute
    {
        /// <summary>
        ///     Gets the value of the attribute in an HTML-compliant format.
        /// </summary>
        public abstract DotHtml ToHtml();
    }
}