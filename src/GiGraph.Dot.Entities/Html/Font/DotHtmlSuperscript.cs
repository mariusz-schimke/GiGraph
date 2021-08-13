using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML superscript text element (&lt;sup&gt;).
    /// </summary>
    public class DotHtmlSuperscript : DotHtmlFontStyle
    {
        protected const string TagName = "sup";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlSuperscript()
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
        public DotHtmlSuperscript(string text, DotHorizontalAlignment? lineAlignment = null)
            : base(TagName, text, lineAlignment)
        {
        }

        protected DotHtmlSuperscript(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}