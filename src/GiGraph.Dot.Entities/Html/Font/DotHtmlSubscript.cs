using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML subscript text element (&lt;sub&gt;).
    /// </summary>
    public class DotHtmlSubscript : DotHtmlFontStyle
    {
        protected const string TagName = "sub";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlSubscript()
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
        public DotHtmlSubscript(string text, DotHorizontalAlignment? horizontalAlignment = null)
            : base(TagName, text, horizontalAlignment)
        {
        }

        protected DotHtmlSubscript(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}