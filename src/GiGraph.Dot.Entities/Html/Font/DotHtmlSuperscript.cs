using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML superscript text element (&lt;sup&gt;).
    /// </summary>
    public class DotHtmlSuperscript : DotHtmlFontStyle
    {
        protected const string TagName = "sup";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlSuperscript()
            : base(TagName)
        {
        }

        protected DotHtmlSuperscript(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}