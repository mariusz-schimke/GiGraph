using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Rule
{
    /// <summary>
    ///     An HTML horizontal rule element (&lt;hr&gt;).
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

        protected DotHtmlHorizontalRule(DotHtmlAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }

        /// <summary>
        ///     Gets a static instance of a horizontal rule element.
        /// </summary>
        public static DotHtmlEntity Instance { get; } = new DotHtmlReadOnlyEntity<DotHtmlHorizontalRule>(new DotHtmlHorizontalRule());
    }
}