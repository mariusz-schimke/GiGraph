using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML italicised text element (&lt;i&gt;).
    /// </summary>
    public class DotHtmlItalic : DotHtmlFontStyle
    {
        protected const string TagName = "i";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlItalic()
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
        public DotHtmlItalic(string text, DotHorizontalAlignment? lineAlignment = null)
            : base(TagName, text, lineAlignment)
        {
        }

        protected DotHtmlItalic(DotHtmlAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}