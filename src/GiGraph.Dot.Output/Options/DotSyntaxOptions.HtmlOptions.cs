namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class HtmlOptions
        {
            /// <summary>
            ///     When set to true, HTML tag names will be written in the upper case.
            /// </summary>
            public virtual bool UpperCaseTagNames { get; set; } = false;

            /// <summary>
            ///     When set to true, HTML attribute names will be written in the upper case.
            /// </summary>
            public virtual bool UpperCaseAttributeNames { get; set; } = false;
        }
    }
}