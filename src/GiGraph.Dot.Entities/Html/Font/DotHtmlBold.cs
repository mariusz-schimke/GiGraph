using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML bold text element (&lt;b&gt;).
    /// </summary>
    public class DotHtmlBold : DotHtmlFontStyle
    {
        protected const string TagName = "b";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlBold()
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
        public DotHtmlBold(string text, DotHorizontalAlignment? horizontalAlignment = null)
            : base(TagName, text, horizontalAlignment)
        {
        }

        protected DotHtmlBold(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}