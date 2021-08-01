using GiGraph.Dot.Entities.Attributes.Collections;

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

        protected DotHtmlVerticalRule(DotAttributeCollection attributes)
            : base(TagName, attributes)
        {
        }
    }
}