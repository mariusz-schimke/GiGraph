using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML overline text element (&lt;o&gt;).
    /// </summary>
    public class DotHtmlOverline : DotHtmlFontStyle
    {
        protected const string TagName = "o";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlOverline()
            : base(TagName)
        {
        }

        /// <summary>
        ///     Creates a new instance with the specified text as its content.
        /// </summary>
        /// <param name="text">
        ///     The text to set as the content.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public DotHtmlOverline(string text, DotHorizontalAlignment? horizontalAlignment = null)
            : base(TagName, text, horizontalAlignment)
        {
        }

        protected DotHtmlOverline(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}