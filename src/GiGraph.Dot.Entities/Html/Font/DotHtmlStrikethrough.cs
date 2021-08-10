using GiGraph.Dot.Entities.Attributes.Collections;

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
        public DotHtmlStrikethrough(string text)
            : base(TagName)
        {
            SetContent(text);
        }

        protected DotHtmlStrikethrough(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}