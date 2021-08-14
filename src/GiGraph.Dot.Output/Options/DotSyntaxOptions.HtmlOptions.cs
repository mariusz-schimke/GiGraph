namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class HtmlOptions
        {
            /// <summary>
            ///     Determines the casing to use for HTML element names.
            /// </summary>
            public virtual DotTextCase ElementNameCasing { get; set; } = DotTextCase.Normal;

            /// <summary>
            ///     Determines the casing to use for HTML element attribute keys.
            /// </summary>
            public virtual DotTextCase AttributeKeyCasing { get; set; } = DotTextCase.Normal;
        }
    }
}