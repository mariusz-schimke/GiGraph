using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML overline text element.
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

        protected DotHtmlOverline(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}