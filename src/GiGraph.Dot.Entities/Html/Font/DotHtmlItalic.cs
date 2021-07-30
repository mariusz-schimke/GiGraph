using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Font
{
    // TODO: do tych typów dopasować przyjazne konstruktory (np. tekst lub children)

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

        protected DotHtmlItalic(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}