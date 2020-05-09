namespace Gigraph.Dot.Generators.Options
{
    public partial class DotGenerationOptions
    {
        public class AttributeOptions
        {
            /// <summary>
            /// When set, attribute value will always be quoted, even if that is not required.
            /// </summary>
            public bool PreferQuotedValue { get; set; } = false;

            /// <summary>
            /// When set, attributes enclosed in square brackets (e.g. node attributes), are separated with colons (,).
            /// </summary>
            public bool PreferExplicitSeparator { get; set; } = true;
        }
    }
}