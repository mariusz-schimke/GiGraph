namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class HtmlOptions
    {
        /// <summary>
        ///     Determines the casing to use for HTML element names.
        /// </summary>
        public DotTextCase ElementNameCasing { get; set; } = DotTextCase.Default;

        /// <summary>
        ///     Determines the casing to use for HTML element attribute keys.
        /// </summary>
        public DotTextCase AttributeKeyCasing { get; set; } = DotTextCase.Default;
    }
}