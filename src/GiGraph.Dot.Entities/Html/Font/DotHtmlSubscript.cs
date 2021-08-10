using GiGraph.Dot.Entities.Attributes.Collections;

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
        public DotHtmlSubscript(string text)
            : base(TagName)
        {
            SetContent(text);
        }

        protected DotHtmlSubscript(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}