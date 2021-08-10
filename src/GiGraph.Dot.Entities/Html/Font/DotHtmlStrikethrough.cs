using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML strikethrough text element (&lt;s&gt;).
    /// </summary>
    public class DotHtmlStrikethrough : DotHtmlFontStyle
    {
        protected const string TagName = "s";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlStrikethrough()
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
        public DotHtmlStrikethrough(string text, DotHorizontalAlignment? horizontalAlignment = null)
            : base(TagName, text, horizontalAlignment)
        {
        }

        protected DotHtmlStrikethrough(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}