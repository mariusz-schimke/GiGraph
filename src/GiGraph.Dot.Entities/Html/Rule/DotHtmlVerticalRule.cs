using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Rule
{
    /// <summary>
    ///     An HTML vertical rule element (&lt;vr&gt;).
    /// </summary>
    public class DotHtmlVerticalRule : DotHtmlRule
    {
        protected const string TagName = "vr";

        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlVerticalRule()
            : base(TagName)
        {
        }

        protected DotHtmlVerticalRule(DotHtmlAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }

        /// <summary>
        ///     Gets a static instance of a vertical rule element.
        /// </summary>
        public static DotHtmlEntity Instance { get; } = new DotHtmlReadOnlyEntity<DotHtmlVerticalRule>(new DotHtmlVerticalRule());
    }
}