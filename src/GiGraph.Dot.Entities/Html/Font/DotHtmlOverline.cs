using GiGraph.Dot.Entities.Attributes.Collections;

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
        public DotHtmlOverline(string text)
            : base(TagName)
        {
            AppendText(text);
        }

        protected DotHtmlOverline(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}