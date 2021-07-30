using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Rules
{
    /// <summary>
    ///     An HTML horizontal rule element.
    /// </summary>
    public class DotHtmlHorizontalRule : DotHtmlRule
    {
        protected const string TagName = "hr";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlHorizontalRule()
            : base(TagName)
        {
        }

        protected DotHtmlHorizontalRule(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}