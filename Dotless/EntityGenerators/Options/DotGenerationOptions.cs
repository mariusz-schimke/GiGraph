namespace Dotless.EntityGenerators.Options
{
    public partial class DotGenerationOptions
    {
        public AttributeOptions Attributes { get; } = new AttributeOptions();

        /// <summary>
        /// When set, identifiers will always be quoted, even if it is not required.
        /// </summary>
        public bool PreferQuotedIdentifiers { get; set; } = false;

        /// <summary>
        /// When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public bool PreferStatementDelimiter { get; set; } = false;
    }
}
