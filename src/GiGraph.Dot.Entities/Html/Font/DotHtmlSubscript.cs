using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML subscript text element.
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

        protected DotHtmlSubscript(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}