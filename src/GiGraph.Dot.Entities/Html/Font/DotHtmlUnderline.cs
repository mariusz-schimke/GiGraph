using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML underlined text element (&lt;u&gt;).
    /// </summary>
    public class DotHtmlUnderline : DotHtmlFontStyle
    {
        protected const string TagName = "u";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlUnderline()
            : base(TagName)
        {
        }

        protected DotHtmlUnderline(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}