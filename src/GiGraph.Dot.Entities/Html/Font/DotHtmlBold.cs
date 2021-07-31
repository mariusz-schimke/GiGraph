using GiGraph.Dot.Entities.Attributes.Collections;

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
        public DotHtmlBold(string text)
            : base(TagName)
        {
            AppendText(text);
        }

        protected DotHtmlBold(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}