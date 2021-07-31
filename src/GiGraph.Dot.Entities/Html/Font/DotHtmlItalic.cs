using GiGraph.Dot.Entities.Attributes.Collections;

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
        public DotHtmlItalic(string text)
            : base(TagName)
        {
            AppendText(text);
        }

        protected DotHtmlItalic(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}