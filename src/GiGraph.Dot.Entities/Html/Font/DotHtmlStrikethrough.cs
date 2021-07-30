using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML strikethrough text element.
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

        protected DotHtmlStrikethrough(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}