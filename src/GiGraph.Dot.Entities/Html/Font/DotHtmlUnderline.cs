using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML underlined text element (&lt;u&gt;).
    /// </summary>
    public class DotHtmlUnderline : DotHtmlFontStyle
    {
        protected const string TagName = "u";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlUnderline()
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
        public DotHtmlUnderline(string text, DotHorizontalAlignment? horizontalAlignment = null)
            : base(TagName, text, horizontalAlignment)
        {
        }

        protected DotHtmlUnderline(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}