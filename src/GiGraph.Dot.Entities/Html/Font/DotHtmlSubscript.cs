using GiGraph.Dot.Entities.Html.Attributes.Collections;
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
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public DotHtmlSubscript(string text, DotHorizontalAlignment? lineAlignment = null)
            : base(TagName, text, lineAlignment)
        {
        }

        protected DotHtmlSubscript(DotHtmlAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}