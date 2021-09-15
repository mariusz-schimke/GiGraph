namespace GiGraph.Dot.Entities.Html.Rule
{
    /// <summary>
    ///     An HTML horizontal rule element (&lt;hr&gt;).
    /// </summary>
    public class DotHtmlHorizontalRule : DotHtmlRule
    {
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        public DotHtmlHorizontalRule()
            : base("hr")
        {
        }

        /// <summary>
        ///     Gets a static instance of a horizontal rule element.
        /// </summary>
        public static DotHtmlEntity Instance { get; } = new DotHtmlReadOnlyEntity<DotHtmlHorizontalRule>(new DotHtmlHorizontalRule());
    }
}