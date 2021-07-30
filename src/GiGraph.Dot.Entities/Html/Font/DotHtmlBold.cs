using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML bold text element.
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

        protected DotHtmlBold(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}