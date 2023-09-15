namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class AttributeOptions
    {
        /// <summary>
        ///     When set, keys will always be quoted, even if it is not required.
        /// </summary>
        public bool PreferQuotedKey { get; set; } = false;

        /// <summary>
        ///     When set, attribute value will always be quoted, even if it is not required.
        /// </summary>
        public bool PreferQuotedValue { get; set; } = false;

        /// <summary>
        ///     When true, attributes enclosed in square brackets (e.g. node attributes), will be separated with colons (,). When false, they
        ///     will be separated with spaces.
        /// </summary>
        public bool PreferExplicitSeparator { get; set; } = true;

        /// <summary>
        ///     HTML attribute options.
        /// </summary>
        public HtmlOptions Html { get; protected set; } = new();
    }
}